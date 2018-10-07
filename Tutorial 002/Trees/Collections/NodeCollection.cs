using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Trees.Collections
{
    public abstract class NodeCollection<TNodeCollection, TValue> :
        Node<TNodeCollection, TValue>,
        INodeCollection<TNodeCollection, TValue>
        where TNodeCollection : class, INodeCollection<TNodeCollection, TValue>
    {
        public override IEnumerable<TNodeCollection> Children => ChildrenCollection;

        public abstract IReadOnlyCollection<TNodeCollection> ChildrenCollection { get; }

        protected NodeCollection(TValue value) :
            base(value)
        {
        }

        public abstract void AddDirect(TNodeCollection node);

        public abstract bool RemoveDirect(TNodeCollection node);
    }
}
