namespace csharp.Section1.Stack
{
    public interface IGenericStack<T>
    {
        bool IsEmpty();
        int Count();
        T Peek();
        T Pop();
        void Clear();
        void Push(T value);

    }
}