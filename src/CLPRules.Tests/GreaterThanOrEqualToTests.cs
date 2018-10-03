using System;
using CLPComparisons;
using CLPInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class GreaterThanOrEqualToTests
    {
        [TestMethod]
        public void TestRuleGreaterThanOrEqualToInt()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.GreaterThanOrEqualTo<int>(12, 10));
            Assert.IsTrue(ruleComparer.GreaterThanOrEqualTo<int>(12, 12));
            Assert.IsFalse(ruleComparer.GreaterThanOrEqualTo<int>(10, 12));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToInt()
        {
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(1289, 128));
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(1289, 1289));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToUInt32()
        {
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(uint.MaxValue, uint.MinValue));
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(uint.MaxValue, uint.MaxValue));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToInt64()
        {
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(long.MaxValue, long.MinValue));
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(long.MaxValue, long.MaxValue));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToUInt64()
        {
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(ulong.MaxValue, ulong.MinValue));
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(ulong.MaxValue, ulong.MaxValue));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToDouble()
        {
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(1289.00, 128.00));
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(1289.00, 1289.00));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToFloat()
        {
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(1289.00F, 128.00F));
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(1289.00F, 1289.00F));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToChar()
        {
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo('h', 'g'));
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo('g', 'g'));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToByte()
        {
            var a = Convert.ToByte("2");
            var b = Convert.ToByte("1");
            var c = Convert.ToByte("2");

            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(a, b));
            Assert.IsTrue(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(a, c));
        }

        [TestMethod]
        public void TestGreaterThanOrEqualToIntNegative()
        {
            Assert.IsFalse(GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(1, 2));
        }
    }
}