using RCi.Tutorials.Advanced.Trees.Collections.Dictionaries;

namespace RCi.Tutorials.Advanced.DiskItems.Collections.Dictionaries
{
    public interface IDiskItemDictionary :
        IDiskItemCollection
        <
            INodeDictionary<IDiskItemDictionary, string>,
            IDiskItemDictionary
        >,
        IBelongToNodeDictionary
        <
            INodeDictionary<IDiskItemDictionary, string>,
            IDiskItemDictionary,
            string
        >
    {
    }
}
