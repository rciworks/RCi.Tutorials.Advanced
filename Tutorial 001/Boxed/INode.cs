using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Boxed
{
    public interface INode
    {
        object Value { get; }

        INode Parent { get; set; }

        IReadOnlyCollection<INode> Children { get; }

        void Add(INode node);

        bool Remove(INode node);
    }
}
