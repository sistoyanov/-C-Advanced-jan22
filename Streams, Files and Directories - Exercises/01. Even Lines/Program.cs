namespace EvenLines
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            //string outputFilePath = @"..\..\..\output.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder output = new StringBuilder();
            StreamReader reader = new StreamReader(inputFilePath);
            //StreamWriter writer = new StreamWriter(outputFilePath);

            using (reader)
            {
                int counter = 0;
                string line = String.Empty;

                //using (writer)
                //{
                    while ((line = reader.ReadLine())  != null)
                    {
                        if (counter % 2 == 0)
                        {
                            
                            char[] symbolsToReplace = { '-',',','.','!','?' };

                           foreach (var symbol in symbolsToReplace)
                           {
                               if (line.Contains(symbol))
                               {
                                   line = line.Replace(symbol, '@');
                               }
                           }

                           string[] currentWords = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
  
                           output.AppendLine(String.Join(" ", currentWords));
                        }

                        counter++;
        
                    }

                //}

            }

            return output.ToString();
        }
    }
}
