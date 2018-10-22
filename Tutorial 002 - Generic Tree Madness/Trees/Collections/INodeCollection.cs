using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Trees.Collections
{
    public interface INodeCollection<TNodeCollection, TValue> :
        INode<TNodeCollection, TValue>
        where TNodeCollection : class, INodeCollection<TNodeCollection, TValue>
    {
        IReadOnlyCollection<TNodeCollection> ChildrenCollection { get; }

        void AddDirect(TNodeCollection node);

        bool RemoveDirect(TNodeCollection node);
    }
}
