namespace Negzero.DataStructures.PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        int Queue(T item);
        T Dequeue();
        T Peek();

        void Clear();
        int Count { get; }
    }
}