namespace csharp.Section1.Dictionary
{
    public interface IGenericDictionary<K, V>
    {
        // The built-in C# Dictionary, the Add() method 
        // will throw an exception if there are duplicate keys.
        void Add(K key, V value);
        void Remove(K key);
        bool ContainsKey(K key);
        bool ContainsValue(V value);
        int Count();
        K[] Keys();
        V[] Values();
        void Clear();
    }
}