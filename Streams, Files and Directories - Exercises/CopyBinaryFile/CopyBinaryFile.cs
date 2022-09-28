﻿namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            FileStream reader = new FileStream(inputFilePath, FileMode.Open);
            FileStream writer = new FileStream(outputFilePath, FileMode.Create);

            using (reader)
            {
                byte[] buffer = new byte[reader.Length];
                reader.Read(buffer, 0, buffer.Length);

                using (writer)
                {
                    writer.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
