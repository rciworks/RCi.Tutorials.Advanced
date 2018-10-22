using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Trees
{
    public interface INode<TNode>
        where TNode : class, INode<TNode>
    {
        TNode Parent { get; set; }

        IEnumerable<TNode> Children { get; }
    }

    public interface INode<TNode, TValue> :
        INode<TNode>
        where TNode : class, INode<TNode, TValue>
    {
        TValue Value { get; set; }
    }
}
