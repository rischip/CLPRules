using System;
using CLPComparisons;
using CLPInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class GreaterThanTests
    {
        [TestMethod]
        public void TestRuleGreaterThanInt()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.GreaterThan<int>(12, 10));
            Assert.IsFalse(ruleComparer.GreaterThan<int>(10, 12));
        }

        [TestMethod]
        public void TestGreaterThanInt()
        {
            Assert.IsTrue(GreaterThanComparison.GreaterThan(1289, 128));
        }

        [TestMethod]
        public void TestGreaterThanUInt32()
        {
            Assert.IsTrue(GreaterThanComparison.GreaterThan(uint.MaxValue, uint.MinValue));
        }

        [TestMethod]
        public void TestGreaterThanInt64()
        {
            Assert.IsTrue(GreaterThanComparison.GreaterThan(long.MaxValue, long.MinValue));
        }

        [TestMethod]
        public void TestGreaterThanUInt64()
        {
            Assert.IsTrue(GreaterThanComparison.GreaterThan(ulong.MaxValue, ulong.MinValue));
        }

        [TestMethod]
        public void TestGreaterThanDouble()
        {
            Assert.IsTrue(GreaterThanComparison.GreaterThan(1289.00, 128.00));
        }

        [TestMethod]
        public void TestGreaterThanFloat()
        {
            Assert.IsTrue(GreaterThanComparison.GreaterThan(1289.00F, 128.00F));
        }

        [TestMethod]
        public void TestGreaterThanChar()
        {
            Assert.IsTrue(GreaterThanComparison.GreaterThan('h', 'g'));
        }

        [TestMethod]
        public void TestGreaterThanByte()
        {
            var a = Convert.ToByte("2");
            var b = Convert.ToByte("1");

            Assert.IsTrue(GreaterThanComparison.GreaterThan(a, b));
        }

        [TestMethod]
        public void TestGreaterThanIntNegative()
        {
            Assert.IsFalse(GreaterThanComparison.GreaterThan(1, 2));
        }
    }
}