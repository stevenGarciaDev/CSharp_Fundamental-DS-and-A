namespace csharp.Section1.ArrayList
{
    public interface IGenericList<T>
    {
        void Add(T item);
        bool Contains(T item);
        int IndexOf(T item);
        void Insert(int index, T item);
        bool Remove(T item);
    }
}