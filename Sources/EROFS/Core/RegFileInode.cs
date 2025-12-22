using System;

namespace iReverse_BootInfo.EROFS.Core
{
    public sealed class RegFileInode : Inode
    {
        public RegFileInode(ErofsImage img, uint nid) : base(img, nid)
        {
            const int S_IFREG = 0x8000;
            if ((Header.i_mode & 0xF000) != S_IFREG)
                throw new InvalidOperationException("Not a regular file");
        }

        public override byte[] GetData()
        {
            return ReadData();
        }
    }
}
