using System;
using System.IO;
using ZipITSmart.Core.Archive;
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

            bw.Write((byte)'D');
            new ArchiveHeader { Type = ArchiveType.Folder }.Write(bw);

            bw.Write(Path.GetFileName(inputPath.TrimEnd(Path.DirectorySeparatorChar)));
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
                OriginalSize = compressedTotal,
                CompressedSize = originalTotal

            };
        }

        public CompressionResult Decompress(string inputPath, string outputPath)
        {
            long originalTotal = 0;
            long compressedTotal = 0;

            using var fs = new FileStream(inputPath, FileMode.Open);
            using var br = new BinaryReader(fs);

            byte marker = br.ReadByte();
            if (marker != 'D')
                throw new Exception("Not a valid compressed folder");

            ArchiveHeader.Read(br);

            string folderName = br.ReadString();

            string finalFolderPath = Path.Combine(outputPath, folderName);
            Directory.CreateDirectory(finalFolderPath);

            int fileCount = br.ReadInt32();

            for (int i = 0; i < fileCount; i++)
            {
                string fileName = br.ReadString();
                int originalSize = br.ReadInt32();
                int compressedSize = br.ReadInt32();

                byte[] compressedData = br.ReadBytes(compressedSize);
                byte[] originalData = HuffmanService.Decompress(compressedData);

                string filePath = Path.Combine(finalFolderPath, fileName);
                File.WriteAllBytes(filePath, originalData);

                originalTotal += originalSize;
                compressedTotal += compressedSize;
            }

            return new CompressionResult
            {
                OriginalSize = compressedTotal,
                CompressedSize = originalTotal
            };
        }
    }
}
