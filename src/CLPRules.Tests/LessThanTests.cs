using System;
using CLPComparisons;
using CLPInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class LessThanTests
    {
        [TestMethod]
        public void TestRuleLessThanInt()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.LessThan<int>(9, 10));
            Assert.IsFalse(ruleComparer.LessThan<int>(13, 12));
        }

        [TestMethod]
        public void TestLessThanInt()
        {
            Assert.IsTrue(LessThanComparison.LessThan(1289, 1290));
        }

        [TestMethod]
        public void TestLessThanUInt32()
        {
            Assert.IsTrue(LessThanComparison.LessThan(uint.MinValue, uint.MaxValue));
        }

        [TestMethod]
        public void TestLessThanInt64()
        {
            Assert.IsTrue(LessThanComparison.LessThan(long.MinValue, long.MaxValue));
        }

        [TestMethod]
        public void TestLessThanUInt64()
        {
            Assert.IsTrue(LessThanComparison.LessThan(ulong.MinValue, ulong.MaxValue));
        }

        [TestMethod]
        public void TestLessThanDouble()
        {
            Assert.IsTrue(LessThanComparison.LessThan(1289.00, 1290.00));
        }

        [TestMethod]
        public void TestLessThanFloat()
        {
            Assert.IsTrue(LessThanComparison.LessThan(1289.00F, 1290.00F));
        }

        [TestMethod]
        public void TestLessThanChar()
        {
            Assert.IsTrue(LessThanComparison.LessThan('g', 'h'));
        }

        [TestMethod]
        public void TestLessThanByte()
        {
            var a = Convert.ToByte("1");
            var b = Convert.ToByte("2");

            Assert.IsTrue(LessThanComparison.LessThan(a, b));
        }

        [TestMethod]
        public void TestLessThanIntNegative()
        {
            Assert.IsFalse(LessThanComparison.LessThan(2, 1));
        }
    }
}