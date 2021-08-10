namespace csharp.Section1.MyLinkedList
{
    public interface IGenericList<T>
    {
        void AddFirst(T item);
        void AddLast(T item);
        int IndexOf(T item);
        T RemoveFirst();
        T RemoveLast();
        int Count();
        void Reverse();
        T KthFromEnd(int k);
    }
}