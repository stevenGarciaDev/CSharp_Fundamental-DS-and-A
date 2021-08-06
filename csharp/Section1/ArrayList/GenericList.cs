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
            if (_size >= _list.Length)
            {
                int doubledSize = _size * 2;
                T[] updatedList = new T[_size];
                for (int idx = 0; idx < _list.Length; idx++)
                {
                    updatedList[idx] = _list[idx];
                }
                _list = updatedList;
            }

            _list[_size] = item;
            _size++;
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
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;

            while (index < _size)
            {
                _list[index] = _list[index + 1];
            }

            _size -= 1;
            return true;
        }
    }
}