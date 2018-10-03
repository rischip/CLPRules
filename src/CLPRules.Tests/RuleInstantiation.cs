using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CLPRules.Tests
{
    [TestClass]
    public class RuleInstantiation
    {
        [DataTestMethod]
        [DataRow("..\\..\\TestData\\RulesBuilder.json")]
        public void InstantiateRuleList(string path)
        {
            var file = new FileInfo(path);
            var json = File.ReadAllText(file.FullName);

            var activeRuleSets = RuleInstantiations.ParseRuleSets(json);

            var ruleSet = new RuleList {RuleSets = activeRuleSets};
        }

        [DataTestMethod]
        [DataRow("..\\..\\TestData\\RulesBuilder.json")]
        public void InstantiateData(string path)
        {
            var file = new FileInfo(path);
            var json = File.ReadAllText(file.FullName);

            var activeDataSets = RuleInstantiations.ParseDataSet(json);
        }

        [TestMethod]
        public void SerializeRules()
        {
            var rule1 = new IncludeRule
            {
                ComparisonOperator = "==",
                ComparisonType = "int",
                CompareRuleObject = new KeyValuePair<string, object>("ShpId", "13"),
                ExpectedResult = false
            };
            var rule2 = new IncludeRule
            {
                ComparisonOperator = "==",
                ComparisonType = "int",
                CompareRuleObject = new KeyValuePair<string, object>("ShpId", "14"),
                ExpectedResult = false
            };
            var rule3 = new ExcludeRule
            {
                ComparisonOperator = "!=",
                ComparisonType = "int",
                CompareRuleObject = new KeyValuePair<string, object>("ShpId", "13"),
                ExpectedResult = false
            };
            var rule4 = new ErrorCheckRule
            {
                ComparisonOperator = ">",
                ComparisonType = "int",
                CompareRuleObject = new KeyValuePair<string, object>("ShpId", "19"),
                ExpectedResult = false
            };
            var ruleSet = new RuleSet();
            ruleSet.RuleSets.Add(rule1);
            ruleSet.RuleSets.Add(rule2);

            var ruleSet2 = new RuleSet();
            ruleSet2.RuleSets.Add(rule3);

            var ruleSet3 = new RuleSet();
            ruleSet3.RuleSets.Add(rule4);

            var ruleSets = new List<RuleSet> {ruleSet, ruleSet2, ruleSet3};

            var json = JsonConvert.SerializeObject(ruleSets);
        }
    }
}