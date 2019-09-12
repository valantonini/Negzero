using System.Collections.Generic;

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
        private IList<Node<T>> _children = new List<Node<T>>();
        private Node<T> _parent = null;
    }
}