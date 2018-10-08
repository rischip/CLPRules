using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [Route("api/v1/RulesEngine")]
        public HttpResponseMessage Post()
        {
            try
            {
                return RunRulesPost();
            }
            catch (Exception ex)
            {
                HttpResponseException httpResponseException = new HttpResponseException(HttpStatusCode.BadRequest)
                {
                    
                    Response =
                    {
                        ReasonPhrase = ex.Message,
                        RequestMessage = Request,
                        Content = new StringContent(ex.Message + " " + ex.StackTrace)
                    }
                };
                
                throw httpResponseException;
            }
        }

        private HttpResponseMessage RunRulesPost()
        {
            var value = Request.Content.ReadAsStringAsync().Result;
            var startTime = DateTime.Now;
            string json;
            var errorMessages = new List<ExpandoObject>();
            var destDataRows = new List<ExpandoObject>();
            if (Request.Content.Headers.ContentType.ToString().ToLower() == "application/json")
            {
                json = value;
                value = null;
            }
            else
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "This API accepts Content-Type [application/json] only."
                };
                throw new HttpResponseException(httpResponseMessage);
            }

            var activeRuleSets = RuleInstantiations.ParseRuleSets(ref json);
            var count = GetRuleCount(activeRuleSets);
            var ruleList = new RuleList {RuleSets = activeRuleSets};
            var propertyObject = RuleInstantiations.ParseDataSet(ref json);
            json = null;
            IdentityUtil.AddIdentities(ref propertyObject);
            destDataRows = IterateGeneralRules(ref propertyObject, ruleList, ref destDataRows, ref errorMessages);
            destDataRows = IterateErrorCheckRules(ref destDataRows, ruleList, ref errorMessages);
            IdentityUtil.RemoveIdentities(ref destDataRows);
            var parsed = BuildResponse(ref errorMessages, ref destDataRows);
            var response = Request.CreateResponse(HttpStatusCode.OK);

            var endTime = DateTime.Now;
            var diff = endTime - startTime;

            response.Content = new StringContent(parsed.ToString(), Encoding.UTF8, "application/json");
            AddHeaders(response, diff, ref propertyObject, ref destDataRows, count);

            Debug.WriteLine("End of call to " + this.GetType().Name + ". " +
                            System.Reflection.MethodBase.GetCurrentMethod().Name + ".");

            return response;
        }

        [Route("api/v1/RulesEngine/GetComparisonOperators")]
        public HttpResponseMessage GetOperators()
        {
            Comparisons comparisons = new Comparisons();
            var parsed = JsonConvert.SerializeObject(comparisons.GetComparisonOperators());
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(parsed.ToString(), Encoding.UTF8, "application/json");

            return response;
        }

        [Route("api/v1/RulesEngine/GetComparisonTypes")]
        public HttpResponseMessage GetComparisonTypes()
        {
            Comparisons comparisons = new Comparisons();
            var parsed = JsonConvert.SerializeObject(comparisons.GetComparisonTypes());
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(parsed.ToString(), Encoding.UTF8, "application/json");

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

        private static void AddHeaders(HttpResponseMessage response, TimeSpan diff, ref List<ExpandoObject> propertyObject,
            ref List<ExpandoObject> destDataRows, int count)
        {
            response.Content.Headers.Add("Api-ExecutionTime", diff.ToString());
            response.Content.Headers.Add("Api-RuleExecutions", (propertyObject.Count * count).ToString());
            response.Content.Headers.Add("Api-AverageRuleRecordExecutionTime",
                (diff.TotalMilliseconds / (propertyObject.Count * count)).ToString(CultureInfo.InvariantCulture));
            response.Content.Headers.Add("Api-RuleCount", count.ToString());
            response.Content.Headers.Add("Api-InputRecordCount", propertyObject.Count.ToString());
            response.Content.Headers.Add("Api-ReturnedRecordCount", destDataRows.Count.ToString());

        }

        private static JObject BuildResponse(ref List<ExpandoObject> errorMessages,
            ref List<ExpandoObject> destDataRows)
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

        private static List<ExpandoObject> IterateErrorCheckRules(ref List<ExpandoObject> destDataRows,
            RuleList ruleList,
            ref List<ExpandoObject> errorMessages)
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

        private static List<ExpandoObject> IterateGeneralRules(ref List<ExpandoObject> propertyObject,
            RuleList ruleList,
            ref List<ExpandoObject> destDataRows, ref List<ExpandoObject> errorMessages)
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

        [Route("api/v1/CsvToJson/")]
        public HttpResponseMessage PostCsv()
        {
            try
            {
                return ConvertCsvToJson();
            }
            catch (Exception ex)
            {
                HttpResponseException httpResponseException = new HttpResponseException(HttpStatusCode.BadRequest)
                {

                    Response =
                    {
                        ReasonPhrase = ex.Message,
                        RequestMessage = Request,
                        Content = new StringContent(ex.Message + " " + ex.StackTrace)
                    }
                };

                throw httpResponseException;
            }
        }

        private HttpResponseMessage ConvertCsvToJson()
        {
            var startTime = DateTime.Now;
            CSV csv = new CSV();

            var value = Request.Content.ReadAsStringAsync().Result;

            string json;

            if (Request.Content.Headers.ContentType.ToString().ToLower() == "text/csv")
            {
                json = csv.Stringify(ref value);
                value = null;
            }
            else
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    ReasonPhrase = "This API method accepts Content-Type [text/csv] only."
                };
                throw new HttpResponseException(httpResponseMessage);
            }

            //var parsed = JObject.Parse(json);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            Debug.WriteLine("End of call to " + this.GetType().Name + ". " +
                            System.Reflection.MethodBase.GetCurrentMethod().Name + ".");
            var endTime = DateTime.Now;
            var diff = endTime - startTime;
            response.Content.Headers.Add("Api-ExecutionTime", diff.ToString());
            return response;
        }
    }
}