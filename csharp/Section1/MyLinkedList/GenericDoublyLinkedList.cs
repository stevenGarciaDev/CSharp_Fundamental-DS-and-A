using System;

namespace csharp.Section1.MyLinkedList
{
    public class GenericDoublyLinkedList<T> : IGenericList<T> where T : IComparable<T>
    {
        private DoublyNode<T> _head;
        private DoublyNode<T> _tail;
        private int _size;

        public GenericDoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }

        public void AddFirst(T item)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _head.Previous = newNode;
                newNode.Next = _head;
                _head = newNode;
            }

            _size++;
        }

        public void AddLast(T item)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(item);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else if (_head == _tail)
            {
                _head.Next = newNode;
                newNode.Previous = _head;
                _tail = newNode;
            }
            else
            {
                newNode.Previous = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }

            _size++;
        }

        public int Count() => _size;

        public int IndexOf(T item)
        {
            if (_head == null) return -1;
            DoublyNode<T> current = _head;

            int idx = 0;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                    return idx;
                idx++;
                current = current.Next;
            }
            return -1;
        }

        public T KthFromEnd(int k)
        {
            if (k > _size)
                throw new Exception("Size of linked list is not large enough to retrieve that value.");

            DoublyNode<T> current = _tail;
            for (int i = 1; i < k; i++)
            {
                current = current.Previous;
            }
            return current.Value;
        }

        public T RemoveFirst()
        {
            /*
            if head is null 

            is head has just one value, no next 

            if there are 2 nodes 

            if there are 3 or more 
            */

            if (_head == null)
                throw new Exception("List is empty");

            T valueToRemove = default(T);

            if (_head == _tail)
            {
                valueToRemove = _head.Value;
                _head = null;
                _tail = null;
            }
            else if (_head.Next == null)
            {
                _head = _tail;
            }
            else
            {
                _head = _head.Next;
            }

            _size--;
            return valueToRemove;
        }

        public T RemoveLast()
        {
            throw new System.NotImplementedException();
        }

        public void Reverse()
        {
            throw new System.NotImplementedException();
        }
    }
}