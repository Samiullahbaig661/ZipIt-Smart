using System;
using System.IO;

namespace CompressorAndDecompressor
{
    public class FolderCompressor
    {
        public void CompressFolder(string inputFolderPath, string outputArchivePath)
        {
            // sirf top-level files (subfolders nahi)
            string[] files = Directory.GetFiles(inputFolderPath, "*.*", SearchOption.TopDirectoryOnly);

            using (var fs = new FileStream(outputArchivePath, FileMode.Create, FileAccess.Write))
            using (var bw = new BinaryWriter(fs))
            {
                // total files
                bw.Write(files.Length);

                foreach (var file in files)
                {
                    byte[] originalBytes = File.ReadAllBytes(file);
                    byte[] compressedBytes = HuffmanService.Compress(originalBytes);
                    string fileName = Path.GetFileName(file);

                    // ⚠️ IMPORTANT: sirf string likho, length alag se nahi
                    bw.Write(fileName);                      // BinaryWriter.Write(string)
                    bw.Write(originalBytes.Length);          // int
                    bw.Write(compressedBytes.Length);        // int

                    bw.Write(compressedBytes);               // data
                }
            }
        }
    }
}
