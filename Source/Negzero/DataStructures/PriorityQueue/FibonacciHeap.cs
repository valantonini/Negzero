using System.Collections.Generic;

namespace Negzero.DataStructures.PriorityQueue
{
    public class FibonacciHeap<T> : IPriorityQueue<T>
    {
        private readonly IComparer<T> _comparer;
        private Node<T> _min = null;
        private IList<Node<T>> _roots = new List<Node<T>>();
        public int Count { get; private set; }

        public FibonacciHeap() : this(Comparer<T>.Default) { }

        public FibonacciHeap(IComparer<T> comparer)
        {
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public void Clear()
        {
            _min = null;
            _roots = new List<Node<T>>();
            Count = 0;
        }

        public T Peek()
        {
            if (_min == null)
            {
                throw new System.NullReferenceException("No values in heap");
            }

            return _min.Value;
        }

        public T PopMin()
        {
            if (_min == null) 
            {
                throw new System.NullReferenceException("No values in heap");
            }

            Node<T> newMin = null;
            foreach(var newMinCandidate in _roots) 
            {
                if(_min == newMinCandidate) 
                {
                    continue;
                }

                if(newMin == null || _comparer.Compare(newMinCandidate.Value, newMin.Value) < 0){
                    newMin = newMinCandidate;
                }
            }

            var returnValue = _min.Value;
            _min = newMin;
            Count--;
            return returnValue;
        }

        public void Push(T item)
        {
            var node = new Node<T>(item);
            _roots.Add(node);
            if (_min == null || _comparer.Compare(node.Value, _min.Value) < 0)
            {
                _min = node;
            }
            Count++;
        }
    }
}