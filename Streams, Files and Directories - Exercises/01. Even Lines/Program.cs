namespace EvenLines
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string output = String.Empty;
            StreamReader reader = new StreamReader(inputFilePath);
            //StreamWriter writer = new StreamWriter(@"../../../output.txt");

            using (reader)
            {
                int counter = 0;
                string line = reader.ReadLine();

                //using (writer)
                //{
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            string[] currentWords = line.Split(' ');
                            currentWords = currentWords.Reverse().ToArray();

                            for (int i = 0; i < currentWords.Length; i++)
                            {
                              currentWords[i] = currentWords[i].Replace('-', '@').Replace(',', '@').Replace('.', '@').Replace('!', '@').Replace('?', '@');
                            }

                            //writer.WriteLine(String.Join(" ", currentWords));
                            output += (String.Join(" ", currentWords));
                        }

                        counter++;
                        line = reader.ReadLine();
                    }

                //}

            }

            return output;
        }
    }
}
