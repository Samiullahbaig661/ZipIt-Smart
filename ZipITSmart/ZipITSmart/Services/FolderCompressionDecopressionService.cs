using System;
using System.IO;
using ZipITSmart.Core.Huffman;
using ZipITSmart.Core.Interfaces;
using ZipITSmart.Models;

namespace ZipITSmart.Services
{
    public class FolderCompressionDecompressionService : ICompressor, IDecompressor
    {
        public CompressionResult Compress(string inputPath, string outputPath)
        {
            string[] files = Directory.GetFiles(inputPath);
            long originalTotal = 0;
            long compressedTotal = 0;

            using var fs = new FileStream(outputPath, FileMode.Create);
            using var bw = new BinaryWriter(fs);

            bw.Write((byte)'D'); // marker for folder
            bw.Write(files.Length);

            foreach (var file in files)
            {
                byte[] data = File.ReadAllBytes(file);
                byte[] compressed = HuffmanService.Compress(data);

                bw.Write(Path.GetFileName(file));
                bw.Write(data.Length);
                bw.Write(compressed.Length);
                bw.Write(compressed);

                originalTotal += data.Length;
                compressedTotal += compressed.Length;
            }

            return new CompressionResult
            {
                OriginalSize = originalTotal,
                CompressedSize = compressedTotal
            };
        }

        public CompressionResult Decompress(string inputPath, string outputPath)
        {
            Directory.CreateDirectory(outputPath);
            long originalTotal = 0;
            long compressedTotal = 0;

            using var fs = new FileStream(inputPath, FileMode.Open);
            using var br = new BinaryReader(fs);

            byte marker = br.ReadByte();
            if (marker != 'D') throw new Exception("Not a valid compressed folder");

            int fileCount = br.ReadInt32();

            for (int i = 0; i < fileCount; i++)
            {
                string fileName = br.ReadString();
                int originalSize = br.ReadInt32();
                int compressedSize = br.ReadInt32();

                byte[] compressed = br.ReadBytes(compressedSize);
                byte[] data = HuffmanService.Decompress(compressed);

                File.WriteAllBytes(Path.Combine(outputPath, fileName), data);

                originalTotal += originalSize;
                compressedTotal += compressedSize;
            }

            return new CompressionResult
            {
                OriginalSize = originalTotal,
                CompressedSize = compressedTotal
            };
        }
    }
}
