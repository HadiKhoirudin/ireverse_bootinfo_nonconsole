using System.Runtime.InteropServices;

namespace iReverse_BootInfo.EROFS.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ErofsDirent
    {
        public ulong nid;
        public ushort nameoff;
        public byte file_type;
        public byte reserved;
    }
}
