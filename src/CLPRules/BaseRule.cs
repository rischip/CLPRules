using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CLPClasses;
using CLPComparisons;
using Microsoft.Build.Framework;
using Newtonsoft.Json.Linq;

namespace CLPRules
{
    public class BaseRule
    {
        public BaseRule()
        {
        }

        public BaseRule(string comparisonOperator, string comparisonType, object compareRuleObject, bool expectedResult)
        {
            RuleType = "IncludeRule";
            ComparisonOperator = comparisonOperator;
            ComparisonType = comparisonType;
            CompareRuleObject = compareRuleObject;
            ExpectedResult = expectedResult;
        }

        public virtual string ErrorMessage { get; set; }

        [Required] public string ComparisonOperator { get; set; }

        [Required] public string ComparisonType { get; set; }

        [Required] public object CompareRuleObject { get; set; }

        [Required] public object CompareSourceObject { get; set; }

        public bool EvaluationResult { get; set; }

        [Required] public bool ExpectedResult { get; set; }

        [Required] public string RuleType { get; set; }

        public virtual void MapFromBase(BaseRule baseRule)
        {
        }

        public bool Evaluate()
        {
            var comparisonExecutor = new ComparisonExecutor(ComparisonOperator, ComparisonType,
                ((JObject) CompareRuleObject).Properties().Last().Value.ToString(), CompareSourceObject);
            EvaluationResult = comparisonExecutor.ExecuteComparison();
            return EvaluationResult;
        }

        public void Configure(IDictionary<string, object> src)
        {
            var jObject = JObject.FromObject(CompareRuleObject);

            foreach (var property in jObject) Debug.WriteLine(property.Key + " - " + property.Value);

            var propertyName = jObject.Properties().First().Value.ToString();

            var sourceValue = PropertyUtils.GetPropertyValueByName(src, propertyName);

            CompareSourceObject = sourceValue;
        }
    }
}