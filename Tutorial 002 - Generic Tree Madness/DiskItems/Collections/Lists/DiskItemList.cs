using System.IO;
using RCi.Tutorials.Advanced.Trees.Collections.Lists;

namespace RCi.Tutorials.Advanced.DiskItems.Collections.Lists
{
    public class DiskItemList :
        DiskItemCollection
        <
            INodeList<IDiskItemList>,
            IDiskItemList
        >,
        IDiskItemList
    {
        public DiskItemList(FileSystemInfo fileSystemInfo) :
            base(fileSystemInfo) =>
            Node = new NodeList<IDiskItemList>(this);
    }
}
