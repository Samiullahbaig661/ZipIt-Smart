using System;
using System.IO;

namespace CompressorAndDecompressor
{
    internal class FolderDecompressor
    {
        public void DecompressArchive(string inputArchivePath, string outputFolderPath)
        {
            if (!File.Exists(inputArchivePath))
                throw new FileNotFoundException("Archive file not found.", inputArchivePath);

            if (!Directory.Exists(outputFolderPath))
                Directory.CreateDirectory(outputFolderPath);

            using (var fs = new FileStream(inputArchivePath, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                int totalFiles = br.ReadInt32();

                for (int i = 0; i < totalFiles; i++)
                {
                    // yahan seedha string read karo (matches Write(string))
                    string fileName = br.ReadString();

                    int originalSize = br.ReadInt32();
                    int compressedSize = br.ReadInt32();

                    byte[] compressedBytes = br.ReadBytes(compressedSize);
                    byte[] originalBytes = HuffmanService.Decompress(compressedBytes);

                    string outPath = Path.Combine(outputFolderPath, fileName);
                    File.WriteAllBytes(outPath, originalBytes);
                }
            }
        }
    }
}
