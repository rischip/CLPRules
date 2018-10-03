using System;
using CLPComparisons;
using CLPInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class LessThanOrEqualToTests
    {
        [TestMethod]
        public void TestRuleLessThanOrEqualToInt()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.LessThanOrEqualTo<int>(9, 10));
            Assert.IsTrue(ruleComparer.LessThanOrEqualTo<int>(12, 12));
            Assert.IsFalse(ruleComparer.LessThanOrEqualTo<int>(13, 12));
        }

        [TestMethod]
        public void TestLessThanOrEqualToInt()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(1289, 1290));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(1289, 1289));
        }

        [TestMethod]
        public void TestLessThanOrEqualToUInt32()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(uint.MaxValue, uint.MaxValue));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(uint.MinValue, uint.MaxValue));
        }

        [TestMethod]
        public void TestLessThanOrEqualToInt64()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(long.MaxValue, long.MaxValue));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(long.MinValue, long.MaxValue));
        }

        [TestMethod]
        public void TestLessThanOrEqualToUInt64()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(ulong.MaxValue, ulong.MaxValue));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(ulong.MinValue, ulong.MaxValue));
        }

        [TestMethod]
        public void TestLessThanOrEqualToDouble()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(1289.00, 1290.00));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(1289.00, 1289.00));
        }

        [TestMethod]
        public void TestLessThanOrEqualToFloat()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(1289.00F, 1290.00F));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(1289.00F, 1289.00F));
        }

        [TestMethod]
        public void TestLessThanOrEqualToChar()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo('h', 'h'));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo('g', 'h'));
        }

        [TestMethod]
        public void TestLessThanOrEqualToByte()
        {
            var a = Convert.ToByte("1");
            var b = Convert.ToByte("2");
            var c = Convert.ToByte("1");

            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(a, b));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(a, c));
        }

        [TestMethod]
        public void TestLessThanOrEqualToIntNegative()
        {
            Assert.IsFalse(LessThanOrEqualToComparison.LessThanOrEqualTo(2, 1));
        }
    }
}