using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Encoder.Encoding.Tests
{
    [TestClass()]
    public class T9TextEncoderTests
    {
        [TestMethod()]
        public void T9TextEncoder_EncodeNullTest()
        {
            var encoder = new T9TextEncoder();
            Assert.AreEqual(null, encoder.Encode(null));
        }

        [TestMethod()]
        public void T9TextEncoder_EncodeEmptyTest()
        {
            var encoder = new T9TextEncoder();
            Assert.AreEqual("", encoder.Encode(""));
        }

        [TestMethod()]
        public void T9TextEncoder_EncodeABCTest()
        {
            var encoder = new T9TextEncoder();
            Assert.AreEqual("2 22 222", encoder.Encode("abc"));
        }

        [TestMethod()]
        public void T9TextEncoder_EncodeSpacesTest()
        {
            var encoder = new T9TextEncoder();
            Assert.AreEqual("0 0", encoder.Encode("  "));
        }

        [TestMethod()]
        public void T9TextEncoder_EncodeLastSpaceTest()
        {
            var encoder = new T9TextEncoder();
            Assert.AreEqual("990", encoder.Encode("x "));
        }

        [TestMethod()]
        public void T9TextEncoder_EncodeHelloWorldTest()
        {
            var encoder = new T9TextEncoder();
            Assert.AreEqual("4433555 555666096667775553", encoder.Encode("hello world"));
        }
    }
}