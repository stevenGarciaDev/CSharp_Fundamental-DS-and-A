using System.Collections.Generic;
using System;

namespace csharp.Section1.Queue
{
    public class StackQueue<T> : IGenericQueue<T>
    {
        /* 
        So with stacks, only have access to the top.
        Therefore would need two stacks.
        
        One to access the top value (the front of the queue)
        One to add to the back. (the back of the queue)

        queue is 
        f ["harry", "ron", "hermonie"] b

            stack 1
                top ["harry", "ron", "hermonie"]  back

            stack 2
                []

        so if adding a new value to the back of the queue

        */
        private Stack<T> _stack1;
        private Stack<T> _stack2;

        public StackQueue()
        {
            _stack1 = new Stack<T>();
            _stack2 = new Stack<T>();
        }

        public void Clear()
        {
            _stack1 = new Stack<T>();
        }

        public int Count() => _stack1.Count;

        public T Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Cannot dequeue an empty queue");
            return _stack1.Pop();
        }

        public void Enqueue(T item)
        {
            if (_stack1.Count == 0)
            {
                _stack1.Push(item);
            }
            else
            {
                while (_stack1.Count != 0)
                {
                    _stack2.Push(_stack1.Pop());
                }

                _stack2.Push(item);

                while (_stack2.Count != 0)
                {
                    _stack1.Push(_stack2.Pop());
                }
            }
        }

        public bool IsEmpty() => _stack1.Count == 0;

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Unable to peek at front of queue since queue is empty");

            return _stack1.Peek();
        }
    }
}