using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CompressorAndDecompressor
{
    public static class HuffmanService
    {
        // ************************************************************
        // COMPRESS
        // ************************************************************
        public static byte[] Compress(byte[] input)
        {
            // empty file handle
            if (input == null || input.Length == 0)
                return Array.Empty<byte>();

            // Frequency table
            Dictionary<byte, int> freq = new Dictionary<byte, int>();
            foreach (byte b in input)
            {
                if (!freq.ContainsKey(b))
                    freq[b] = 0;
                freq[b]++;
            }

            // Min-heap (priority queue)
            var pq = new SortedSet<HuffmanNode>(new HuffmanComparer());
            foreach (var kv in freq)
                pq.Add(new HuffmanNode { Symbol = kv.Key, Frequency = kv.Value });

            // Build tree
            while (pq.Count > 1)
            {
                var left = pq.Min; pq.Remove(left);
                var right = pq.Min; pq.Remove(right);

                pq.Add(new HuffmanNode
                {
                    Left = left,
                    Right = right,
                    Frequency = left.Frequency + right.Frequency
                });
            }

            HuffmanNode root = pq.Min;

            // Build Codes
            Dictionary<byte, string> codes = new Dictionary<byte, string>();
            BuildCodes(root, "", codes);

            // single-symbol file ke liye, code empty na rahe
            if (codes.Count == 1)
            {
                byte onlyKey = codes.Keys.First();
                if (codes[onlyKey].Length == 0)
                    codes[onlyKey] = "0";
            }

            // Encode data to bitstring (StringBuilder for speed)
            var sb = new StringBuilder(input.Length);
            foreach (byte b in input)
                sb.Append(codes[b]);

            string bitString = sb.ToString();

            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                // 1) Write tree
                WriteTree(root, bw);

                // 2) Write padding info
                int padding = 8 - (bitString.Length % 8);
                if (padding == 8) padding = 0;
                bw.Write((byte)padding);

                // 3) Write bitstring as bytes
                for (int i = 0; i < bitString.Length; i += 8)
                {
                    int len = Math.Min(8, bitString.Length - i);
                    string chunk = bitString.Substring(i, len);
                    if (len < 8)
                        chunk = chunk.PadRight(8, '0');

                    bw.Write(Convert.ToByte(chunk, 2));
                }

                return ms.ToArray();
            }
        }

        // ************************************************************
        // DECOMPRESS
        // ************************************************************
        public static byte[] Decompress(byte[] compressedData)
        {
            if (compressedData == null || compressedData.Length == 0)
                return Array.Empty<byte>();

            using (var ms = new MemoryStream(compressedData))
            using (var br = new BinaryReader(ms))
            {
                // 1) Rebuild Huffman tree
                HuffmanNode root = ReadTree(br);

                // 2) Padding byte
                int padding = br.ReadByte();

                // 3) Remaining bytes = bitstream
                byte[] body = br.ReadBytes((int)(ms.Length - ms.Position));

                var sb = new StringBuilder(body.Length * 8);
                foreach (byte b in body)
                    sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));

                string bitString = sb.ToString();

                if (padding > 0 && padding <= bitString.Length)
                    bitString = bitString.Substring(0, bitString.Length - padding);

                // 4) Decode bits using tree
                List<byte> output = new List<byte>();
                HuffmanNode current = root;

                foreach (char bit in bitString)
                {
                    current = (bit == '0') ? current.Left : current.Right;

                    if (current.Left == null && current.Right == null)
                    {
                        output.Add(current.Symbol);
                        current = root;
                    }
                }

                return output.ToArray();
            }
        }

        // ************************************************************
        // Helpers
        // ************************************************************
        private static void BuildCodes(HuffmanNode node, string code, Dictionary<byte, string> dict)
        {
            if (node.Left == null && node.Right == null)
            {
                dict[node.Symbol] = code;
                return;
            }

            BuildCodes(node.Left, code + "0", dict);
            BuildCodes(node.Right, code + "1", dict);
        }

        private static void WriteTree(HuffmanNode node, BinaryWriter bw)
        {
            if (node.Left == null && node.Right == null)
            {
                bw.Write((byte)1);
                bw.Write(node.Symbol);
                return;
            }

            bw.Write((byte)0);
            WriteTree(node.Left, bw);
            WriteTree(node.Right, bw);
        }

        private static HuffmanNode ReadTree(BinaryReader br)
        {
            byte flag = br.ReadByte();
            if (flag == 1)
            {
                return new HuffmanNode { Symbol = br.ReadByte() };
            }

            HuffmanNode node = new HuffmanNode();
            node.Left = ReadTree(br);
            node.Right = ReadTree(br);

            return node;
        }
    }

    public class HuffmanNode
    {
        public byte Symbol;
        public int Frequency;
        public HuffmanNode Left;
        public HuffmanNode Right;
    }

    public class HuffmanComparer : IComparer<HuffmanNode>
    {
        public int Compare(HuffmanNode x, HuffmanNode y)
        {
            int result = x.Frequency.CompareTo(y.Frequency);
            if (result == 0)
                result = x.GetHashCode().CompareTo(y.GetHashCode());
            return result;
        }
    }
}