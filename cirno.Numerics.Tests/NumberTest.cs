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

        [TestMethod]
        public void TestExpressionStringBinary()
        {
            num a = 1;
            Assert.AreEqual("1", a.ToExactExpressionString());

            num b = a / 3;
            Assert.AreEqual("1 / 3", b.ToExactExpressionString());

            num c = b * 2;
            Assert.AreEqual("2 / 3", c.ToExactExpressionString());

            num d = c + 2;
            Assert.AreEqual("8 / 3", c.ToExactExpressionString());

            num e = d * 3;
            Assert.AreEqual("8", c.ToExactExpressionString());

            Assert.AreEqual(8, e);
        }

        [TestMethod]
        public void TestExpressionStringPow()
        {
            num a = 12;
            Assert.AreEqual("12", a.ToExactExpressionString());

            num b = a.Pow(2);
            Assert.AreEqual("144", a.ToExactExpressionString());

            num c = b.Sqrt3();
            Assert.AreEqual("2 * sqrt3(21)", a.ToExactExpressionString());

            num d = c.Sqrt();
            Assert.AreEqual("sqrt(2 * sqrt3(21))", a.ToExactExpressionString());
        }
    }
}
