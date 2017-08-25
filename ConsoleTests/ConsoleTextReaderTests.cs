using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Encoder.Input.Tests
{
    [TestClass()]
    public class ConsoleTextReaderTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConsoleTextReader_ConstructorWithNullParameterTest()
        {
            var reader = new ConsoleTextReader(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ConsoleTextReader_ReadNonIntegerCountTest()
        {
            var reader = new ConsoleTextReader(() => "r");
            reader.Read().ToArray();
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void ConsoleTextReader_ReadTooBigCountTest()
        {
            var reader = new ConsoleTextReader(() => long.MaxValue.ToString());
            reader.Read().ToArray();
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ConsoleTextReader_ReadNegativeCountTest()
        {
            var reader = new ConsoleTextReader(() => "-1");
            reader.Read().ToArray();
        }

        [TestMethod()]
        public void ConsoleTextReader_ReadCorrectInputTest()
        {
            int i = 0;
            string[] data = { "2", "cat", "dog" };
            var reader = new ConsoleTextReader(() => data[i++]);
            var result = reader.Read().ToArray();

            string[] expected = { "cat", "dog" };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}