using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                int counter = 0;
                string line = String.Empty; 

                using (writer)
                {
                  while ((line = reader.ReadLine()) != null)
                  {
                    counter++;
                    writer.WriteLine($"{counter}. {line}");
                  
                  }

                }

            }
        }
    }
}
