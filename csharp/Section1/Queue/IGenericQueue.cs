namespace csharp.Section1.Queue
{
    public interface IGenericQueue<T>
    {
        void Clear();
        T Dequeue();
        T Peek();
        void Enqueue(T item);
        int Count();
    }
}