using System;
using System.IO;
using ZipITSmart.Core.Interfaces;
using ZipITSmart.Models;

namespace ZipITSmart.Services
{
    public class CompressionDispatcher
    {
        private readonly ICompressor _fileCompressor = new FileCompressionDecompressionService();
        private readonly ICompressor _imageCompressor = new ImageCompressionDecompressionService();
        private readonly ICompressor _folderCompressor = new FolderCompressionDecompressionService();

        private readonly IDecompressor _fileDecompressor = new FileCompressionDecompressionService();
        private readonly IDecompressor _imageDecompressor = new ImageCompressionDecompressionService();
        private readonly IDecompressor _folderDecompressor = new FolderCompressionDecompressionService();

        public CompressionResult Compress(string type, string inputPath, string outputPath) => type.ToLower() switch
        {
            "file" => _fileCompressor.Compress(inputPath, outputPath),
            "image" => _imageCompressor.Compress(inputPath, outputPath),
            "folder" => _folderCompressor.Compress(inputPath, outputPath),
            _ => throw new ArgumentException("Invalid type. Must be File, Image, or Folder.")
        };

        public CompressionResult Decompress(string inputPath, string outputPath)
        {
            if (!File.Exists(inputPath))
                throw new FileNotFoundException("Compressed file not found", inputPath);

            byte marker;
            using (var fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                marker = (byte)fs.ReadByte();

            return marker switch
            {
                (byte)'F' => _fileDecompressor.Decompress(inputPath, outputPath),
                (byte)'I' => _imageDecompressor.Decompress(inputPath, outputPath),
                (byte)'D' => _folderDecompressor.Decompress(inputPath, outputPath),
                _ => throw new Exception("Unknown compressed file type")
            };
        }
    }
}
