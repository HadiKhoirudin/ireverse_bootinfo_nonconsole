using System;

namespace iReverse_BootInfo.EROFS.Core
{
    public sealed class SymlinkInode : Inode
    {
        private readonly byte[] _target;

        public SymlinkInode(ErofsImage img, uint nid) : base(img, nid)
        {
            const int S_IFLNK = 0xA000;
            if ((Header.i_mode & 0xF000) != S_IFLNK)
                throw new InvalidOperationException("Not a symlink");

            _target = ReadData();
        }

        public byte[] GetTarget() => _target;

        public override byte[] GetData() => _target;
    }
}
