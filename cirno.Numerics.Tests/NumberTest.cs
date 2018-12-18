using Microsoft.VisualStudio.TestTools.UnitTesting;

using num = cirno.Numerics.Number;

namespace cirno.Numerics.Tests
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void TestBasic()
        {
            num a = 10;
            num b = 20;

            num expected = 30;
            num actual = a + b;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(30, actual);
            Assert.AreEqual(30f, actual);
            Assert.AreEqual(30.0, actual);
            Assert.AreEqual(30m, actual);
        }

        [TestMethod]
        public void TestSqrt()
        {
            num a = 81;
            num a_sqrt = a.Sqrt();
            Assert.AreEqual(9, a_sqrt);

            num b = 8;
            num b_sqrt = b.Sqrt();
            num b_sqrt_square = b_sqrt.Pow(2);
            Assert.AreEqual(b, b_sqrt_square);
        }
    }
}
