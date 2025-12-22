using System.Runtime.InteropServices;

namespace iReverse_BootInfo.EROFS.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ZVleDecompressedIndex
    {
        public ushort di_advise;
        public ushort di_clusterofs;
        public uint di_u; // blkaddr or delta
    }
}
