using System;

namespace csharp.Section1.ArrayList
{
    public class GenericList<T> : IGenericList<T> where T : IComparable
    {
        private T[] _list;
        private int _size;

        public GenericList()
        {
            int defaultSize = 10;
            _list = new T[defaultSize];
            _size = 0;
        }

        public void Add(T item)
        {
            if (IsFull())
                Resize();

            _list[_size++] = item;
        }

        public bool Contains(T item)
        {
            for (int idx = 0; idx < _list.Length; idx++)
            {
                if (_list[idx].CompareTo(item) == 0)
                    return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int idx = 0; idx < _list.Length; idx++)
            {
                if (_list[idx].CompareTo(item) == 0)
                    return idx;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (IsFull())
                Resize();

            // shift elements from index + 1 to the right as to make room
            /*
                insert at index 2, value of 5

                    // so _size is == 4

                [1, 2, 3, 4]

                       i     size
                [1, 2, 3, 4, 0, 0, 0, 0]

                       i     size
                [1, 2, 3, 4, 4, 0, 0, 0]

                [1, 2, 3, 3, 4, 0, 0, 0]

                [1, 2, 5, 3, 4, 0, 0, 0]

            */
            for (int i = _size - 1; i > index; i--)
            {
                _list[i + 1] = _list[i];
            }

            _list[index] = item;
            _size++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;

            /*
                remove 1


            [1, 2, 3, 4, 0]

                its index is at 0
                we need to fill its spot 

            i           _size
            [1, 2, 3, 4, 0]

            */

            while (index < _size)
            {
                _list[index] = _list[index + 1];
            }

            _size -= 1;
            return true;
        }

        private bool IsFull() => _size >= _list.Length;

        private void Resize()
        {
            int doubledSize = _size * 2;
            T[] updatedList = new T[_size];
            for (int idx = 0; idx < _list.Length; idx++)
            {
                updatedList[idx] = _list[idx];
            }
            _list = updatedList;
        }
    }
}