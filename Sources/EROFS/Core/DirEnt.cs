namespace iReverse_BootInfo.EROFS.Core
{
    public sealed class DirEnt
    {
        public byte[] FileName { get; }
        public byte FileType { get; }
        public ulong Nid { get; }

        public DirEnt(byte[] name, byte type, ulong nid)
        {
            FileName = name;
            FileType = type;
            Nid = nid;
        }
    }
}
