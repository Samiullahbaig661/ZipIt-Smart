using System;
using System.Collections.Generic;
using System.Text;

namespace ZipITSmart.Core.Huffman
{
    public class HuffmanTree
    {
        public HuffmanNode Root { get; private set; }

        public Dictionary<byte, string> Build(byte[] data)
        {
            var frequency = new Dictionary<byte, int>();

            foreach (byte b in data)
            {
                if (!frequency.ContainsKey(b))
                    frequency[b] = 0;
                frequency[b]++;
            }

            var nodes = frequency
                .Select(kvp => new HuffmanNode
                {
                    Symbol = kvp.Key,
                    Frequency = kvp.Value
                })
                .ToList();

            if (nodes.Count == 1)
            {
                Root = new HuffmanNode
                {
                    Left = nodes[0],
                    Frequency = nodes[0].Frequency
                };
            }
            else
            {
                while (nodes.Count > 1)
                {
                    var ordered = nodes.OrderBy(n => n.Frequency).ToList();

                    var left = ordered[0];
                    var right = ordered[1];

                    var parent = new HuffmanNode
                    {
                        Left = left,
                        Right = right,
                        Frequency = left.Frequency + right.Frequency
                    };

                    nodes.Remove(left);
                    nodes.Remove(right);
                    nodes.Add(parent);
                }

                Root = nodes[0];
            }

            var codes = new Dictionary<byte, string>();
            GenerateCodes(Root, "", codes);
            return codes;
        }

        private void GenerateCodes(HuffmanNode node, string code, Dictionary<byte, string> table)
        {
            if (node == null)
                return;

            if (node.IsLeaf && node.Symbol.HasValue)
            {
                table[node.Symbol.Value] = code.Length > 0 ? code : "0";
            }

            GenerateCodes(node.Left, code + "0", table);
            GenerateCodes(node.Right, code + "1", table);
        }
    }
}
