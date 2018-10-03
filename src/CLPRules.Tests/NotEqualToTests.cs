using System;
using CLPComparisons;
using CLPInterfaces;
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
            Assert.IsFalse(ruleComparer.NotEqualTo<bool>(false, false));
            Assert.IsTrue(ruleComparer.NotEqualTo<bool>(false, true));
        }

        [TestMethod]
        public void TestNotEqualToString()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(";wpioemcopiwecmwc", ";wpioemcopiwecmwC"));
        }

        [TestMethod]
        public void TestNotEqualToDate()
        {
            var now = DateTime.Now;
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(now, "09/06/2018 10:21:00.000"));
            Assert.IsFalse(NotEqualToComparison.NotEqualTo(DateTime.Parse("09/06/2018 10:21:00.000"),
                "09/06/2018 10:21:00.000"));
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(DateTime.Today.AddHours(1), "today"));
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(DateTime.Today, "today -1"));
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(DateTime.Today, "today +1"));
        }

        [TestMethod]
        public void TestNotEqualToInt()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(1289, 1290));
        }

        [TestMethod]
        public void TestNotEqualToUInt32()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(uint.MaxValue, uint.MinValue));
        }

        [TestMethod]
        public void TestNotEqualToInt64()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(long.MaxValue, long.MinValue));
        }

        [TestMethod]
        public void TestNotEqualToUInt64()
        {
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(ulong.MaxValue, ulong.MinValue));
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
            var a = Convert.ToByte("1");
            var b = Convert.ToByte("2");

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

        [TestMethod]
        public void TestNotEqualToNull()
        {
            //Assert.IsTrue(EqualToComparison.EqualTo(null, "1"));
            Assert.IsTrue(NotEqualToComparison.NotEqualTo(null, ";wpioemcopiwecmwC"));
        }
    }
}