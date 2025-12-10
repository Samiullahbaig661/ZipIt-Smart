using System;
using System.Collections.Generic;
using System.Text;
using ZipITSmart.Models;

namespace ZipITSmart.Core.Archive
{
    public class ArchiveHeader
    {
        public const string Magic = "HUF1";   

        public int Version { get; set; } = 1;
        public ArchiveType Type { get; set; }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Magic);
            writer.Write(Version);
            writer.Write((int)Type);
        }

        public static ArchiveHeader Read(BinaryReader reader)
        {
            string magic = reader.ReadString();
            if (magic != Magic)
                throw new InvalidDataException("Invalid archive format");

            int version = reader.ReadInt32();
            ArchiveType type = (ArchiveType)reader.ReadInt32();

            return new ArchiveHeader
            {
                Version = version,
                Type = type
            };
        }

        public static ArchiveType PeekType(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            using (var br = new BinaryReader(fs))
            {
                string magic = new string(br.ReadChars(4));
                if (magic != "HUF1")
                    throw new Exception("Invalid archive file");

                return (ArchiveType)br.ReadByte();
            }
        }
    }
}
