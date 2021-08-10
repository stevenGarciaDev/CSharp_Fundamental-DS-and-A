using System;
using System.Collections.Generic;

namespace csharp.Section1.Dictionary
{
    public class GenericChainedDictionary<K, V> : IGenericDictionary<K, V>
    {
        // An array of linked lists.
        private LinkedList<Entry<K, V>>[] _map;
        private int _size;

        public V this[K key]
        {
            get
            {
                return this.GetValueOrDefault(key);
            }

            set
            {
                this.Add(key, value);
            }
        }

        public GenericChainedDictionary()
        {
            _map = new LinkedList<Entry<K, V>>[10];
            _size = 0;
        }

        public void Add(K key, V value)
        {
            if (this.DoesNeedResizing())
                this.Resize();

            LinkedList<Entry<K, V>> bucket = GetOrCreateBucket(key);
            foreach (Entry<K, V> entry in bucket)
            {
                if (entry.Value.Equals(value))
                    throw new Exception("Duplicate value added.");
            }
            Entry<K, V> newEntry = new Entry<K, V> { Key = key, Value = value };
            bucket.AddLast(newEntry);
            _size++;
        }

        public void Clear()
        {
            _map = new LinkedList<Entry<K, V>>[10];
            _size = 0;
        }

        public bool ContainsKey(K key)
        {
            int index = this.hash(key, _map.Length);
            if (_map[index] == null) return false;
            LinkedList<Entry<K, V>> bucket = _map[index];
            foreach (Entry<K, V> entry in bucket)
            {
                if (entry.Key.Equals(key))
                    return true;
            }
            return false;
        }

        public bool ContainsValue(V value)
        {
            foreach (LinkedList<Entry<K, V>> bucket in _map)
            {
                foreach (Entry<K, V> entry in bucket)
                {
                    if (entry.Value.Equals(value))
                        return true;
                }
            }
            return false;
        }

        public int Count()
        {
            return _size;
        }

        public K[] Keys()
        {
            List<K> allKeys = new List<K>();
            foreach (LinkedList<Entry<K, V>> bucket in _map)
            {
                foreach (Entry<K, V> entry in bucket)
                {
                    allKeys.Add(entry.Key);
                }
            }
            return allKeys.ToArray();
        }

        public void Remove(K key)
        {
            LinkedList<Entry<K, V>> bucket = GetOrCreateBucket(key);
            if (bucket.Count == 0) return;
            foreach (Entry<K, V> entry in bucket)
            {
                if (entry.Key.Equals(key))
                {
                    bucket.Remove(entry);
                    _size--;
                }
            }
        }

        public V[] Values()
        {
            List<V> allValues = new List<V>();
            foreach (LinkedList<Entry<K, V>> bucket in _map)
            {
                foreach (Entry<K, V> entry in bucket)
                {
                    allValues.Add(entry.Value);
                }
            }
            return allValues.ToArray();
        }

        private V GetValueOrDefault(K key)
        {
            var bucket = this.GetOrCreateBucket(key);
            if (bucket.Count == 0) return default(V);
            foreach (Entry<K, V> entry in bucket)
            {
                if (entry.Key.Equals(key))
                    return entry.Value;
            }
            return default(V);
        }

        private int hash(K key, int tableLength)
        {
            return key.GetHashCode() % tableLength;
        }

        private LinkedList<Entry<K, V>> GetOrCreateBucket(K key)
        {
            int index = this.hash(key, _map.Length);
            var bucket = _map[index];
            if (bucket == null)
            {
                bucket = new LinkedList<Entry<K, V>>();
                _map[index] = bucket;
            }
            return bucket;
        }

        private bool DoesNeedResizing()
        {
            double maxLoadFactor = 0.75;
            double loadFactor = _size / _map.Length;
            return loadFactor >= maxLoadFactor;
        }

        private void Resize()
        {
            int updatedCapacity = _map.Length * 2;
            LinkedList<Entry<K, V>>[] updatedMap = new LinkedList<Entry<K, V>>[updatedCapacity];

            // Must rehash each element and store in updatedMap
            foreach (LinkedList<Entry<K, V>> bucket in _map)
            {
                foreach (Entry<K, V> entry in bucket)
                {
                    int index = this.hash(entry.Key, updatedCapacity);
                    updatedMap[index].AddLast(entry);
                }
            }
            _map = updatedMap;
        }
    }
}