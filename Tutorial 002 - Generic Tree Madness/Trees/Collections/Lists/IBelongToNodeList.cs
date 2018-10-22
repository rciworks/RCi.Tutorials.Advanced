namespace RCi.Tutorials.Advanced.Trees.Collections.Lists
{
    public interface IBelongToNodeList<out TNodeList, TValue> :
        IBelongToNodeCollection<TNodeList, TValue>
        where TNodeList :
            class,
            INodeCollection<TNodeList, TValue>,
            INodeList<TValue>
    {
    }
}
