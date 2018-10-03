using System.Collections.Generic;
using System.Dynamic;

namespace CLPClasses
{
    public static class IdentityUtil
    {
        public static void AddIdentities(ref List<ExpandoObject> dataset)
        {
            var ruleRoleId = 1;

            foreach (var propObject in dataset)
                ((IDictionary<string, object>) propObject).Add("RuleRowId", ruleRoleId++);
        }

        public static void RemoveIdentities(ref List<ExpandoObject> dataset)
        {
            foreach (var propObject in dataset) ((IDictionary<string, object>) propObject).Remove("RuleRowId");
        }
    }
}