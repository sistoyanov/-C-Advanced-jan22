namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadLines(inputFilePath).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                int charCount = 0;
                int punctuationCount = 0;

                char[] currentSentance = lines[i].ToCharArray();

                foreach (var charItem in currentSentance)
                {
                    if (Char.IsLetter(charItem))
                    {
                        charCount++;
                    }
                    else if (charItem != ' ')    
                    {
                        punctuationCount++;
                    }
                }
                
                
                string currentLine = $"Line {i + 1}: {lines[i]} ({charCount})({punctuationCount}) \n";


                File.AppendAllText(outputFilePath, currentLine);
            }
            
        }
    }
}
