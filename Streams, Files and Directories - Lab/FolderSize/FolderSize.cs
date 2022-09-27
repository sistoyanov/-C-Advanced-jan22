namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo folderInfo = new DirectoryInfo(folderPath);
            DirectoryInfo[] subFolders = folderInfo.GetDirectories();
            long totalSize = 0;

            FileInfo[] allFiles = folderInfo.GetFiles();

            foreach (var file in allFiles)
            {
                totalSize += file.Length;
            }

            foreach (var dir in subFolders)
            {
                FileInfo[] allSbFiles = dir.GetFiles();

                foreach (var sbFile in allSbFiles)
                {
                    totalSize += sbFile.Length;
                }
            }

            double newSize = totalSize / 1024d;
            File.WriteAllText(outputFilePath, $"{newSize} KB");
        }
    }
}
