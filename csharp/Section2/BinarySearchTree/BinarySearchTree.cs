using System;
using System.Collections.Generic;

namespace csharp.Section2.BinarySearchTree
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private BSTNode<T> _root;

        public BinarySearchTree()
        {
            _root = null;
        }

        // Since BST have no cycles, no need to have a visisted Set.
        public void BreadthFirstSearch()
        {
            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();

            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                BSTNode<T> frontOfQueue = queue.Dequeue();
                Console.WriteLine(frontOfQueue.Value);

                if (frontOfQueue.HasLeftChild())
                    queue.Enqueue(frontOfQueue.LeftChild);

                if (frontOfQueue.HasRightChild())
                    queue.Enqueue(frontOfQueue.RightChild);

            }
        }

        public void DepthFirstSearch()
        {
            DepthFirstSearch(_root);
        }

        // Initialize a Stack. No need for a visisted Set as the data structure 
        // is a BST and has no cycles.
        public void DepthFirstSearchIterative()
        {
            if (_root == null) return;
            Stack<BSTNode<T>> stack = new Stack<BSTNode<T>>();
            stack.Push(_root);

            while (stack.Count > 0)
            {
                BSTNode<T> topOfStack = stack.Pop();
                Console.WriteLine(topOfStack.Value);

                if (topOfStack.HasLeftChild())
                    stack.Push(topOfStack.LeftChild);

                if (topOfStack.HasRightChild())
                    stack.Push(topOfStack.RightChild);
            }
        }

        public bool Find(T value)
        {
            return Find(_root, value);
        }

        public bool FindIterative(T value)
        {
            BSTNode<T> current = _root;

            while (current != null)
            {
                int comparisonResult = value.CompareTo(current.Value);

                if (comparisonResult == 0)
                    return true;
                else if (comparisonResult == -1)
                    current = current.LeftChild;
                else
                    current = current.RightChild;
            }

            return false;
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(_root);
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(_root);
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(_root);
        }

        public void Insert(T value)
        {
            _root = Insert(_root, value);
        }

        public int CountLeaves()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public bool AreSiblings(T value1, T value2)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAncestors(T value)
        {
            throw new NotImplementedException();
        }

        private BSTNode<T> Insert(BSTNode<T> node, T value)
        {
            if (node == null)
                return new BSTNode<T>(value);

            if (value.CompareTo(node.Value) == -1)
                node.LeftChild = Insert(node.LeftChild, value);
            else
                node.RightChild = Insert(node.RightChild, value);

            return node;
        }

        private void DepthFirstSearch(BSTNode<T> node)
        {
            if (node == null) return;
            Console.WriteLine(node.Value);

            if (node.HasLeftChild())
                DepthFirstSearch(node.LeftChild);

            if (node.HasRightChild())
                DepthFirstSearch(node.RightChild);
        }

        private bool Find(BSTNode<T> node, T value)
        {
            if (node == null) return false;
            int comparisonResult = value.CompareTo(node.Value);

            if (comparisonResult == 0)
                return true;
            else if (comparisonResult == -1)
                return Find(node.LeftChild, value);
            else
                return Find(node.RightChild, value);
        }

        private void PreOrderTraversal(BSTNode<T> node)
        {
            if (node == null) return;
            Console.WriteLine(node.Value);
            PreOrderTraversal(node.LeftChild);
            PreOrderTraversal(node.RightChild);
        }

        private void InOrderTraversal(BSTNode<T> node)
        {
            if (node == null) return;
            InOrderTraversal(node.LeftChild);
            Console.WriteLine(node.Value);
            InOrderTraversal(node.RightChild);
        }

        private void PostOrderTraversal(BSTNode<T> node)
        {
            if (node == null) return;
            PostOrderTraversal(node.LeftChild);
            PostOrderTraversal(node.RightChild);
            Console.WriteLine(node.Value);
        }
    }
}