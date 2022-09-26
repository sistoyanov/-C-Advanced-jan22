namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

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
            StringBuilder ouput = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                int charCount = lines[i].Count(ch => char.IsLetter(ch));
                int punctuationCount = lines[i].Count(ch => char.IsPunctuation(ch));

                ouput.AppendLine($"Line {i + 1}: {lines[i]} ({charCount})({punctuationCount})");
                
            }

            File.WriteAllText(outputFilePath, ouput.ToString());

        }
    }
}
