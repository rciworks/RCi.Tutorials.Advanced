namespace RCi.Tutorials.Advanced.DiskItems
{
    public interface IDiskItem
    {
        string Name { get; }

        System.IO.DirectoryInfo[] GetDirectories();

        System.IO.FileInfo[] GetFiles();
    }
}
