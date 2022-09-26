using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string[] words = File.ReadAllText(wordsFilePath).Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] lines = File.ReadAllLines(textFilePath);
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordCounts.ContainsKey(word))
                {
                    wordCounts.Add(word, 0);
                }
            }

            foreach (var line in lines)
            {
                string regex = @"[\w\']+";
                MatchCollection matches = Regex.Matches(line, regex);

                foreach (Match match in matches)
                {
                   string currentWord = match.Value.ToLower();
                    
                    if (wordCounts.ContainsKey(currentWord))
                    {
                        wordCounts[currentWord]++;
                    }
                }
            }

            wordCounts = wordCounts.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in wordCounts)
            {

                string output = $"{kvp.Key} - {kvp.Value}";
                File.AppendAllText(outputFilePath, output + Environment.NewLine);
            }
        }
    }
}

