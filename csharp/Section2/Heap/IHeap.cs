using System;

namespace csharp.Section2.Heap
{
    public interface IHeap<T> where T : IComparable<T>
    {
        void Insert(T value);
        T Remove();
        T Get();
    }
}