namespace RCi.Tutorials.Advanced.Boxed
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
            UsageGeneric();
        }

        public static void UsageNumeric()
        {
            var nodes = new NodeNumeric[5];

            nodes[0] = new NodeNumeric(0);
            nodes[0].Add(nodes[1] = new NodeNumeric(1));
            nodes[0].Add(nodes[2] = new NodeNumeric(2));
            nodes[2].Add(nodes[3] = new NodeNumeric(3));
            nodes[2].Add(nodes[4] = new NodeNumeric(4));

            nodes[0].Add(new NodeText("IMPOSTER!"));
        }

        public static void UsageText()
        {
            var nodes = new NodeText[5];

            nodes[0] = new NodeText("0");
            nodes[0].Add(nodes[1] = new NodeText("1"));
            nodes[0].Add(nodes[2] = new NodeText("2"));
            nodes[2].Add(nodes[3] = new NodeText("3"));
            nodes[2].Add(nodes[4] = new NodeText("4"));

            nodes[0].Add(new NodeNumeric(666));
        }

        public static void UsageGeneric()
        {
            var nodes = new INode[5];

            nodes[0] = new Node(0);
            nodes[0].Add(nodes[1] = new NodeNumeric(1));
            nodes[0].Add(nodes[2] = new NodeText("2"));
            nodes[2].Add(nodes[3] = new Node<int>(3));
            nodes[2].Add(nodes[4] = new Node<string>("4"));
        }
    }
}
