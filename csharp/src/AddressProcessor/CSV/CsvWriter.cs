using System;
using System.IO;

namespace AddressProcessing.CSV
{
    public class CsvWriter : ICsvWriter
    {
        private readonly TextWriter textWriter;

        public CsvWriter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public void Write(params string[] columns)
        {
            var newLine = string.Join(Constants.CsvSeparator, columns);
            textWriter.WriteLine(newLine);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposing)
        {
            if (isdisposing && textWriter != null)
            {
                textWriter.Dispose();
            }
        }
    }
}