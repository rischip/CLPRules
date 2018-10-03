using System;
using CLPComparisons;
using CLPInterfaces;
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
            Assert.IsTrue(ruleComparer.EqualTo<bool>(false, false));
            Assert.IsFalse(ruleComparer.EqualTo<bool>(false, true));
        }

        [TestMethod]
        public void TestEqualToString()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(";wpioemcopiwecmwc", ";wpioemcopiwecmwc"));
        }

        [TestMethod]
        public void TestEqualToDate()
        {
            var now = DateTime.Now;
            Assert.IsFalse(EqualToComparison.EqualTo(now, "09/06/2018 10:21:00.000"));
            Assert.IsTrue(EqualToComparison.EqualTo(DateTime.Parse("09/06/2018 10:21:00.000"),
                "09/06/2018 10:21:00.000"));
            Assert.IsTrue(EqualToComparison.EqualTo(DateTime.Today, "today"));
            Assert.IsFalse(EqualToComparison.EqualTo(DateTime.Today, "today 11:00:00.000"));
            Assert.IsFalse(EqualToComparison.EqualTo(DateTime.Today, "today@ 15:00:00.000"));
        }

        [TestMethod]
        public void TestEqualToInt()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(1289, 1289));
        }

        [TestMethod]
        public void TestEqualToUInt32()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(uint.MaxValue, uint.MaxValue));
        }

        [TestMethod]
        public void TestEqualToInt64()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(long.MaxValue, long.MaxValue));
        }

        [TestMethod]
        public void TestEqualToUInt64()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(ulong.MaxValue, ulong.MaxValue));
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
            var a = Convert.ToByte("1");
            var b = Convert.ToByte("1");

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

        [TestMethod]
        public void TestEqualToNull()
        {
            Assert.IsTrue(EqualToComparison.EqualTo(null, null));
        }
    }
}