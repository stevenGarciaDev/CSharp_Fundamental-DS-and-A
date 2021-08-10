using System;

namespace csharp.Section2.Heap
{
    public class MaxHeap<T> : IHeap<T> where T : IComparable<T>
    {
        private T[] _heap;
        private int _size;

        public MaxHeap()
        {
            _heap = new T[10];
            _size = 0;
        }

        public T Get()
        {
            if (_size == 0)
                throw new Exception("Cannot get max value from an empty heap.");

            return _heap[0];
        }

        public void Insert(T value)
        {
            if (IsFull())
                Resize();

            _heap[_size++] = value;

            BubbleUp();
        }

        public T Remove()
        {
            if (_size == 0)
                throw new Exception("Cannot remove from an empty heap.");

            T maxValue = _heap[0];

            Swap(0, _size - 1);

            BubbleDown();

            return maxValue;
        }

        private void BubbleUp()
        {
            int index = _size - 1;
            while (index > 0 && _heap[index].CompareTo(Parent(index)) == 1)
            {
                Swap(index, ParentIndex(index));
                index = ParentIndex(index);
            }
        }

        private void BubbleDown()
        {
            int index = 0;
            while (index < _size && !this.IsValidParent(index))
            {
                int largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private bool IsFull() => _heap.Length >= _size;

        private void Resize()
        {
            T[] updatedHeap = new T[_size * 2];
            for (int i = 0; i < _size; i++)
            {
                updatedHeap[i] = _heap[i];
            }
            _heap = updatedHeap;
        }

        private void Swap(int index1, int index2)
        {
            T temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            T parentValue = _heap[index];

            if (LeftChild(index).CompareTo(parentValue) == 1)
                return false;

            if (RightChild(index).CompareTo(parentValue) == 1)
                return false;

            return true;
        }

        private int LargerChildIndex(int index)
        {
            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return LeftChild(index).CompareTo(RightChild(index)) == 1
                ? LeftChildIndex(index) : RightChildIndex(index);
        }

        private T Parent(int index) => _heap[ParentIndex(index)];

        private int ParentIndex(int index) => (index - 1) / 2;

        private bool HasLeftChild(int index) => LeftChildIndex(index) < -_size;

        private T LeftChild(int index) => _heap[LeftChildIndex(index)];

        private int LeftChildIndex(int index) => (index * 2) + 1;

        private bool HasRightChild(int index) => RightChildIndex(index) < _size;

        private T RightChild(int index) => _heap[RightChildIndex(index)];

        private int RightChildIndex(int index) => (index * 2) + 2;

        private bool IsALeaf(int index) => !HasLeftChild(index) && !HasRightChild(index);

    }
}