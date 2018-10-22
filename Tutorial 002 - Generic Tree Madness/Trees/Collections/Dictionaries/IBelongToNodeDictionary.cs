namespace RCi.Tutorials.Advanced.Trees.Collections.Dictionaries
{
    public interface IBelongToNodeDictionary<out TNodeDictionary, TValue, TKey> :
        IBelongToNodeCollection<TNodeDictionary, TValue>
        where TNodeDictionary :
            class,
            INodeCollection<TNodeDictionary, TValue>,
            INodeDictionary<TValue, TKey>
    {
    }
}
