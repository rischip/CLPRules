using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class NotEqualToTests
    {
        [TestMethod]
        public void TestRuleNotEqualToBool()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsFalse(ruleComparer.NotEqualTo<bool>((object)false, (object)false));
            Assert.IsTrue(ruleComparer.NotEqualTo<bool>((object)false, (object)true));
        }
        [TestMethod]
        public void TestNotEqualToString()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(";wpioemcopiwecmwc", ";wpioemcopiwecmwC"));
        }
        [TestMethod]
        public void TestNotEqualToInt()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(1289, 1290));
        }
        [TestMethod]
        public void TestNotEqualToUInt32()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(UInt32.MaxValue, UInt32.MinValue));
        }
        [TestMethod]
        public void TestNotEqualToInt64()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(Int64.MaxValue, Int64.MinValue));
        }
        [TestMethod]
        public void TestNotEqualToUInt64()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(UInt64.MaxValue, UInt64.MinValue));
        }
        [TestMethod]
        public void TestNotEqualToDouble()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(1289.00, 1290.00));
        }
        [TestMethod]
        public void TestNotEqualToFloat()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(1289.00F, 1290.00F));
        }
        [TestMethod]
        public void TestNotEqualToChar()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo('h', 'g'));
        }
        [TestMethod]
        public void TestNotEqualToByte()
        {
            Byte a = Convert.ToByte("1");
            Byte b = Convert.ToByte("2");

            Assert.IsTrue(NotEqualToComparison.NotEqualTo(a, b));
        }
        [TestMethod]
        public void TestNotEqualToBool()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(true, false));
            Assert.IsFalse(NotEqualToComparison.NotEqualTo(false, false));
        }
        [TestMethod]
        public void TestNotEqualToStringNegative()
        {
            Assert.IsFalse(NotEqualToComparison.NotEqualTo(";wpioemcopiwecmwc", ";wpioemcopiwecmwc"));
        }
        [TestMethod]
        public void TestNotEqualToIntNegative()
        {
            Assert.IsFalse(NotEqualToComparison.NotEqualTo(1, 1));
        }
    }
}
