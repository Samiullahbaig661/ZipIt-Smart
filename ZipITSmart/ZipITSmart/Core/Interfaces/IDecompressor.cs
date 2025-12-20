using System;
using System.Collections.Generic;
using System.Text;
using ZipITSmart.Models;

namespace ZipITSmart.Core.Interfaces
{
    public interface IDecompressor
    {
        CompressionResult Decompress(string inputPath, string outputPath);
    }
}
