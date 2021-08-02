using System;
using System.Collections.Generic;

namespace csharp.Section1.Stack
{
    public class GenericArrayStack<T> : IGenericStack<T>
    {
        private T[] _stack;
        private int _topOfStack;
        private int _size;

        public GenericArrayStack()
        {
            this.InitializeStack();
        }

        public void Clear()
        {
            this.InitializeStack();
        }

        public bool IsEmpty() => _size == 0;

        // Time complexity O(1) 
        public T Peek()
        {
            if (_size == 0)
                return default(T);

            return _stack[_size - 1];
        }

        // Time complexity O(1)
        public T Pop()
        {
            if (this.IsEmpty())
                throw new Exception("Invalid operation. Can not Pop() when stack is empty.");

            T topValue = _stack[--_size];

            return topValue;
        }

        // Time complexity Big theta, O(1) | worst case Big O(n)
        // Space complexity Big theta O(1) | worst case Big O(n^2)
        public void Push(T value)
        {
            if (this.NeedsResizing())
                this.Resize();

            _stack[_size++] = value;
        }

        public int Count() => _size;

        private bool NeedsResizing() => _size >= _stack.Length;

        private void Resize()
        {
            T[] updatedStack = new T[_size * 2];
            for (int i = 0; i < _size; i++)
            {
                updatedStack[i] = _stack[i];
            }
            _stack = updatedStack;
        }

        private void InitializeStack()
        {
            _stack = new T[10];
            _size = 0;
        }
    }
}