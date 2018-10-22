using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Trees.Collections.Lists
{
    public interface INodeList<TValue> :
        INodeCollection
        <
            INodeList<TValue>,
            TValue
        >
    {
        IReadOnlyList<INodeList<TValue>> ChildrenList { get; }
    }
}
