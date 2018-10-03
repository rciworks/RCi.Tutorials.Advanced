namespace RCi.Tutorials.Advanced.Boxed
{
    public class NodeNumeric :
        Node
    {
        public int ValueUnboxed => (int)Value;

        public NodeNumeric(int value) :
            base(value)
        {
        }
    }
}
