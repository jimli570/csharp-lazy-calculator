using NUnit.Framework;
using System.Collections.Generic;
using Calculator.fileReader;

namespace FileReaderTest
{
    [TestFixture]
    class FileReaderTest
    {
        private IReader<string> m_fileReader;

        [SetUp]
        public void Setup()
        {
            m_fileReader = new FileReader();
        }

        [TestCase("math_data_1.txt", new[] { "A add 2", "A add 3", "print A", "B add 5", "B substract 2", "print B", "A add 1", "print A" })]
        [TestCase("math_data_2.txt", new[] { "a add 10", "b add a", "b add 1", "print b" })]
        [TestCase("math_data_3.txt", new[] { "result add revenue", "result substract costs", "revenue add 200",
            "costs add salaries", "salaries add 20", "salaries multiply 5", "costs add 10", "print result" })]
        public void ReaderTest(string path, string[] expected)
        {
            List<string> lines = m_fileReader.Read( path );

            Assert.That(lines, Is.EqualTo(expected));
        }

        [Test]
        public void ReaderNoneExistingTest()
        {
            Assert.Throws(typeof(System.IO.FileNotFoundException), () => m_fileReader.Read("noneExistingFile.txt"));
        }
    }
}
