using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone.Output;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Output.Tests
{
    [TestClass()]
    public class CaseNumberDecoratorTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CaseNumberDecorator_ConstructorWithNullParameterTest()
        {
            var instance = new CaseNumberDecorator(null);
        }

        [TestMethod()]
        public void CaseNumberDecorator_WriteNullTest()
        {
            var nestedWriter = new Mock<ITextWriter>();
            nestedWriter.Setup(x => x.Write(It.IsAny<string>())).Callback((string data) => Assert.IsTrue("Case #1: ".Equals(data)));

            var writer = new CaseNumberDecorator(nestedWriter.Object);
            writer.Write(null);
        }

        [TestMethod()]
        public void CaseNumberDecorator_WriteTest()
        {
            var nestedWriter = new Mock<ITextWriter>();
            nestedWriter.Setup(x => x.Write(It.IsAny<string>())).Callback((string data) => Assert.IsTrue("Case #1: cat".Equals(data)));

            var writer = new CaseNumberDecorator(nestedWriter.Object);
            writer.Write("cat");
        }
    }
}