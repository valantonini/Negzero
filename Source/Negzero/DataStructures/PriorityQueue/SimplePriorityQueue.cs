using System.Collections.Generic;

namespace Negzero.DataStructures.PriorityQueue
{
    public class SimplePriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly IComparer<T> _comparer;

        public int Count => throw new System.NotImplementedException();

        public SimplePriorityQueue() : this(Comparer<T>.Default) { }

        public SimplePriorityQueue(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public T Dequeue()
        {
            throw new System.NotImplementedException();
        }

        public T Peek()
        {
            throw new System.NotImplementedException();
        }

        public int Queue(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}