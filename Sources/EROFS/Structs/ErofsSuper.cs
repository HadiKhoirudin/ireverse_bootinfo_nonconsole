using System.Runtime.InteropServices;

namespace iReverse_BootInfo.EROFS.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ErofsSuper
    {
        public uint magic;
        public uint checksum;
        public uint features;
        public byte blkszbits;
        public byte reserved;
        public ushort root_nid;
        public ulong inos;
        public ulong build_time;
        public uint build_time_nsec;
        public uint blocks;
        public uint meta_blkaddr;
        public uint xattr_blkaddr;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] uuid;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] volume_name;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] reserved2;
    }
}
