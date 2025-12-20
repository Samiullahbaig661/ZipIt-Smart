using System;
using System.Collections.Generic;
using System.Text;
using ZipITSmart.Models;

namespace ZipITSmart.Core.Interfaces
{
    public interface ICompressor
    {
        CompressionResult Compress(string inputPath, string outputPath);
    }
}
