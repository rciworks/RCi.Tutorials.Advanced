using System;
using System.IO;
using System.Linq;

namespace RCi.Tutorials.Advanced.Generic
{
    public static class Test
    {
        public static void Usage()
        {
            /*
                   node0
                   /   \ 
                  /     \
                node1  node2
                       /   \
                      /     \
                   node3   node4
            */

            UsageNumeric();
            UsageText();
            UsageFolder();
        }

        public static void UsageNumeric()
        {
            var nodes = new Node<int>[5];

            nodes[0] = new Node<int>(0);
            nodes[0].Add(nodes[1] = new Node<int>(1));
            nodes[0].Add(nodes[2] = new Node<int>(2));
            nodes[2].Add(nodes[3] = new Node<int>(3));
            nodes[2].Add(nodes[4] = new Node<int>(4));
        }

        public static void UsageText()
        {
            var nodes = new Node<string>[5];

            nodes[0] = new Node<string>("0");
            nodes[0].Add(nodes[1] = new Node<string>("1"));
            nodes[0].Add(nodes[2] = new Node<string>("2"));
            nodes[2].Add(nodes[3] = new Node<string>("3"));
            nodes[2].Add(nodes[4] = new Node<string>("4"));
        }

        public static void UsageFolder()
        {
            // ReSharper disable PossibleNullReferenceException
            var rootDirectoryInfo = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.Parent;
            // ReSharper restore PossibleNullReferenceException

            var root = Folder.BuildTree(rootDirectoryInfo);

            foreach (var folder in root.GetDescendantsAndSelf())
            {
                Console.Write(string.Join(string.Empty, Enumerable.Repeat("   ", folder.GetAncestors().Count())));
                Console.WriteLine(folder.Value.Name);
            }
        }
    }
}
