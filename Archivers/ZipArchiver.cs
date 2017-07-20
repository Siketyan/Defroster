using System;
using Defroster.Interfaces;
using Ionic.Zip;
using Defroster.Exceptions;

namespace Defroster.Archivers
{
    public class ZipArchiver : IArchiver
    {
        public string Name => "Zip Archiver";
        public string[] Extensions => new string[] { "zip", "jar", "docx", "xlsx", "pptx" };

        public event EventHandler<int> ProgressChanged;

        public void Defrost(string src, string dest)
        {
            try
            {
                using (var zip = new ZipFile(src))
                {
                    zip.ExtractProgress += OnExtractProgress;
                    zip.ExtractAll(dest);
                }
            }
            catch (ZipException e)
            {
                throw new DefrostException(e.Message);
            }
        }

        private void OnExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            ProgressChanged?.Invoke(this, (int)(e.BytesTransferred / e.TotalBytesToTransfer) * 100);
        }
    }
}