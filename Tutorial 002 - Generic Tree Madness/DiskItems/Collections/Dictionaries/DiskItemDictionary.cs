using System.IO;
using RCi.Tutorials.Advanced.Trees.Collections.Dictionaries;

namespace RCi.Tutorials.Advanced.DiskItems.Collections.Dictionaries
{
    public class DiskItemDictionary :
        DiskItemCollection
        <
            INodeDictionary<IDiskItemDictionary, string>,
            IDiskItemDictionary
        >,
        IDiskItemDictionary
    {
        public DiskItemDictionary(FileSystemInfo fileSystemInfo) :
            base(fileSystemInfo) =>
            Node = new NodeDictionary<IDiskItemDictionary, string>(Name, this);
    }
}
