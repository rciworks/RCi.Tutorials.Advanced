using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Generic
{
    public interface INode<TValue>
    {
        TValue Value { get; set; }

        INode<TValue> Parent { get; set; }

        IReadOnlyCollection<INode<TValue>> Children { get; }

        bool IsRoot();

        bool IsLeaf();

        void Add(INode<TValue> node);

        bool Remove(INode<TValue> node);

        IEnumerable<INode<TValue>> GetAncestors();

        IEnumerable<INode<TValue>> GetAncestorsAndSelf();

        IEnumerable<INode<TValue>> GetDescendants();

        IEnumerable<INode<TValue>> GetDescendantsAndSelf();
    }
}
