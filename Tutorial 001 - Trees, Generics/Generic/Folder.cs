using System.IO;

namespace RCi.Tutorials.Advanced.Generic
{
    public class Folder :
        Node<DirectoryInfo>,
        IFolder
    {
        public Folder(DirectoryInfo value) :
            base(value)
        {
        }

        public static IFolder BuildTree(DirectoryInfo directoryInfo)
        {
            void Traverse(IFolder parent)
            {
                foreach (var childDirectoryInfo in parent.Value.GetDirectories())
                {
                    var child = new Folder(childDirectoryInfo);
                    parent.Add(child);
                    Traverse(child);
                }
            }

            var root = new Folder(directoryInfo);
            Traverse(root);
            return root;
        }
    }
}
