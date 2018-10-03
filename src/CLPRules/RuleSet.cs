using System.Collections.Generic;
using System.Dynamic;
using CLPInterfaces;

namespace CLPRules
{
    public class RuleSet
    {
        public RuleSet()
        {
            RuleSets = new List<BaseRule>();
        }

        public List<BaseRule> RuleSets { get; set; }

        private bool GroupResult { get; set; }

        public bool Coalesce(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            GroupResult = true;
            foreach (IRule rule in RuleSets)
                if (!(rule is IErrorCheck))
                {
                    var result = rule.Evaluate();
                    GroupResult = GroupResult && result && rule.ExpectedResult;
                }

            if (GroupResult)
                foreach (IRule rule in RuleSets)
                    if (!(rule is IErrorCheck))
                        rule.Apply(src, ref dest);
            return false;
        }

        public bool ErrCheck(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            GroupResult = true;
            foreach (IRule rule in RuleSets)
                if (rule is IErrorCheck)
                {
                    var result = rule.Evaluate();
                    GroupResult = GroupResult && result && rule.ExpectedResult;
                }

            if (GroupResult)
                foreach (IRule rule in RuleSets)
                    if (rule is IErrorCheck)
                        rule.Apply(src, ref dest);
            return false;
        }
    }
}