using System.Collections.Generic;
using System.Linq;

namespace RCi.Tutorials.Advanced.Generic
{
    public class Node<TValue> :
        INode<TValue>
    {
        private readonly List<INode<TValue>> m_Children = new List<INode<TValue>>();

        public TValue Value { get; set; }

        public INode<TValue> Parent { get; set; }

        public IReadOnlyCollection<INode<TValue>> Children => m_Children;

        public Node(TValue value) => Value = value;

        public override string ToString() => $"{Value}";

        public bool IsRoot() => Parent is null;

        public bool IsLeaf() => !Children.Any();

        public void Add(INode<TValue> node)
        {
            node.Parent?.Remove(node);
            node.Parent = this;
            m_Children.Add(node);
        }

        public bool Remove(INode<TValue> node)
        {
            node.Parent = default;
            return m_Children.Remove(node);
        }

        public IEnumerable<INode<TValue>> GetAncestors()
        {
            var node = (INode<TValue>)this;
            while (!node.IsRoot())
            {
                node = node.Parent;
                yield return node;
            }
        }

        public IEnumerable<INode<TValue>> GetAncestorsAndSelf() => this.Concat(GetAncestors());

        public IEnumerable<INode<TValue>> GetDescendants() => Children.SelectMany(child => child.GetDescendantsAndSelf());

        public IEnumerable<INode<TValue>> GetDescendantsAndSelf() => this.Concat(GetDescendants());
    }
}
