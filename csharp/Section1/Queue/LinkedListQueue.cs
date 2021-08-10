using System.Collections.Generic;
using System;

namespace csharp.Section1.Queue
{
    public class LinkedListQueue<T> : IGenericQueue<T>
    {
        //  .First is front of queue, .Last is end of queue
        private LinkedList<T> _queue;

        public LinkedListQueue()
        {
            _queue = new LinkedList<T>();
        }

        public void Clear()
        {
            _queue = new LinkedList<T>();
        }

        public int Count() => _queue.Count;

        public T Dequeue()
        {
            if (_queue.Count == 0)
                throw new Exception("Cannot remove from an empty queue.");

            T firstValue = _queue.First.Value;
            _queue.RemoveFirst();
            return firstValue;
        }

        public void Enqueue(T item)
        {
            _queue.AddFirst(item);
        }

        public bool IsEmpty() => _queue.Count == 0;

        public T Peek()
        {
            if (_queue.Count == 0)
                throw new Exception("Queue is empty. Cannot peek to see the first value");
            return _queue.First.Value;
        }
    }
}