using System.Runtime.InteropServices;

public static class Lz4Decompressor
{
    [DllImport(@"bin\lib\lz4-iReverse-hadikit.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int LZ4_hadikit_iReverse_decompress(byte[] src, byte[] dst, int isize);

    public static int lz4_hadikit_decompress(byte[] src, ref byte[] dst)
    {
        return LZ4_hadikit_iReverse_decompress(src: src, dst: dst, isize: src.Length);
    }

}
