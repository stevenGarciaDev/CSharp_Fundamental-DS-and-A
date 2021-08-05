namespace csharp.Section1.Queue
{
    public class ArrayQueue<T> : IGenericQueue<T>
    {
        // Front - Back
        private T[] _queue;
        private int _size;

        public ArrayQueue()
        {
            this.InitializeQueue();
        }

        public void Clear()
        {
            this.InitializeQueue();
        }

        public int Count() => _size;

        public T Dequeue()
        {
            T frontValue = default(T);
            if (_size == 0)
            {
                return frontValue;
            }
            else if (_size == 1)
            {
                _size--;
                return _queue[0];
            }
            else
            {
                frontValue = _queue[0];
                for (int i = 1; i < _size; i++)
                {
                    _queue[i - 1] = _queue[i];
                }
                _size--;
            }
            return frontValue;
        }

        public void Enqueue(T item)
        {
            if (this.NeedsResizing())
                this.Resize();

            _queue[_size++] = item;
        }

        public T Peek()
        {
            if (_size == 0)
                return default(T);
            return _queue[_size - 1];
        }

        private void InitializeQueue()
        {
            _queue = new T[10];
            _size = 0;
        }

        private bool NeedsResizing() => _size >= _queue.Length;

        private void Resize()
        {
            T[] updatedQueue = new T[_size * 2];
            for (int i = 0; i < _size; i++)
            {
                updatedQueue[i] = _queue[i];
            }
            _queue = updatedQueue;
        }
    }
}