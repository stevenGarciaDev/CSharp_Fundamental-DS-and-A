using System;

namespace csharp.Section2.AVLTree
{
    public interface IAVLTree<T> where T : IComparable
    {
        void Insert(T value);
        int HeightOfTree();
        AVLNode<T> Find(T value);
    }
}