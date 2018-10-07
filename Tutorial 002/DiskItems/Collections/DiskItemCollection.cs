using System.IO;
using RCi.Tutorials.Advanced.Trees.Collections;

namespace RCi.Tutorials.Advanced.DiskItems.Collections
{
    public abstract class DiskItemCollection<TNodeCollection, TDiskItemCollection> :
        DiskItem,
        IDiskItemCollection<TNodeCollection, TDiskItemCollection>
        where TNodeCollection : class, INodeCollection<TNodeCollection, TDiskItemCollection>
        where TDiskItemCollection : IDiskItemCollection<TNodeCollection, TDiskItemCollection>
    {
        public TNodeCollection Node { get; protected set; }

        protected DiskItemCollection(FileSystemInfo fileSystemInfo) :
            base(fileSystemInfo)
        {
        }
    }
}
