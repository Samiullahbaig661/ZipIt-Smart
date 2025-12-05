using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressorAndDecompressor
{
    internal class FolderCompressor
    {
        public void CompressFolder(string inputFolderPath, string outputArchivePath)
        {
            // saari files (sirf top level; subfolders nahi)
            string[] files = Directory.GetFiles(inputFolderPath, "*.*", SearchOption.TopDirectoryOnly);

            using (var fs = new FileStream(outputArchivePath, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                // total files likho
                bw.Write(files.Length);

                foreach (var file in files)
                {
                    // original bytes
                    byte[] originalBytes = File.ReadAllBytes(file);

                    // yahan tumhara Huffman / compression function call hoga
                    byte[] compressedBytes = HuffmanService.Compress(originalBytes);

                    string fileName = Path.GetFileName(file);

                    // metadata
                    bw.Write(fileName.Length);          // int
                    bw.Write(fileName);                 // string
                    bw.Write(originalBytes.Length);     // int
                    bw.Write(compressedBytes.Length);   // int

                    // compressed data
                    bw.Write(compressedBytes);
                }
            }
        }
    }

    // yeh sirf example hai – tumhari team ka actual Huffman code yahan use hoga
    public static class HuffmanService
    {
        public static byte[] Compress(byte[] inputBytes)
        {
            // TODO: yahan actual huffman compression lagana hai
            return inputBytes; // abhi ke liye dummy
        }
    }

}
