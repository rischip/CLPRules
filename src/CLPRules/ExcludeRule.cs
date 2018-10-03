using System;
using System.Collections.Generic;
using System.Dynamic;
using CLPActions;
using CLPInterfaces;

namespace CLPRules
{
    public class ExcludeRule : BaseRule, IRule
    {
        public ExcludeRule()
        {
            RuleType = "ExcludeRule";
        }

        public ExcludeRule(string comparisonOperator, string comparisonType, object compareRuleObject,
            bool expectedResult)
        {
            ComparisonOperator = comparisonOperator;
            ComparisonType = comparisonType;
            CompareRuleObject = compareRuleObject;
            ExpectedResult = expectedResult;
            RuleType = "ExcludeRule";
        }

        public void Apply(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            ExcludeAction.Execute(src, ref dest);
        }

        public override void MapFromBase(BaseRule baseRule)
        {
            if (baseRule.RuleType != RuleType)
                throw new Exception("Attempted instantiation of invalid rule type.");
            ComparisonOperator = baseRule.ComparisonOperator;
            ComparisonType = baseRule.ComparisonType;
            CompareRuleObject = baseRule.CompareRuleObject;
            CompareSourceObject = baseRule.CompareSourceObject;
            ExpectedResult = baseRule.ExpectedResult;
            RuleType = baseRule.RuleType;
        }
    }
}