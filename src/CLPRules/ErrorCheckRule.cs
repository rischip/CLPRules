using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using CLPInterfaces;
using Microsoft.Build.Framework;
using Newtonsoft.Json.Linq;

namespace CLPRules
{
    public class ErrorCheckRule : BaseRule, IRule, IErrorCheck //, IAlwaysExecute
    {
        public ErrorCheckRule()
        {
            RuleType = "ErrorCheckRule";
        }

        public ErrorCheckRule(string comparisonOperator, string comparisonType, object compareRuleObject,
            bool expectedResult)
        {
            ComparisonOperator = comparisonOperator;
            ComparisonType = comparisonType;
            CompareRuleObject = compareRuleObject;
            ExpectedResult = expectedResult;
            RuleType = "ErrorCheckRule";
        }

        [Required] public override string ErrorMessage { get; set; }

        public void Apply(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            var message =
                $"The error check rule reported the following error in the data. The rule params are ComparisonOperator {ComparisonOperator}, " +
                $"ComparisonType {ComparisonType}, CompareRuleObject Field {((JObject) CompareRuleObject).Properties().First().Value}, CompareRuleObject Value {((JObject) CompareRuleObject).Properties().Last().Value}, CompareSourceObject {CompareSourceObject}, " +
                $"ExpectedResult {ExpectedResult}, EvaluationResult {EvaluationResult}.";
            throw new ErrorCheckException(ErrorMessage + " " + message);

            //ErrorCheckAction.Execute(src, ref dest);
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
            ErrorMessage = baseRule.ErrorMessage;
            RuleType = baseRule.RuleType;
        }
    }

    public class ErrorCheckException : Exception
    {
        public ErrorCheckException()
        {
        }

        public ErrorCheckException(string message)
        {
            Message = message;
        }

        public override string Message { get; }
    }
}