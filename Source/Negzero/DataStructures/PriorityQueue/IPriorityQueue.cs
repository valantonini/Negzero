namespace Negzero.DataStructures.PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        void Push(T item);
        T PopMin();
        T Peek();

        void Clear();
        int Count { get; }
    }
}