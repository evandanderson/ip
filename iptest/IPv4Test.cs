using ip;

namespace iptest
{
    [TestClass]
    public class IPv4Test
    {
        [TestMethod]
        public void TestMaxToInt()
        {
            Assert.AreEqual(4294967295, IPv4.ToUInt32("255.255.255.255"));
        }

        [TestMethod]
        public void TestMaxToString()
        {
            IPv4 ip = new("255.255.255.255");
            Assert.AreEqual("255.255.255.255", ip.ToString());
        }

        [TestMethod]
        public void TestMinToInt()
        {
            Assert.AreEqual((uint)0, IPv4.ToUInt32("0.0.0.0"));
        }

        [TestMethod]
        public void TestMinToString()
        {
            IPv4 ip = new();
            Assert.AreEqual("0.0.0.0", ip.ToString());
        }

        [TestMethod]
        public void TestToInt()
        {
            Assert.AreEqual((uint)65280, IPv4.ToUInt32("0.0.255.0"));
        }

        [TestMethod]
        public void TestHexToString()
        {
            IPv4 ip = new(0xFF0000);
            Assert.AreEqual("0.255.0.0", ip.ToString());
        }

        [TestMethod]
        public void TestInvalid()
        {
            Assert.ThrowsException<ArgumentException>(() => new IPv4("1.12.5669"));
        }
    }
}