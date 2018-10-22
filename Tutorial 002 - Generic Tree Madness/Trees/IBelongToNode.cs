namespace RCi.Tutorials.Advanced.Trees
{
    public interface IBelongToNode<out TNode>
        where TNode : class, INode<TNode>
    {
        TNode Node { get; }
    }

    public interface IBelongToNode<out TNode, TValue> :
        IBelongToNode<TNode>
        where TNode : class, INode<TNode, TValue>
    {
    }
}
