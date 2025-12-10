using System;
using System.Collections.Generic;
using System.Text;
using ZipITSmart.Models;

namespace ZipITSmart.Core.Archive
{
    public static class ArchiveReader
    {
        public static ArchiveType GetArchiveType(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs))
            {
                ArchiveHeader header = ArchiveHeader.Read(reader);
                return header.Type;
            }
        }
    }
}
