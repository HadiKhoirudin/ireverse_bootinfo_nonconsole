using System;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace FsExt4.IO
{
    public sealed class MappedFile : IDisposable
    {
        private readonly MemoryMappedFile _mmf;
        private readonly MemoryMappedViewAccessor _view;
        private readonly long _fileLength;

        public long Length => _fileLength;

        public MappedFile(string path)
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            _fileLength = fs.Length;

            _mmf = MemoryMappedFile.CreateFromFile(
                fs,
                null,
                0,
                MemoryMappedFileAccess.Read,
                null,
                HandleInheritability.None,
                false
            );

            _view = _mmf.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read);
        }

        public byte[] Read(long offset, int size)
        {
            if (offset < 0 || offset >= _fileLength)
                throw new ArgumentOutOfRangeException(
                    nameof(offset),
                    $"Offset 0x{offset:X} outside mapped file (size=0x{_fileLength:X})"
                );

            long maxReadable = _fileLength - offset;
            if (size > maxReadable)
                size = (int)maxReadable;

            var buf = new byte[size];
            _view.ReadArray(offset, buf, 0, size);
            return buf;
        }

        public void Dispose()
        {
            _view?.Dispose();
            _mmf?.Dispose();
        }
    }
}
