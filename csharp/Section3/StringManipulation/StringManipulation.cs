using System;
using System.Text;

namespace csharp.Section3.StringManipulation
{
    public class StringManipulation
    {
        // Time complexity O(n) | space O(1)
        public static int CountVowels(string sentence)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int numberOfVowels = 0;

            string lowerCaseSentence = sentence.ToLower();

            foreach (char character in lowerCaseSentence)
            {
                if (Array.IndexOf(vowels, character) != -1)
                    numberOfVowels++;
            }

            return numberOfVowels;
        }

        // time complexity O(n) | Space complexity O(n)
        public static string ReverseStr(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int idx = str.Length - 1; idx >= 0; idx--)
            {
                stringBuilder.Append(str[idx]);
            }
            return stringBuilder.ToString();
        }


        public static string ReverseOrderOfWords(string sentence)
        {
            // split based on whitespace and store in a string array
            string[] words = sentence.Split(' ');

            StringBuilder stringBuilder = new StringBuilder();

            for (int idx = words.Length - 1; idx >= 0; idx--)
            {
                stringBuilder.Append($"{words[idx]} ");
            }
            return stringBuilder.ToString().Substring(0, sentence.Length - 1);

        }

        // REDO
        public static bool IsRotation(string str1, string str2)
        {
            return false;
        }

        public static string RemoveDuplicates(string word)
        {
            return "";
        }

        public static char FindMostRepeatedChar(string str)
        {
            return 'a';
        }

        public static string CapitalizeAndRemoveExtraSpaces(string sentence)
        {
            return "";
        }

        public static bool AreAnagrams(string str1, string str2)
        {
            return false;
        }

        public static bool IsPalindrome(string str)
        {
            return false;
        }


    }
}