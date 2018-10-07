namespace RCi.Tutorials.Advanced.Trees.Collections
{
    public static class INodeCollectionExtensions
    {
        public static void Add<TNodeCollection, TValue>(this TNodeCollection parent, TNodeCollection child)
            where TNodeCollection : class, INodeCollection<TNodeCollection, TValue>
        {
            child.Parent?.Remove<TNodeCollection, TValue>(child);
            child.Parent = parent;
            parent.AddDirect(child);
        }

        public static bool Remove<TNodeCollection, TValue>(this TNodeCollection parent, TNodeCollection child)
            where TNodeCollection : class, INodeCollection<TNodeCollection, TValue>
        {
            child.Parent = default;
            return parent.RemoveDirect(child);
        }
    }
}
