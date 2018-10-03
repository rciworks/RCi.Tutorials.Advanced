using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Boxed
{
    public class Node :
        INode
    {
        private readonly List<INode> m_Children = new List<INode>();

        public object Value { get; }

        public INode Parent { get; set; }

        public IReadOnlyCollection<INode> Children => m_Children;

        public Node(object value) => Value = value;

        public override string ToString() => $"{Value}";

        public void Add(INode node)
        {
            node.Parent?.Remove(node);
            node.Parent = this;
            m_Children.Add(node);
        }

        public bool Remove(INode node)
        {
            node.Parent = default;
            return m_Children.Remove(node);
        }
    }
}
