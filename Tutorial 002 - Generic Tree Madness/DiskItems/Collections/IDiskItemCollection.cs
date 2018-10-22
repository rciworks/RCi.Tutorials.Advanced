using RCi.Tutorials.Advanced.Trees.Collections;

namespace RCi.Tutorials.Advanced.DiskItems.Collections
{
    public interface IDiskItemCollection<out TNodeCollection, TDiskItemCollection> :
        IDiskItem,
        IBelongToNodeCollection
        <
            TNodeCollection,
            TDiskItemCollection
        >
        where TNodeCollection : class, INodeCollection<TNodeCollection, TDiskItemCollection>
        where TDiskItemCollection : IDiskItemCollection<TNodeCollection, TDiskItemCollection>
    {
    }
}
