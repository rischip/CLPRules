using System.Collections.Generic;
using System.Dynamic;
using Microsoft.Build.Framework;

namespace CLPInterfaces
{
    public interface IRule
    {
        [Required] string ComparisonOperator { get; set; }

        [Required] string ComparisonType { get; set; }

        [Required] object CompareRuleObject { get; set; }

        [Required] object CompareSourceObject { get; set; }

        bool EvaluationResult { get; set; }

        [Required] bool ExpectedResult { get; set; }

        bool Evaluate();
        void Apply(IDictionary<string, object> src, ref List<ExpandoObject> dest);
    }

    //public interface IRuleGroup
    //{
    //    List<Rule> RuleGroup { get; set; }
    //    bool Coalesce();
    //}
    //public interface IRuleSet
    //{
    //    List<IRuleGroup> RuleSets { get; set; }
    //}
}