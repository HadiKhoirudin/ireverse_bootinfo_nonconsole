using System.Runtime.InteropServices;

namespace iReverse_BootInfo.EROFS.IO
{
    public static class StructReader
    {
        public static T Read<T>(byte[] buf) where T : struct
        {
            GCHandle h = GCHandle.Alloc(buf, GCHandleType.Pinned);
            try
            {
                return Marshal.PtrToStructure<T>(h.AddrOfPinnedObject());
            }
            finally
            {
                h.Free();
            }
        }
    }
}
