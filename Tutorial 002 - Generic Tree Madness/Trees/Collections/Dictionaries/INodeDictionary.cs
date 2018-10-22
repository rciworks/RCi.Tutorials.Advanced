using System.Collections.Generic;

namespace RCi.Tutorials.Advanced.Trees.Collections.Dictionaries
{
    public interface INodeDictionary<TValue, TKey> :
        INodeCollection
        <
            INodeDictionary<TValue, TKey>,
            TValue
        >
    {
        TKey Key { get; }

        IReadOnlyDictionary<TKey, INodeDictionary<TValue, TKey>> ChildrenDictionary { get; }
    }
}
