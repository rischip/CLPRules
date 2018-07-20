using System;
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
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(UInt32.MaxValue, UInt32.MaxValue));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(UInt32.MinValue, UInt32.MaxValue));
        }
        [TestMethod]
        public void TestLessThanOrEqualToInt64()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(Int64.MaxValue, Int64.MaxValue));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(Int64.MinValue, Int64.MaxValue));
        }
        [TestMethod]
        public void TestLessThanOrEqualToUInt64()
        {
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(UInt64.MaxValue, UInt64.MaxValue));
            Assert.IsTrue(LessThanOrEqualToComparison.LessThanOrEqualTo(UInt64.MinValue, UInt64.MaxValue));
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
            Byte a = Convert.ToByte("1");
            Byte b = Convert.ToByte("2");
            Byte c = Convert.ToByte("1");

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
