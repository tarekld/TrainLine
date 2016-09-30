using System;
using System.IO;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */
    /*
     added empty constructor for maintaining  backwards compatibility.
     added constructor with two parameters ICsvReader and ICsvWriter
     remove  public bool Read(string column1, string column2) because is not used and wrongly implemented
     */

    public class CSVReaderWriter
    {
        const int FirstColumn = 0;
        const int SecondColumn = 1;

        private ICsvReader csvReader;
        private ICsvWriter csvWriter;

        [Flags]
        public enum Mode { Read = 1, Write = 2 };

        public CSVReaderWriter()
        {

        }
        public CSVReaderWriter(ICsvReader csvReader, ICsvWriter csvWriter)
        {
            this.csvReader = csvReader;
            this.csvWriter = csvWriter;
        }
        public void Open(string fileName, Mode mode)
        {
            if (mode == Mode.Read)
            {
                csvReader = new CsvReader(File.OpenText(fileName));
                return;
            }
            else if (mode == Mode.Write)
            {
                var fileInfo = new FileInfo(fileName);
                csvWriter = new CsvWriter(fileInfo.CreateText());
                return;
            }
            throw  new ArgumentException("invalid mode");
        }

        public void Write(params string[] columns)
        {
            if (csvWriter == null)
            {
                throw new ApplicationException("csvWriter is null");
            }
            csvWriter.Write(columns);
        }

        public bool Read(out string column1, out string column2)
        {
            if (csvReader == null)
            {
                throw new ApplicationException("csvReader is null");
            }
            string[] columns = csvReader.ReadLine();
            if (columns != null && columns.Length >= 2)
            {
                column1 = columns[FirstColumn];
                column2 = columns[SecondColumn];
                return true;
            }
            column1 = column2 = null;
            return false;
        }


        public void Close()
        {
            if (csvWriter != null)
            {
                csvWriter.Dispose();
            }

            if (csvReader != null)
            {
                csvReader.Dispose();
            }
        }
    }
}
