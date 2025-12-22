using System.Runtime.InteropServices;

namespace iReverse_BootInfo.EROFS.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ErofsInodeV1
    {
        public ushort i_advise;
        public ushort i_xattr_icount;
        public ushort i_mode;
        public ushort i_nlink;
        public uint i_size;
        public uint i_reserved;
        public uint i_u;
        public uint i_ino;
        public ushort i_uid;
        public ushort i_gid;
        public uint checksum;
    }
}
