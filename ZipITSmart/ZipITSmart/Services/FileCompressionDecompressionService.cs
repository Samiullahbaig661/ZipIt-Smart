using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ZipITSmart.Core.Huffman;
using ZipITSmart.Core.Interfaces;
using ZipITSmart.Models;

namespace ZipITSmart.Services
{
    public class FileCompressionDecompressionService : ICompressor, IDecompressor
    {
        private readonly Dictionary<string, byte> fileFormats = new()
        {
            { ".txt", 0x01 },
            { ".doc", 0x02 },
            { ".docx", 0x03 },
            { ".ppt", 0x04 },
            { ".pptx", 0x05 },
            { ".pdf", 0x06 }
        };

        private readonly Dictionary<byte, string> formatExtensions;

        public FileCompressionDecompressionService()
        {
            formatExtensions = fileFormats.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        }

        public CompressionResult Compress(string inputPath, string outputPath)
        {
            byte[] data = File.ReadAllBytes(inputPath);
            byte[] compressed = HuffmanService.Compress(data);

            string ext = Path.GetExtension(inputPath).ToLower();
            byte formatByte = fileFormats.ContainsKey(ext) ? fileFormats[ext] : (byte)0x00;

            using var fs = new FileStream(outputPath, FileMode.Create);
            using var bw = new BinaryWriter(fs);

            bw.Write((byte)'F'); // marker for file
            bw.Write(formatByte);
            bw.Write(compressed.Length);
            bw.Write(compressed);

            return new CompressionResult
            {
                OriginalSize = data.Length,
                CompressedSize = compressed.Length
            };
        }

        public CompressionResult Decompress(string inputPath, string outputPath)
        {
            using var fs = new FileStream(inputPath, FileMode.Open);
            using var br = new BinaryReader(fs);

            byte marker = br.ReadByte();
            if (marker != 'F') throw new Exception("Not a valid compressed file");

            byte formatByte = br.ReadByte();
            string extension = formatExtensions.ContainsKey(formatByte) ? formatExtensions[formatByte] : ".dat";

            int length = br.ReadInt32();
            byte[] compressed = br.ReadBytes(length);
            byte[] data = HuffmanService.Decompress(compressed);

            // Ensure output path includes filename + extension
            string finalPath = Path.ChangeExtension(outputPath, extension);
            File.WriteAllBytes(finalPath, data);

            return new CompressionResult
            {
                OriginalSize = data.Length,
                CompressedSize = compressed.Length
            };
        }
    }
}
