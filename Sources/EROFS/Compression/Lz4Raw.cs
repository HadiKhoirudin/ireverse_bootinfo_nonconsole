
using System;

namespace iReverse_BootInfo.EROFS.Compression
{
    public static class Lz4Raw
    {
        public static byte[] Decompress(byte[] src, int maxLen)
        {
            byte[] dst = new byte[maxLen];

            var decoded = Lz4Decompressor.lz4_hadikit_decompress(src: src, dst: ref dst);

            if (decoded < 0)
                throw new InvalidOperationException("LZ4 decode failed");

            if (decoded == maxLen)
                return dst;

            byte[] trimmed = new byte[decoded];
            Buffer.BlockCopy(dst, 0, trimmed, 0, decoded);
            return trimmed;
        }
    }
}
