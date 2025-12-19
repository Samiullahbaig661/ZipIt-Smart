using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressorAndDecompressor
{
    public class ImageCompressorDecompressor
    {
        public void CompressImage(string imagePath, string outputPath)
        {
            try
            {
                // Read image bytes
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // Get image extension for metadata
                string extension = Path.GetExtension(imagePath).ToLower();

                // For images, we'll store the original format/type
                byte formatByte = GetFormatByte(extension);

                // Compress using Huffman
                byte[] compressedData = HuffmanService.Compress(imageBytes);

                // Save with image metadata
                using (var fs = new FileStream(outputPath, FileMode.Create))
                using (var bw = new BinaryWriter(fs))
                {
                    // Write marker to identify as image (e.g., 'I')
                    bw.Write((byte)'I');

                    // Write original image format
                    bw.Write(formatByte);

                    // Write compressed data
                    bw.Write(compressedData.Length);
                    bw.Write(compressedData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error compressing image: {ex.Message}", ex);
            }
        }

        public void DecompressImage(string compressedPath, string outputPath)
        {
            try
            {
                using (var fs = new FileStream(compressedPath, FileMode.Open))
                using (var br = new BinaryReader(fs))
                {
                    // Check if it's an image file
                    byte marker = br.ReadByte();
                    if (marker != 'I')
                        throw new Exception("Not a valid compressed image file");

                    // Read original format
                    byte formatByte = br.ReadByte();
                    string extension = GetExtensionFromFormatByte(formatByte);

                    // Read compressed data length and data
                    int dataLength = br.ReadInt32();
                    byte[] compressedData = br.ReadBytes(dataLength);

                    // Decompress
                    byte[] originalData = HuffmanService.Decompress(compressedData);

                    // Write to file
                    string finalPath = Path.ChangeExtension(outputPath, extension);
                    File.WriteAllBytes(finalPath, originalData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error decompressing image: {ex.Message}", ex);
            }
        }

        private byte GetFormatByte(string extension)
        {
            extension = extension.ToLower();

            if (extension == ".jpg" || extension == ".jpeg")
                return 0x01;
            else if (extension == ".png")
                return 0x02;
            else if (extension == ".bmp")
                return 0x03;
            else if (extension == ".gif")
                return 0x04;
            else if (extension == ".tiff")
                return 0x05;
            else
                return 0x00; // Unknown/raw
        }

        private string GetExtensionFromFormatByte(byte format)
        {
            switch (format)
            {
                case 0x01:
                    return ".jpg";
                case 0x02:
                    return ".png";
                case 0x03:
                    return ".bmp";
                case 0x04:
                    return ".gif";
                case 0x05:
                    return ".tiff";
                default:
                    return ".dat";
            }
        }
    }
}
