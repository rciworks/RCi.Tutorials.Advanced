using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Trees
{
    public abstract class Node<TNode, TValue> :
        INode<TNode, TValue>
        where TNode : class, INode<TNode, TValue>
    {
        public TNode Parent { get; set; }

        public abstract IEnumerable<TNode> Children { get; }

        public TValue Value { get; set; }

        protected Node(TValue value) => Value = value;

        public override string ToString() => $"{Value}";
    }
}
