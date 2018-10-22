using System;
using System.IO;
using System.Linq;
using RCi.Tutorials.Advanced.DiskItems;
using RCi.Tutorials.Advanced.DiskItems.Collections.Dictionaries;
using RCi.Tutorials.Advanced.DiskItems.Collections.Lists;
using RCi.Tutorials.Advanced.Trees;
using RCi.Tutorials.Advanced.Trees.Collections;
using RCi.Tutorials.Advanced.Trees.Collections.Dictionaries;
using RCi.Tutorials.Advanced.Trees.Collections.Lists;

namespace RCi.Tutorials.Advanced
{
    internal static class Program
    {
        private static void Main()
        {
            // ReSharper disable PossibleNullReferenceException
            var rootDirectoryInfo = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.Parent;
            // ReSharper restore PossibleNullReferenceException

            var rootList = BuildTree<INodeList<IDiskItemList>, IDiskItemList>(di => new DiskItemList(di), rootDirectoryInfo);
            var rootDictionary = BuildTree<INodeDictionary<IDiskItemDictionary, string>, IDiskItemDictionary>(di => new DiskItemDictionary(di), rootDirectoryInfo);

            Print<INodeList<IDiskItemList>, IDiskItemList>(rootList.Node);
            Print<INodeDictionary<IDiskItemDictionary, string>, IDiskItemDictionary>(rootDictionary.Node);

            Console.Read();
        }

        public static TDiskItem BuildTree<TNodeCollection, TDiskItem>(Func<FileSystemInfo, TDiskItem> ctor, FileSystemInfo rootDiskItem)
            where TDiskItem : IDiskItem, IBelongToNodeCollection<TNodeCollection, TDiskItem>
            where TNodeCollection : class, INodeCollection<TNodeCollection, TDiskItem>
        {
            void Traverse(TDiskItem parent)
            {
                foreach (var childDiskItem in parent.GetDirectories().Cast<FileSystemInfo>().Concat(parent.GetFiles()))
                {
                    var child = ctor(childDiskItem);
                    parent.Node.Add<TNodeCollection, TDiskItem>(child.Node);
                    Traverse(child);
                }
            }

            var root = ctor(rootDiskItem);
            Traverse(root);
            return root;
        }

        public static void Print<TNode, TDiskItem>(TNode node)
            where TNode : class, INode<TNode, TDiskItem>
            where TDiskItem : IDiskItem
        {
            foreach (var child in node.GetDescendantsAndSelf())
            {
                Console.Write(string.Join(string.Empty, Enumerable.Repeat("   ", child.GetAncestors().Count())));
                Console.WriteLine(child.Value.Name);
            }
        }
    }
}
