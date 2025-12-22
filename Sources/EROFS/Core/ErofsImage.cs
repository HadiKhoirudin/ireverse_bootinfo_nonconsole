using FsExt4.IO;
using iReverse_BootInfo.EROFS.IO;
using iReverse_BootInfo.EROFS.Structs;
using System;

namespace iReverse_BootInfo.EROFS.Core
{
    public sealed class ErofsImage : IDisposable
    {
        public readonly MappedFile File;
        public readonly ErofsSuper Super;
        public readonly DirInode Root;
        public int BlockBits { get; private set; }
        public long DataOff { get; private set; }

        public ErofsImage(string path)
        {
            File = new MappedFile(path);

            Super = StructReader.Read<ErofsSuper>(
                File.Read(0x400, 128)
            );

            if (Super.magic != 0xE0F5E1E2)
                throw new InvalidOperationException("Invalid EROFS magic");

            Root = new DirInode(this, Super.root_nid);

            BlockBits = Super.blkszbits;
            DataOff = (long)Super.xattr_blkaddr << BlockBits;

            Console.WriteLine($"\nBlock Bits : {BlockBits}");
            Console.WriteLine($"DataOff    : {DataOff}\n");
        }

        public void Dispose()
        {
            File.Dispose();
        }
    }
}
