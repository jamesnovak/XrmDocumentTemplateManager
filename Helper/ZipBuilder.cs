using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;

namespace Futurez.Xrm.Tools
{
    public class ZipBuilder
    {
        public byte[] zipBytes(Dictionary<string, byte[]> dictFiles)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
                {
                    foreach (var fileBytes in dictFiles) {

                        var file = archive.CreateEntry(fileBytes.Key);
                        using (var entryStream = file.Open())
                        using (var streamWriter = new BinaryWriter(entryStream))
                        {
                            byte[] bytes = fileBytes.Value;
                            streamWriter.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
                byte[] zipByte;
                try
                {
                    zipByte = stream.ToArray();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return zipByte;
            }
        }
    }
}
