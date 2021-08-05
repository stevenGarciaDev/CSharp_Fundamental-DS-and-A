using System;

namespace csharp.Section2.AVLTree
{
    public class AVLNode<T> where T : IComparable
    {
        public T Value { get; set; }
        public AVLNode<T> LeftChild { get; set; }
        public AVLNode<T> RightChild { get; set; }
        public int Height { get; set; }

        public AVLNode(T value)
        {
            this.Value = value;
        }

        public AVLNode()
        {

        }
    }
}