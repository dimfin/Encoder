using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.Encoding;
using MobilePhone.Input;
using MobilePhone.Output;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Program_ConstructorWithNullReaderParameterTest()
        {
            var p = new Program(null, new T9TextEncoder(), new ConsoleTextWriter());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Program_ConstructorWithNullEncoderParameterTest()
        {
            var p = new Program(new ConsoleTextReader(), null, new ConsoleTextWriter());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Program_ConstructorWithNullWriterParameterTest()
        {
            var p = new Program(new ConsoleTextReader(), new T9TextEncoder(), null);
        }

        [TestMethod()]
        public void Program_RunTest()
        {
            // get input data
            int i = 0;
            string[] inputData = { "3", null, "", " cat " };

            // mock the reader to read them
            var reader = new ConsoleTextReader(() => inputData[i++]);

            // standard encoder
            var encoder = new T9TextEncoder();

            // list to collect output data
            List<string> outputData = new List<string>();

            // mock the writer to collect data
            var nestedWriter = new Mock<ITextWriter>();
            nestedWriter.Setup(x => x.Write(It.IsAny<string>())).Callback((string s) => outputData.Add(s));
            var writer = new CaseNumberDecorator(nestedWriter.Object);

            // create a Program instance
            var p = new Program(reader, encoder, writer);

            // run it
            p.Run();

            // expected results
            List<string> expected = new List<string>
            {
                "Case #1: ",
                "Case #2: ",
                "Case #3: 0222 280"
            };

            // test results
            CollectionAssert.AreEqual(expected, outputData);
        }
    }
}