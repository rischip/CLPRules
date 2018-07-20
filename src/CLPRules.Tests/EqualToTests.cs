using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class EqualToTests
    {
        [TestMethod]
        public void TestRuleEqualToBool()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.EqualTo<bool>((object)false, (object)false));
            Assert.IsFalse(ruleComparer.EqualTo<bool>((object)false, (object)true));
        }
        [TestMethod]
        public void TestEqualToString()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(";wpioemcopiwecmwc", ";wpioemcopiwecmwc"));
        }
        [TestMethod]
        public void TestEqualToInt()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(1289, 1289));
        }
        [TestMethod]
        public void TestEqualToUInt32()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(UInt32.MaxValue, UInt32.MaxValue));
        }
        [TestMethod]
        public void TestEqualToInt64()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(Int64.MaxValue, Int64.MaxValue));
        }
        [TestMethod]
        public void TestEqualToUInt64()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(UInt64.MaxValue, UInt64.MaxValue));
        }
        [TestMethod]
        public void TestEqualToDouble()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(1289.00, 1289.00));
        }
        [TestMethod]
        public void TestEqualToFloat()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(1289.00F, 1289.00F));
        }
        [TestMethod]
        public void TestEqualToChar()
        {
            Assert.IsTrue(EqualToComparison.EqualTo('h', 'h'));
        }
        [TestMethod]
        public void TestEqualToByte()
        {
            Byte a = Convert.ToByte("1");
            Byte b = Convert.ToByte("1");

            Assert.IsTrue(EqualToComparison.EqualTo(a, b));
        }
        [TestMethod]
        public void TestEqualToBool()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(true, true));
            Assert.IsTrue(EqualToComparison.EqualTo(false, false));
        }
        [TestMethod]
        public void TestEqualToStringNegative()
        {
            Assert.IsFalse(EqualToComparison.EqualTo(";wpioemcopiwecmwc", "wpioemcopiwecmwc"));
        }
        [TestMethod]
        public void TestEqualToIntNegative()
        {
            Assert.IsFalse(EqualToComparison.EqualTo(1, 2));
        }
    }
}
