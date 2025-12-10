using System;
using System.Collections.Generic;
using System.Text;

namespace ZipITSmart.Core.Huffman
{
    public static class HuffmanService
    {
        public static byte[] Compress(byte[] data)
        {
            if (data == null || data.Length == 0)
                return Array.Empty<byte>();

            var tree = new HuffmanTree();
            var codeTable = tree.Build(data);

            var bitString = new StringBuilder();
            foreach (byte b in data)
                bitString.Append(codeTable[b]);

            int padding = (8 - bitString.Length % 8) % 8;
            bitString.Append('0', padding);

            var bytes = new List<byte>();
            for (int i = 0; i < bitString.Length; i += 8)
            {
                bytes.Add(Convert.ToByte(bitString.ToString(i, 8), 2));
            }

            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                WriteTree(bw, tree.Root);
                bw.Write((byte)padding);
                bw.Write(bytes.ToArray());
                return ms.ToArray();
            }
        }

        public static byte[] Decompress(byte[] compressed)
        {
            if (compressed == null || compressed.Length == 0)
                return Array.Empty<byte>();

            using (var ms = new MemoryStream(compressed))
            using (var br = new BinaryReader(ms))
            {
                var root = ReadTree(br);
                int padding = br.ReadByte();

                var bits = new StringBuilder();
                while (ms.Position < ms.Length)
                {
                    bits.Append(Convert.ToString(br.ReadByte(), 2).PadLeft(8, '0'));
                }

                if (padding > 0)
                    bits.Length -= padding;

                var output = new List<byte>();
                var current = root;

                foreach (char bit in bits.ToString())
                {
                    current = bit == '0' ? current.Left : current.Right;
                    if (current.IsLeaf)
                    {
                        output.Add(current.Symbol.Value);
                        current = root;
                    }
                }

                return output.ToArray();
            }
        }

        private static void WriteTree(BinaryWriter bw, HuffmanNode node)
        {
            if (node.IsLeaf)
            {
                bw.Write(true);
                bw.Write(node.Symbol.Value);
            }
            else
            {
                bw.Write(false);
                WriteTree(bw, node.Left);
                WriteTree(bw, node.Right);
            }
        }

        private static HuffmanNode ReadTree(BinaryReader br)
        {
            bool isLeaf = br.ReadBoolean();
            if (isLeaf)
            {
                return new HuffmanNode
                {
                    Symbol = br.ReadByte()
                };
            }

            return new HuffmanNode
            {
                Left = ReadTree(br),
                Right = ReadTree(br)
            };
        }
    }
}
