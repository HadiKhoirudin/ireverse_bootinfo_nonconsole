using System.Runtime.InteropServices;

namespace iReverse_BootInfo.EROFS.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ZMapHeader
    {
        public uint h_reserved1;
        public ushort h_advise;
        public byte h_algorithmtype;
        public byte h_clusterbits;
    }
}
