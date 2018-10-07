using RCi.Tutorials.Advanced.Trees.Collections.Lists;

namespace RCi.Tutorials.Advanced.DiskItems.Collections.Lists
{
    public interface IDiskItemList :
        IDiskItemCollection
        <
            INodeList<IDiskItemList>,
            IDiskItemList
        >,
        IBelongToNodeList
        <
            INodeList<IDiskItemList>,
            IDiskItemList
        >
    {
    }
}
