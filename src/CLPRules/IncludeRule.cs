using System;
using System.Collections.Generic;
using System.Dynamic;
using CLPActions;
using CLPClasses;
using CLPInterfaces;

namespace CLPRules
{
    public class IncludeRule : BaseRule, IRule
    {
        public IncludeRule()
        {
            RuleType = "IncludeRule";
        }

        public IncludeRule(string comparisonOperator, string comparisonType, object compareRuleObject,
            bool expectedResult)
        {
            ComparisonOperator = comparisonOperator;
            ComparisonType = comparisonType;
            CompareRuleObject = compareRuleObject;
            ExpectedResult = expectedResult;
            RuleType = "IncludeRule";
        }

        public void Apply(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            IncludeAction.Execute(src, ref dest);
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