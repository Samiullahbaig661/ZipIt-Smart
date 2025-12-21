using System;
using System.IO;
using ZipITSmart.Core.Huffman;
using ZipITSmart.Core.Interfaces;
using ZipITSmart.Models;

namespace ZipITSmart.Services
{
    public class ImageCompressionDecompressionService : ICompressor, IDecompressor
    {
        public CompressionResult Compress(string inputPath, string outputPath)
        {
            byte[] data = File.ReadAllBytes(inputPath);
            string ext = Path.GetExtension(inputPath).ToLower();
            byte formatByte = GetFormatByte(ext);

            byte[] compressed = HuffmanService.Compress(data);

            using var fs = new FileStream(outputPath, FileMode.Create);
            using var bw = new BinaryWriter(fs);

            bw.Write((byte)'I'); 
            bw.Write(formatByte);
            bw.Write(compressed.Length);
            bw.Write(compressed);

            return new CompressionResult
            {
                OriginalSize = compressed.Length,
                CompressedSize = data.Length
            };
        }

        public CompressionResult Decompress(string inputPath, string outputPath)
        {
            using var fs = new FileStream(inputPath, FileMode.Open);
            using var br = new BinaryReader(fs);

            byte marker = br.ReadByte();
            if (marker != 'I') throw new Exception("Not a valid compressed image");

            byte formatByte = br.ReadByte();
            string ext = GetExtensionFromFormatByte(formatByte);

            int length = br.ReadInt32();
            byte[] compressed = br.ReadBytes(length);
            byte[] data = HuffmanService.Decompress(compressed);

            string finalPath = Path.ChangeExtension(outputPath, ext);
            File.WriteAllBytes(finalPath, data);

            return new CompressionResult
            {
                OriginalSize = compressed.Length,
                CompressedSize = data.Length
            };
        }

        private byte GetFormatByte(string ext) => ext switch
        {
            ".jpg" or ".jpeg" => 0x01,
            ".png" => 0x02,
            ".bmp" => 0x03,
            ".gif" => 0x04,
            ".tiff" => 0x05,
            _ => 0x00
        };

        private string GetExtensionFromFormatByte(byte format) => format switch
        {
            0x01 => ".jpg",
            0x02 => ".png",
            0x03 => ".bmp",
            0x04 => ".gif",
            0x05 => ".tiff",
            _ => ".dat"
        };
    }
}
