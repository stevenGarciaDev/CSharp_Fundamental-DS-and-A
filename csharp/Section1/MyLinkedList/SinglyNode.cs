using System;

namespace csharp.Section1.MyLinkedList
{
    public class SinglyNode<T> where T : IComparable
    {
        public T Value { get; set; }
        public SinglyNode<T> Next { get; set; }

        public SinglyNode(T value = default(T))
        {
            Value = value;
            Next = null;
        }
    }
}