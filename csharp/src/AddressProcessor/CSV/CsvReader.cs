using System;
using System.IO;

namespace AddressProcessing.CSV
{
    public class CsvReader : ICsvReader
    {
        private readonly TextReader textReader;

        public CsvReader(TextReader textReader)
        {
            this.textReader = textReader;
        }

        public string[] ReadLine()
        {
            var readLine = textReader.ReadLine();
            if (!string.IsNullOrEmpty(readLine))
            {
                return readLine.Split(new[] { Constants.CsvSeparator }, StringSplitOptions.None);
            }
            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposing)
        {
            if (isdisposing && textReader != null)
            {
                textReader.Dispose();
            }
        }
    }
}