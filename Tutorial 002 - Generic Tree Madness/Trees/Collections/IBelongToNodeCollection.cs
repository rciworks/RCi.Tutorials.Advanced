namespace RCi.Tutorials.Advanced.Trees.Collections
{
    public interface IBelongToNodeCollection<out TNodeCollection, TValue> :
        IBelongToNode<TNodeCollection, TValue>
        where TNodeCollection : class, INodeCollection<TNodeCollection, TValue>
    {
    }
}
