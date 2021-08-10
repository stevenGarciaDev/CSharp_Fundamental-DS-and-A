using System;
using System.Text;

namespace csharp.Section2.AVLTree
{
    public class AVLTree<T> : IAVLTree<T> where T : IComparable
    {
        public AVLNode<T> Root { get; set; }

        public override string ToString()
        {
            return "";
        }

        public string InOrderTraversal()
        {
            StringBuilder stringBuilder = new StringBuilder();
            return InOrderTraversal(Root, stringBuilder);
        }

        public string InOrderTraversal(AVLNode<T> node, StringBuilder stringBuilder)
        {
            return "";
        }

        public AVLNode<T> Find(T value)
        {
            return null;
        }

        public void Insert(T value)
        {
            Root = Insert(Root, value);
        }

        public int HeightOfTree()
        {
            if (Root == null) return 0;

            return Math.Max(Height(Root.LeftChild), Height(Root.RightChild)) + 1;
        }

        private AVLNode<T> Find(AVLNode<T> node, T value)
        {
            if (node == null) return null;

            if (node.Value.Equals(value))
                return node;

            if (value.CompareTo(node.Value) == -1)
                return Find(node.LeftChild, value);

            return Find(node.RightChild, value);
        }

        private AVLNode<T> Insert(AVLNode<T> node, T value)
        {
            if (node == null)
                return new AVLNode<T>(value);

            if (value.CompareTo(node.Value) == -1)
            {
                node.LeftChild = Insert(node.LeftChild, value);
            }
            else
            {
                node.RightChild = Insert(node.RightChild, value);
            }

            SetHeight(node);

            return Balance(node);
        }

        private void SetHeight(AVLNode<T> node)
        {
            node.Height = Math.Max(
                Height(node.LeftChild),
                Height(node.RightChild)
            ) + 1;
        }

        private int Height(AVLNode<T> node)
        {
            return (node == null) ? 0 : node.Height;
        }

        private AVLNode<T> Balance(AVLNode<T> node)
        {
            if (IsLeftHeavy(node))
            {
                if (BalanceFactor(node.LeftChild) < 0)
                    RotateLeft(node.LeftChild);
                RotateRight(node);
            }
            else if (IsRightHeavy(node))
            {
                if (BalanceFactor(node.RightChild) > 0)
                    RotateRight(node.RightChild);
                RotateLeft(node);
            }

            return node;
        }

        private AVLNode<T> RotateRight(AVLNode<T> node)
        {
            AVLNode<T> newRoot = node.LeftChild;

            node.LeftChild = newRoot.RightChild;

            newRoot.RightChild = node;

            SetHeight(node);
            SetHeight(newRoot);

            return newRoot;
        }

        private AVLNode<T> RotateLeft(AVLNode<T> node)
        {
            AVLNode<T> newRoot = node.RightChild;

            node.RightChild = newRoot.LeftChild;

            newRoot.LeftChild = node;

            SetHeight(node);
            SetHeight(newRoot);

            return newRoot;
        }

        /*

        
        */
        private int BalanceFactor(AVLNode<T> node)
        {
            return (node == null) ? 0 : Height(node.LeftChild) - Height(node.RightChild);
        }

        private bool IsLeftHeavy(AVLNode<T> node)
        {
            return BalanceFactor(node) > 1;
        }

        private bool IsRightHeavy(AVLNode<T> node)
        {
            return BalanceFactor(node) < -1;
        }

        private bool IsALeaf(AVLNode<T> node) => node.LeftChild == null && node.RightChild == null;
    }
}