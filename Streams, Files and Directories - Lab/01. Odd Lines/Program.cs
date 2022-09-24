using System;
using System.IO;
using System.Linq;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            int count = 0;
            string[] lines = File.ReadLines(inputFilePath).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                if (count % 2 != 0)
                {
                    File.AppendAllText(outputFilePath, lines[i] + Environment.NewLine);
                }

                count++;
            }
        }
    }
}
