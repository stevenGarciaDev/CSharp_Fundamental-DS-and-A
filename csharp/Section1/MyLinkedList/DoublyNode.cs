using System;

namespace csharp.Section1.MyLinkedList
{
    public class DoublyNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }

        public DoublyNode(T value = default(T))
        {
            Value = value;
            Previous = null;
            Next = null;
        }
    }
}