using System.IO;

namespace RCi.Tutorials.Advanced.DiskItems
{
    public class DiskItem :
        IDiskItem
    {
        private FileSystemInfo FileSystemInfo { get; }

        public string Name => FileSystemInfo.Name;

        public DirectoryInfo[] GetDirectories() => FileSystemInfo is DirectoryInfo directoryInfo ? directoryInfo.GetDirectories() : new DirectoryInfo[0];

        public FileInfo[] GetFiles() => FileSystemInfo is DirectoryInfo directoryInfo ? directoryInfo.GetFiles() : new FileInfo[0];

        public override string ToString() => Name;

        protected DiskItem(FileSystemInfo fileSystemInfo) => FileSystemInfo = fileSystemInfo;
    }
}
