namespace csharp.Section2.Trie
{
    public class Trie : ITrie
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public bool Contains(string word)
        {
            if (word == null)
                return false;

            string lowercaseWord = word.ToLower();
            TrieNode current = _root;

            foreach (char character in lowercaseWord.ToCharArray())
            {
                if (!current.HasChild(character))
                    return false;

                current = current.GetNode(character);
            }

            return current.IsEndOfWord == true;
        }

        public void Insert(string word)
        {
            if (word == null) return;

            string lowercaseWord = word.ToLower();
            TrieNode current = _root;

            foreach (char character in lowercaseWord.ToCharArray())
            {
                if (!current.HasChild(character))
                    current.AddChild(character);

                current = current.GetNode(character);
            }
            current.IsEndOfWord = true;
        }

        public void PostOrder()
        {
            throw new System.NotImplementedException();
        }

        public void PreOrder()
        {
            throw new System.NotImplementedException();
        }

        public string Remove(string word)
        {
            // go up to that 
            throw new System.NotImplementedException();
        }
    }
}