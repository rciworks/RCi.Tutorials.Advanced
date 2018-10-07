using System.Collections.Generic;
using System.Linq;

namespace RCi.Tutorials.Advanced.Trees
{
    public static class INodeExtensions
    {
        public static bool IsRoot<TNode>(this TNode node)
            where TNode : class, INode<TNode>
        {
            return node.Parent is null;
        }

        public static bool IsLeaf<TNode>(this TNode node)
            where TNode : class, INode<TNode>
        {
            return !node.Children.Any();
        }

        public static IEnumerable<TNode> GetAncestors<TNode>(this TNode node)
            where TNode : class, INode<TNode>
        {
            while (!node.IsRoot())
            {
                node = node.Parent;
                yield return node;
            }
        }

        public static IEnumerable<TNode> GetAncestorsAndSelf<TNode>(this TNode node)
            where TNode : class, INode<TNode>
        {
            return node.Concat(node.GetAncestors());
        }

        public static IEnumerable<TNode> GetDescendants<TNode>(this TNode node)
            where TNode : class, INode<TNode>
        {
            return node.Children.SelectMany(child => child.GetDescendantsAndSelf());
        }

        public static IEnumerable<TNode> GetDescendantsAndSelf<TNode>(this TNode node)
            where TNode : class, INode<TNode>
        {
            return node.Concat(node.GetDescendants());
        }
    }
}
