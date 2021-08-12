using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.Section2.Trie
{
    public class TrieNode
    {
        public char Value { get; set; }
        public bool IsEndOfWord { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode(char value = default(char))
        {
            Value = value;
            IsEndOfWord = false;
            Children = new Dictionary<char, TrieNode>();
        }

        public void AddChild(char character)
        {
            char lowercaseChar = LowerCaseChar(character);
            if (!Children.ContainsKey(lowercaseChar))
                Children.Add(lowercaseChar, new TrieNode(lowercaseChar));
        }

        public TrieNode GetNode(char character)
        {
            char lowercaseChar = LowerCaseChar(character);
            if (!Children.ContainsKey(lowercaseChar))
                throw new Exception($"Trie does not contain a child with the value of {lowercaseChar}.");

            return Children[lowercaseChar];
        }

        public bool HasChild(char character)
        {
            char lowercaseChar = LowerCaseChar(character);
            return Children.ContainsKey(lowercaseChar);
        }

        private char LowerCaseChar(char character)
        {
            char lowercaseChar = character.ToString().ToLower().ToCharArray()[0];
            return lowercaseChar;
        }
    }
}