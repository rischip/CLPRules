using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using CLPClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CLPRules
{
    public class RuleInstantiations
    {
        public static List<RuleSet> ParseRuleSets(ref string json)
        {

            //dynamic d = JsonConvert.DeserializeObject<dynamic>(json);
            //string v = d.ToString();

            JObject parsed = JObject.Parse(json);
            JArray array = (JArray) parsed["RuleList"];

            List<RuleSet> ruleSetsDeserialized = JsonConvert.DeserializeObject<List<RuleSet>>(array.ToString());


            
            List<RuleSet> activeRuleSets = new List<RuleSet>();
            foreach (RuleSet ruleSet in ruleSetsDeserialized)
            {
                RuleSet localRuleSet = new RuleSet();
                List<BaseRule> activeBaseRules = new List<BaseRule>();
                foreach (BaseRule baseRule in ruleSet.RuleSets)
                {
                    string concreteType =
                        PropertyUtils.GetPropertyValueByName((object) baseRule, "RuleType").ToString();
                    IQueryable<Type> types = PropertyUtils.GetTypeByName(concreteType).AsQueryable<Type>();
                    Type type = types.FirstOrDefault(x => x.Name.ToString() == concreteType.ToString());
                    BaseRule concreteObj = null;
                    try
                    {
                        concreteObj =
                            (BaseRule) Activator.CreateInstance(type ?? throw new InvalidOperationException());
                    }
                    catch (InvalidOperationException)
                    {
                        if (concreteType.ToLower() == "commentrule" || concreteType.ToLower() == "comment")
                        {
                            continue;
                        }
                        else
                        {
                            throw;
                        }
                    };
                    concreteObj?.MapFromBase(baseRule);
                    activeBaseRules.Add(concreteObj);
                }

                localRuleSet.RuleSets.AddRange(activeBaseRules);
                activeRuleSets.Add(localRuleSet);
            }

            return activeRuleSets;
        }

        public static List<ExpandoObject> ParseDataSet(ref string json)
        {

            JObject parsed = JObject.Parse(json);
            JArray array = (JArray) parsed["DataList"];

            //dynamic data = JsonConvert.DeserializeObject<List<dynamic>>(array.ToString());

            List<ExpandoObject> data =
                JsonConvert.DeserializeObject<List<ExpandoObject>>(array.ToString());

            return data;
        }
    }
}