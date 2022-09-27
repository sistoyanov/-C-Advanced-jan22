namespace ExtractBytes
{
    using System;
    using System.IO;
    public class ExtractSBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            FileStream image = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read);
            FileStream bytes = new FileStream(bytesFilePath, FileMode.Open, FileAccess.Read);
            FileStream output = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            byte[] imageBuffer = new byte[image.Length];
            byte[] bytesBuffer = new byte[bytes.Length];

            using (image)
            {
                using (bytes)
                {
                    image.Read(imageBuffer, 0, (int)image.Length);
                    bytes.Read(bytesBuffer, 0, (int)bytes.Length);
                }
            }

            using (output)
            {
                for (int i = 0; i < imageBuffer.Length; i++)
                {
                    for (int j = 0; j < bytesBuffer.Length; j++)
                    {
                        if (imageBuffer[i] == bytesBuffer[j])
                        {
                            output.Write(new byte[] { imageBuffer[i] });
                        }
                    }
                }
            }
        }
    }
}
