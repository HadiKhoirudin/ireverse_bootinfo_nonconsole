using iReverse_BootInfo.EROFS.Compression;
using iReverse_BootInfo.EROFS.IO;
using iReverse_BootInfo.EROFS.Structs;
using System;
using System.IO;

namespace iReverse_BootInfo.EROFS.Core
{
    public abstract class Inode
    {
        protected readonly ErofsImage Image;
        protected readonly uint Nid;
        protected readonly ErofsInodeV1 Header;
        protected readonly long InodeOffset;
        protected readonly long XattrStart;
        protected readonly int XattrSize;

        protected Inode(ErofsImage img, uint nid)
        {
            Image = img;
            Nid = nid;

            InodeOffset = img.Super.meta_blkaddr * 4096L + nid * 32;
            Header = StructReader.Read<ErofsInodeV1>(
                img.File.Read(InodeOffset, 32)
            );

            XattrStart = InodeOffset + 32;
            XattrSize = Header.i_xattr_icount > 0
                ? 12 + (Header.i_xattr_icount - 1) * 4
                : 0;
        }

        protected byte[] ReadData()
        {
            int mode = (Header.i_advise >> 1) & 0x3;

            switch (mode)
            {
                case 0: // EROFS_INODE_FLAT_PLAIN
                    return Image.File.Read(
                        Header.i_u * 4096L,
                        (int)Header.i_size
                    );

                case 1: // EROFS_INODE_LEGACY_COMPRESSION
                    return ReadCompressedLegacy();

                case 2: // EROFS_INODE_FLAT_INLINE
                    return ReadInline();

                case 3: // EROFS_INODE_FLAT_COMPRESSION
                    return ReadCompressed();

                default:
                    throw new NotSupportedException($"Mapping mode {mode} not supported");
            }
        }


        private byte[] ReadCompressed()
        {
            long pos = XattrStart + XattrSize;
            pos = (pos + 7) & ~7L;

            var hdr = StructReader.Read<ZMapHeader>(
                Image.File.Read(pos, 8)
            );
            pos += 8;

            int clusterSize = 1 << hdr.h_clusterbits;

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < Header.i_u; i++)
                {
                    var idx = StructReader.Read<ZVleClusterIndex>(
                        Image.File.Read(pos + i * 4, 4)
                    );

                    if (idx.blkaddr == 0)
                        continue;

                    byte[] compressed = Image.File.Read(
                        idx.blkaddr * 4096L,
                        clusterSize
                    );

                    int remain = (int)(Header.i_size - ms.Position);
                    byte[] dec = Lz4Raw.Decompress(compressed, remain);

                    ms.Write(dec, 0, dec.Length);

                    if (ms.Length >= Header.i_size)
                        break;
                }

                var data = ms.ToArray();
                if (data.Length > Header.i_size)
                    Array.Resize(ref data, (int)Header.i_size);

                return data;
            }
        }

        private byte[] ReadCompressedLegacy()
        {
            int blockSize = 4096;
            int numBlocks = (int)((Header.i_size + blockSize - 1) / blockSize);

            long pos = XattrStart + XattrSize;

            if ((pos & 7) == 4)
                pos += 4;

            pos += 12; // z_erofs_map_header (legacy)
            pos += 8;  // legacy padding

            using (var ms = new MemoryStream())
            {
                uint prevBlk = 0;

                for (int i = 0; i < numBlocks; i++)
                {
                    var di = StructReader.Read<ZVleDecompressedIndex>(
                        Image.File.Read(pos + i * 8, 8)
                    );

                    int type = di.di_advise & 0x3;
                    uint blkaddr = di.di_u;

                    if (type == 0) // PLAIN
                    {
                        byte[] data = Image.File.Read(
                            blkaddr * blockSize,
                            blockSize
                        );
                        ms.Write(data, 0, data.Length);
                    }
                    else if (type == 1 || type == 3) // HEAD / RESERVED
                    {
                        if (blkaddr == prevBlk)
                            continue;

                        prevBlk = blkaddr;

                        byte[] compressed = Image.File.Read(
                            blkaddr * blockSize,
                            blockSize
                        );

                        int remain = (int)(Header.i_size - ms.Position);
                        var dec = Lz4Raw.Decompress(compressed, remain);
                        ms.Write(dec, 0, dec.Length);
                    }
                }

                var result = ms.ToArray();
                if (result.Length > Header.i_size)
                    Array.Resize(ref result, (int)Header.i_size);

                return result;
            }
        }

        private byte[] ReadInline()
        {
            long dataOff = XattrStart + XattrSize;

            return Image.File.Read(
                dataOff,
                (int)Header.i_size
            );
        }

        public abstract byte[] GetData();
    }
}
