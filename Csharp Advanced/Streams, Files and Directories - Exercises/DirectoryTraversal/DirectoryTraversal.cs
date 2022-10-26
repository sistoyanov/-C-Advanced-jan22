namespace DirectoryTraversal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> allFiles = new SortedDictionary<string, List<FileInfo>>();
            string[] filesInDirectory = Directory.GetFiles(inputFolderPath);

            foreach (var file in filesInDirectory)
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileExtention = fileInfo.Extension;

                if (!allFiles.ContainsKey(fileExtention))
                {
                    allFiles.Add(fileExtention, new List<FileInfo>());
                }

                allFiles[fileExtention].Add(fileInfo);
            }

            var orderedFilesByCount = allFiles.OrderByDescending(v => v.Value.Count());
            StringBuilder ouput = new StringBuilder();

            foreach (var extensionFile in orderedFilesByCount)
            {
                ouput.AppendLine(extensionFile.Key);

                var orderedFilesBySize = extensionFile.Value.OrderByDescending(f => f.Length);

                foreach (var file in orderedFilesBySize)
                {
                    long fileSize = file.Length;
                    double fileSizeKB = fileSize / 1024d;

                    ouput.AppendLine($"--{file.Name} - {fileSizeKB:f3}kb");
                }
            }

            return ouput.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(filePath, textContent);
        }
    }

}
