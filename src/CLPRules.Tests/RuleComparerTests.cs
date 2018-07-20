using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class RuleComparerTests
    {
        [DataTestMethod]
        [DataRow("string", "!=", "3", "4")]
        [DataRow("string", "==", "4", "4")]
        [DataRow("int", "!=", "3", "4")]
        [DataRow("int", "==", "4", "4")]
        [DataRow("int", ">=", "5", "4")]
        public void TestRules(string valueType, string comparisonType, object valA, object valB)
        {
            IRuleComparer ruleComparer = new RuleComparer();

            switch (valueType.ToLower())
            {
                case "string":
                    switch (comparisonType.ToLower())
                    {
                        case "!=":
                            Assert.IsTrue(ruleComparer.NotEqualTo<string>(valA, valB));
                            break;
                        case "==":
                            Assert.IsTrue(ruleComparer.EqualTo<string>(valA, valB));
                            break;
                        default:
                            break;
                    }
                    break;
                case "int":
                    switch (comparisonType)
                    {
                        case "!=":
                            Assert.IsTrue(ruleComparer.NotEqualTo<int>(valA, valB));
                            break;
                        case "==":
                            Assert.IsTrue(ruleComparer.EqualTo<int>(valA, valB));
                            break;
                        case ">=":
                            Assert.IsTrue(ruleComparer.GreaterThanOrEqualTo<int>(valA, valB));
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

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
