using iReverse_BootInfo.EROFS.IO;
using iReverse_BootInfo.EROFS.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iReverse_BootInfo.EROFS.Core
{
    public sealed class DirInode : Inode
    {
        private readonly List<DirEnt> _entries = new List<DirEnt>();

        public DirInode(ErofsImage img, uint nid) : base(img, nid)
        {
            Parse();
        }

        private void Parse()
        {
            byte[] data = ReadData();
            if (data.Length == 0)
                return;

            var first = StructReader.Read<ErofsDirent>(
                data.Take(12).ToArray()
            );
            int count = first.nameoff / 12;

            var dirents = Enumerable.Range(0, count)
                .Select(i => StructReader.Read<ErofsDirent>(
                    data.Skip(i * 12).Take(12).ToArray()
                ))
                .ToArray();

            for (int i = 0; i < count; i++)
            {
                int start = dirents[i].nameoff;
                int end = (i + 1 < count) ? dirents[i + 1].nameoff : data.Length;

                var name = data.Skip(start).Take(end - start).ToArray();
                int zero = Array.IndexOf(name, (byte)0);
                if (zero >= 0)
                    Array.Resize(ref name, zero);

                _entries.Add(new DirEnt(name, dirents[i].file_type, dirents[i].nid));
            }
        }

        public string result = "";
        public string Extract(string path = "/")
        {
            foreach (var e in _entries)
            {
                if (Encoding.ASCII.GetString(e.FileName) == "." || Encoding.ASCII.GetString(e.FileName) == "..")
                    continue;

                try
                {
                    string currentPath = Path.Combine(path, Encoding.ASCII.GetString(e.FileName)).Replace("\\", "/");

                    Console.WriteLine($"Parsing : {currentPath}");

                    switch (e.FileType)
                    {
                        case 1: // REG
                            if (!currentPath.EndsWith(".prop", StringComparison.OrdinalIgnoreCase))
                                continue;

                            var file = new RegFileInode(Image, (uint)e.Nid);

                            if (currentPath.EndsWith(".prop"))
                                result += Encoding.UTF8.GetString(file.GetData()).Trim('\0');

                            break;

                        case 2: // DIR
                            result += new DirInode(Image, (uint)e.Nid).Extract(currentPath);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine
                    (
                        $"\nExtract Error : \n{ex}\n" +
                        $"{ex.Message}\n" +
                        $"While Extracting File [{Encoding.ASCII.GetString(e.FileName)}] FileType [{e.FileType}] Nid [{e.Nid}]\n"
                    );
                    continue;
                }
            }
            return result;
        }

        public override byte[] GetData() => throw new NotSupportedException();
    }
}
