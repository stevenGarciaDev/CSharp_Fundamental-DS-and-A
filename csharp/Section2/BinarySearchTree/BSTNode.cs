using System;

namespace csharp.Section2.BinarySearchTree
{
    public class BSTNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public BSTNode<T> LeftChild { get; set; }
        public BSTNode<T> RightChild { get; set; }

        public BSTNode(T value = default(T))
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
        }

        public bool HasLeftChild() => LeftChild != null;
        public bool HasRightChild() => RightChild != null;
    }
}