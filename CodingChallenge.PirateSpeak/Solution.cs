using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingChallenge.PirateSpeak
{
    public class Solution
    {
        // Get character occurences for a word
        public Dictionary<char, int> getWordCharacters(string word)
        {
            Dictionary<char, int> wordChars = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (wordChars.ContainsKey(c))
                {
                    wordChars[c] += 1;
                }
                else
                {
                    wordChars.Add(c, 1);
                }
            }
            return wordChars;
        }

        public string[] GetPossibleWords(string jumble, string[] dictionary)
        {
            List<string> possibleWords = new List<string>();

            var jumbleChars = this.getWordCharacters(jumble);

            // Iterate through each word in the dictionary
            foreach (string word in dictionary)
            {
                if (word.Length != jumble.Length)
                {
                    continue;
                }

                Dictionary<char, int> wordChars = new Dictionary<char, int>();
                int i;
                for (i = 0; i < word.Length; i ++)
                {
                    char c = word[i];
                    if (wordChars.ContainsKey(c))
                    {
                        wordChars[c] += 1;
                    }
                    else
                    {
                        wordChars.Add(c, 1);
                    }
                    if (!jumbleChars.ContainsKey(c) || wordChars[c] > jumbleChars[c])
                    {
                        break;
                    }
                }
                if (word.Length == i)
                {
                    possibleWords.Add(word);
                }
            }

            return possibleWords.ToArray();
        }
    }
}