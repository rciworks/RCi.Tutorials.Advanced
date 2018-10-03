namespace RCi.Tutorials.Advanced.Boxed
{
    public class Node<TValue> :
        Node
    {
        public TValue ValueUnboxed => (TValue)Value;

        public Node(TValue value) :
            base(value)
        {
        }
    }
}
