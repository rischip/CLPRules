using System.Collections.Generic;
using System.Dynamic;

namespace CLPRules
{
    public class RuleList
    {
        public List<RuleSet> RuleSets { get; set; }

        public void Execute(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            foreach (var ruleGroup in RuleSets) ruleGroup.Coalesce(src, ref dest);
        }

        public void ErrCheck(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            foreach (var ruleGroup in RuleSets) ruleGroup.ErrCheck(src, ref dest);
        }
    }
}