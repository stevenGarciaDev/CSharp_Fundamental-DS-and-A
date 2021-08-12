namespace csharp.Section2.Trie
{
    public interface ITrie
    {
        void Insert(string word);
        string Remove(string word);
        bool Contains(string word);
        void PreOrder();
        void PostOrder();
    }
}