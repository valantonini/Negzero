using System.Collections.Generic;
using System.Linq;

namespace Negzero.DataStructures.PriorityQueue
{
    public class Node<T>
    {
        public T Value { get; set; }

        private int _height = 0;
        public int Height
        {
            get => _height; 

            private set 
            {
                _height = value;
                if (_parent != null)
                {
                    _parent.ChildHeightUpdated();
                }
            }
        }
        public Node() : this(default(T)) { }
        public Node(T value)
        {
            Value = value;
        }
        private Node<T> _parent = null;
        public Node<T> Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        private IList<Node<T>> _children = new List<Node<T>>();

        public void AddChild(Node<T> child)
        {
            child.Parent = this;
            _children.Add(child);
            RecalculateHeight();
        }

        public void RemoveChild(Node<T> child)
        {
            _children.Remove(child);
            RecalculateHeight();
            child.Parent = null;
        }

        private void RecalculateHeight()
        {
            var newHeight = _children.Count == 0 ? 0 : _children.Max(child => child.Height) + 1;
            if (Height != newHeight)
            {
                Height = newHeight;
            }
        }

        public void ChildHeightUpdated()
        {
            RecalculateHeight();
        }
    }
}