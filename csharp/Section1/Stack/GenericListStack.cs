using System.Collections.Generic;
using System;

namespace csharp.Section1.Stack
{
    public class GenericListStack<T> : IGenericStack<T>
    {
        // first is the top, back is the bottom
        private LinkedList<T> _stack;

        public GenericListStack()
        {
            _stack = new LinkedList<T>();
        }

        public void Clear()
        {
            _stack = new LinkedList<T>();
        }

        public bool IsEmpty() => _stack.Count == 0;

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Unable to peek due to stack being empty.");

            return _stack.First.Value;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new Exception("Unable to pop due to stack being empty.");

            T firstValue = _stack.First.Value;
            _stack.RemoveFirst();
            return firstValue; ;
        }

        public void Push(T value)
        {
            _stack.AddLast(value);
        }

        public int Count() => _stack.Count;
    }
}