using System;
using System.Collections.Generic;
using System.Text;

namespace ZipITSmart.Models
{
    public class CompressionResult
    {
        public long OriginalSize { get; set; }
        public long CompressedSize { get; set; }

        public double CompressionRatio
        {
            get
            {
                if (OriginalSize == 0) return 0;
                return (double)CompressedSize / OriginalSize;
            }
        }
    }
}
