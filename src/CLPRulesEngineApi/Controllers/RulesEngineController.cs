using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using CLPClasses;
using CLPInterfaces;
using CLPRules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CLPRulesEngineApi.Controllers
{
    public class RulesEngineController : ApiController
    {
        // POST: api/RulesEngine
        [Route("api/v1/RulesEngine/{config}")]
        [Route("api/v1/RulesEngine/")]
        public HttpResponseMessage Post()
        {
            var startTime = DateTime.Now;
            var value = Request.Content.ReadAsStringAsync().Result;
            string json;
            var errorMessages = new List<ExpandoObject>();
            var destDataRows = new List<ExpandoObject>();
            if (Request.Content.Headers.ContentType.ToString().ToLower() == "application/json")
            {
                json = value;
            }
            else
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "This API accepts Content-Type [application/json] only."
                };
                throw new HttpResponseException(httpResponseMessage);
            }

            var activeRuleSets = RuleInstantiations.ParseRuleSets(json);
            var count = GetRuleCount(activeRuleSets);
            var ruleList = new RuleList {RuleSets = activeRuleSets};
            var propertyObject = RuleInstantiations.ParseDataSet(json);
            IdentityUtil.AddIdentities(ref propertyObject);
            destDataRows = IterateGeneralRules(propertyObject, ruleList, destDataRows, errorMessages);
            destDataRows = IterateErrorCheckRules(destDataRows, ruleList, errorMessages);
            IdentityUtil.RemoveIdentities(ref destDataRows);
            var parsed = BuildResponse(errorMessages, destDataRows);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(parsed.ToString(), Encoding.UTF8, "application/json");

            var endTime = DateTime.Now;
            var diff = endTime - startTime;

            AddHeaders(response, diff, propertyObject, destDataRows, count);

            return response;
        }

        private static int GetRuleCount(List<RuleSet> activeRuleSets)
        {
            var count = 0;
            foreach (var activeRuleSet in activeRuleSets)
            foreach (var rule in activeRuleSet.RuleSets)
                count++;

            return count;
        }

        private static void AddHeaders(HttpResponseMessage response, TimeSpan diff, List<ExpandoObject> propertyObject,
            List<ExpandoObject> destDataRows, int count)
        {
            response.Content.Headers.Add("Api-ExecutionTime", diff.ToString());
            response.Content.Headers.Add("Api-RuleExecutions", (propertyObject.Count * count).ToString());
            response.Content.Headers.Add("Api-AverageRuleRecordExecutionTime",
                (diff.TotalMilliseconds / (propertyObject.Count * count)).ToString(CultureInfo.InvariantCulture));
            response.Content.Headers.Add("Api-RuleCount", count.ToString());
            response.Content.Headers.Add("Api-InputRecordCount", propertyObject.Count.ToString());
            response.Content.Headers.Add("Api-ReturnedRecordCount", destDataRows.Count.ToString());

        }

        private static JObject BuildResponse(List<ExpandoObject> errorMessages, List<ExpandoObject> destDataRows)
        {
            var errorMessagesJsonOut = JsonConvert.SerializeObject(errorMessages);

            errorMessagesJsonOut = "\"ErrorMessages\": " + errorMessagesJsonOut;

            var jsonDataOut = JsonConvert.SerializeObject(destDataRows);


            jsonDataOut = "\"DataList\": " + jsonDataOut;
            var stringArr = new string[2];
            stringArr[0] = errorMessagesJsonOut;
            stringArr[1] = jsonDataOut;

            var jsonOut = string.Join(",", stringArr);
            jsonOut = "{" + jsonOut + "}";

            var parsed = JObject.Parse(jsonOut);
            return parsed;
        }

        private static List<ExpandoObject> IterateErrorCheckRules(List<ExpandoObject> destDataRows, RuleList ruleList,
            List<ExpandoObject> errorMessages)
        {
            foreach (var row in destDataRows)
            {
                foreach (var eachRuleSet in ruleList.RuleSets)
                foreach (var eachBaseRule in eachRuleSet.RuleSets)
                    if (eachBaseRule is IErrorCheck)
                        eachBaseRule.Configure(row);

                try
                {
                    ruleList.ErrCheck(row, ref destDataRows);
                }
                catch (ErrorCheckException ecEx)
                {
                    var ex = new ExpandoObject() as IDictionary<string, Object>;
                    ex.Add("ErrorMessage", ecEx.Message);
                    errorMessages.Add((ExpandoObject) ex);
                }
            }

            return destDataRows;
        }

        private static List<ExpandoObject> IterateGeneralRules(List<ExpandoObject> propertyObject, RuleList ruleList,
            List<ExpandoObject> destDataRows, List<ExpandoObject> errorMessages)
        {
            foreach (var row in propertyObject)
            {
                foreach (var eachRuleSet in ruleList.RuleSets)
                foreach (var eachBaseRule in eachRuleSet.RuleSets)
                    if (!(eachBaseRule is IErrorCheck))
                        eachBaseRule.Configure(row);

                try
                {
                    ruleList.Execute(row, ref destDataRows);
                }
                catch (ErrorCheckException ecEx)
                {
                    var ex = new ExpandoObject() as IDictionary<string, object>;
                    ex.Add("ErrorMessage", ecEx.Message);
                    errorMessages.Add((ExpandoObject) ex);
                }
            }

            return destDataRows;
        }
    }
}