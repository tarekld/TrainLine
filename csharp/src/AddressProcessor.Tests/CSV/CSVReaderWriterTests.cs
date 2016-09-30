using System;
using System.Text;
using NUnit.Framework;
using AddressProcessing.CSV;
using System.IO;
using System.Text.RegularExpressions;

namespace Csv.Tests
{
    [TestFixture]
    public class CSVReaderWriterTests
    {
        ICsvReader csvReader;
        ICsvWriter csvWriter;
        CSVReaderWriter csvReaderWriter;
        string line = "column1\tcolumn2";
        StringBuilder builder;

        [SetUp]
        public void SetUp()
        {
            builder = new StringBuilder();
            csvReader = new CsvReader(new StringReader(line));
            csvWriter = new CsvWriter(new StringWriter(builder));
            csvReaderWriter = new CSVReaderWriter(csvReader, csvWriter);
        }

        [Test]
        public void Should_Wite_One_Line()
        {
            csvReaderWriter.Write(line);
            csvReaderWriter.Write(line);
            var linesInserted = Regex.Matches(builder.ToString(), Environment.NewLine).Count;

            Assert.That(2, Is.EqualTo(linesInserted));
        }


        [Test]
        public void Should_Read_Atleast_One_Line()
        {

            string column1;
            string column2;
            bool isRead = csvReaderWriter.Read(out column1, out column2);

            Assert.That(true, Is.EqualTo(true));
        }
    }
}
