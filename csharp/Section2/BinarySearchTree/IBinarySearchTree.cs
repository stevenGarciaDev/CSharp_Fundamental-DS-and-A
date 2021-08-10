using System;
using System.Collections.Generic;

namespace csharp.Section2.BinarySearchTree
{
    public interface IBinarySearchTree<T> where T : IComparable<T>
    {
        void Insert(T value);
        bool Find(T value);
        bool FindIterative(T value);
        void PreOrderTraversal();
        void InOrderTraversal();
        void PostOrderTraversal();
        void DepthFirstSearch();
        void BreadthFirstSearch();
        void DepthFirstSearchIterative();
        int CountLeaves();
        int Size();
        bool AreSiblings(T value1, T value2);
        List<T> GetAncestors(T value);
    }
}