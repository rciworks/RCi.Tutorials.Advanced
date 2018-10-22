using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Trees.Collections.Dictionaries
{
    public class NodeDictionary<TValue, TKey> :
        NodeCollection
        <
            INodeDictionary<TValue, TKey>,
            TValue
        >,
        INodeDictionary<TValue, TKey>
    {
        protected Dictionary<TKey, INodeDictionary<TValue, TKey>> m_Children { get; } = new Dictionary<TKey, INodeDictionary<TValue, TKey>>();

        public override IReadOnlyCollection<INodeDictionary<TValue, TKey>> ChildrenCollection => m_Children.Values;

        public virtual TKey Key { get; }

        public virtual IReadOnlyDictionary<TKey, INodeDictionary<TValue, TKey>> ChildrenDictionary => m_Children;

        public NodeDictionary(TKey key, TValue value) : base(value) => Key = key;

        public override void AddDirect(INodeDictionary<TValue, TKey> node) => m_Children.Add(node.Key, node);

        public override bool RemoveDirect(INodeDictionary<TValue, TKey> node) => m_Children.Remove(node.Key);
    }
}
