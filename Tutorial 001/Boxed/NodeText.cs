namespace RCi.Tutorials.Advanced.Boxed
{
    public class NodeText :
        Node
    {
        public string ValueUnboxed => (string)Value;

        public NodeText(string value) :
            base(value)
        {
        }
    }
}
