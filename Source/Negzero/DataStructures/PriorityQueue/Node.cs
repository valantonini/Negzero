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
            if (child.Height + 1 > Height) {
                Height = child.Height + 1;
            }
        }

        public void RemoveChild(Node<T> child)
        {
            _children.Remove(child);
            RecalculateHeight();
            child.Parent = null;
        }

        public void DetachFromParent()
        {
            if (_parent == null) 
            {
                return;
            }

            this._parent.RemoveChild(this);
        }

        public List<Node<T>> DetachChildren()
        {
            var children = new List<Node<T>>();

            foreach(var child in _children) {
                child.Parent = null;
                children.Add(child);
            }

            _children.Clear();

            Height = 0;

            return children;
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