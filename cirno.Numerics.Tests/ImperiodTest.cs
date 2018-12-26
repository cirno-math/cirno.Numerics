using Microsoft.VisualStudio.TestTools.UnitTesting;

using num = cirno.Numerics.ImperiodicNumber;
using bigint = System.Numerics.BigInteger;
using System;

namespace cirno.Numerics.Tests
{
    [TestClass]
    public class ImperiodTest
    {
        [TestMethod]
        public void TestNumberCreating()
        {
            new num(1);
            new num(2);
            new num(3);
            new num(100);

            new num(-1);
            new num((uint)0x14);
            new num((ushort)0x24);

            new num(long.MaxValue - 1);
            new num(long.MaxValue);
            new num(long.MinValue);

            new num(1.33f);
            new num(1.33);
            new num(1.33m);

            new num(bigint.Parse("1234567890"));
            new num(new bigint(10), new bigint(10));
            Assert.IsTrue(num.TryParse("3.14159265358979323846264338327950288", out _));

            new num(bigint.Parse("124314135135"), bigint.Parse("200"));

            TestSuccess(10, 1);
            TestSuccess(0, 1);
            TestSuccess(100313431, 100);
            TestSuccess(30, 3);
            TestSuccess(210, 21);
            TestSuccess(210, 42);
            TestSuccess(1, 128);
            TestSuccess(1, 625);
            TestSuccess(1, bigint.Parse("100000000000000000000000000000000"));
        }

        void TestSuccess(bigint numerator, bigint denominator)
        {
            try
            {
                new num(numerator, denominator);
            }
            catch(Exception ex)
            {
                Assert.Fail("Should not fail for: {0}, {1} by {2}", numerator, denominator, ex);
            }
        }

        [TestMethod]
        public void TestNumberCreateFailing()
        {
            TestFail("a");
            TestFail("10f");
            TestFail("10.0.0");
            TestFail("1e+10");
            TestFail("1.0e+10");

            TestFail(1, 3);
            TestFail(10, 3);
            TestFail(1, 7);
            TestFail(2, 6);
        }

        void TestFail(string text)
            => Assert.IsFalse(num.TryParse(text, out _), "Expected false, but true for: {0}", text);

        void TestFail(bigint numerator, bigint denominator)
            => Assert.ThrowsException<ArgumentException>(
                () => new num(numerator, denominator),
                "Expected fail, but success for: {0}, {1}",
                numerator,
                denominator);

        [TestMethod]
        public void TestEquality()
        {
            var a = new num(10);
            var b = new num(10f);
            Assert.AreEqual(a, b);
            Assert.IsTrue(a == b);
            Assert.IsFalse(a != b);
        }

        [TestMethod]
        public void TestArithmeticExpression()
        {
            {
                num a = num.Add(1, 2);
                num b = 3;
                Assert.AreEqual(a, b);
            }
            {
                num a = num.Multiply(3.14, 10);
                num b = 31.4;
                Assert.AreEqual(a, b);
            }
            {
                num a = num.Multiply(3.14, 3.14);
                num b = 9.8596;
                Assert.AreEqual(a, b);
            }
            {
                Assert.IsTrue(num.TryParse("57998468644974352708871490365213079390068504521588799445473981772354729547806"
                    , out var r));

                num p = num.Add(num.Add(num.Multiply(3, num.Pow(r, 2)), num.Multiply(2, r)), 7331);
                num q = num.Add(num.Add(num.Multiply(17, num.Pow(r, 2)), num.Multiply(18, r)), 1339);
                num n = num.Multiply(p, q);
                Assert.IsTrue(num.TryParse("577080346122592746450960451960811644036616146551114466727848435471345510503600476295033089858879506008659314011731832530327234404538741244932419600335200164601269385608667547863884257092161720382751699219503255979447796158029804610763137212345011761551677964560842758022253563721669200186956359020683979540809"
                    , out var expected));

                Assert.AreEqual(n, expected);
            }
        }
    }
}
