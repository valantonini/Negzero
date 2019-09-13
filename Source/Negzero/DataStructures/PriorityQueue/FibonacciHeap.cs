using System.Linq;
using System.Collections.Generic;

namespace Negzero.DataStructures.PriorityQueue
{
    public class FibonacciHeap<T> : IPriorityQueue<T>
    {
        private readonly IComparer<T> _comparer;
        private Node<T> _min = null;
        private List<Node<T>> _roots = new List<Node<T>>();

        public int Count { get; private set; }

        public FibonacciHeap() : this(Comparer<T>.Default) { }

        public FibonacciHeap(IComparer<T> comparer)
        {
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public void Clear()
        {
            _min = null;
            _roots.Clear();
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

            var oldMin = _min;
            _roots.Remove(oldMin);
            _roots.AddRange(oldMin.DetachChildren());

            Count--;

            var ( newRoots, newMin ) = MergeRootNodes(_roots, _comparer);

            _roots = newRoots;
            _min = newMin;
            

            return oldMin.Value;
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

        public static (List<Node<T>> roots, Node<T> min) MergeRootNodes(List<Node<T>> rootNodes, IComparer<T> comparer)
        {
            var heightMap = new Dictionary<int, Node<T>>();
            Node<T> min = null;
            for (var i = 0; i < rootNodes.Count; i++)
            {
                Node<T> next = rootNodes[i];
                if(min == null || comparer.Compare(next.Value, min.Value) < 0)
                {
                    min = next;
                }
                
                while(next != null) 
                {
                    var height = next.Height;
                    if(!heightMap.ContainsKey(height))
                    {
                        heightMap[next.Height] = next;
                        next = null;
                    }
                    else
                    {
                        var nodeToMergeWith = heightMap[height];
                        heightMap.Remove(height);

                        var nodes = comparer.Compare(next.Value, nodeToMergeWith.Value) < 0 
                                        ? (smaller: next, larger: nodeToMergeWith)
                                        : (smaller: nodeToMergeWith, larger: next);

                        nodes.larger.DetachFromParent();
                        nodes.smaller.AddChild(nodes.larger);
                        next = nodes.smaller;
                    }

                }
            }
            return ( roots: heightMap.Values.ToList(), min: min );
        }
    }
}