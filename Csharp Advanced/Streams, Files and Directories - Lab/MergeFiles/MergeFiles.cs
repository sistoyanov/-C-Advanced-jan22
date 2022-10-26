namespace MergeFiles
{
    using System;
    using System.IO;
    using System.Text;

    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[] firstFile = File.ReadAllLines(firstInputFilePath);
            string[] secondFile = File.ReadAllLines(secondInputFilePath);
            StringBuilder output = new StringBuilder();

            if (firstFile.Length >= secondFile.Length)
            {
                for (int i = 0; i < firstFile.Length; i++)
                {
                    output.AppendLine(firstFile[i]);
                    output.AppendLine(secondFile[i]);
                }
            }
            else
            {
                for (int k = 0; k < firstFile.Length; k++)
                {
                    output.AppendLine(firstFile[k]);
                    output.AppendLine(secondFile[k]);
                }

                for (int j = 0; j < secondFile.Length; j++)
                {
                    output.AppendLine(secondFile[j]);
                }
            }
            

            File.WriteAllText(outputFilePath, output.ToString());
        }
    }
}
