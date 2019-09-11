namespace Negzero.DataStructures.PriorityQueue
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node(): this(default(T)) {}
        public Node(T value)
        {
            Value = value;
        }
    }
}