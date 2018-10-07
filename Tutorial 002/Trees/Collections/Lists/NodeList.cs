using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Trees.Collections.Lists
{
    public class NodeList<TValue> :
        NodeCollection
        <
            INodeList<TValue>,
            TValue
        >,
        INodeList<TValue>
    {
        protected List<INodeList<TValue>> m_Children { get; } = new List<INodeList<TValue>>();

        public override IReadOnlyCollection<INodeList<TValue>> ChildrenCollection => ChildrenList;

        public virtual IReadOnlyList<INodeList<TValue>> ChildrenList => m_Children;

        public NodeList(TValue value) : base(value) { }

        public override void AddDirect(INodeList<TValue> node) => m_Children.Add(node);

        public override bool RemoveDirect(INodeList<TValue> node) => m_Children.Remove(node);
    }
}
