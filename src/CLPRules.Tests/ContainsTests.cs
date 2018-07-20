using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class ContainsTests
    {
        [TestMethod]
        public void TestRuleContainsCI()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.ContainsCI<string>("wwecoimwciowmecowmicew", "wwecoimwcIOwmecowmicew"));
        }
        [TestMethod]
        public void TestRuleContainsCS()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.ContainsCS<string>("wwecoimwciowmecowmicew", "wwecoimwciowmecowmicew"));
        }
        [TestMethod]
        public void TestRuleNotContainsCI()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.NotContainsCI<string>("wecoimwciowmecowmicew", "wwecoimwcIOwmecowmicew"));
        }
        [TestMethod]
        public void TestRuleNotContainsCS()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.NotContainsCS<string>("wecoimwciowmecowmicew", "wwecoimwciowmecowmicew"));
        }
    }
}
