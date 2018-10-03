using System.Collections.Generic;
using Newtonsoft.Json;

namespace CLPClasses
{
    public class CSV
    {
        public string Stringify(string csvValue)
        {
            string json;
            var csv = new List<string[]>();
            foreach (var line in csvValue.Trim().Split('\r'))
                csv.Add(line.Split(',')); // or, populate YourClass          
            var properties = csvValue.Split('\r')[0].Split(',');

            for (var i = properties.Length - 1; i >= 0; i--) properties[i] = properties[i].Trim();

            var listObjResult = new List<Dictionary<string, string>>();

            for (var i = 1; i < csv.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(csv[i].ToString()))
                    continue;
                var objResult = new Dictionary<string, string>();
                for (var j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]?.Trim('\n'));

                listObjResult.Add(objResult);
                if (i > csv.Count - 10)
                {
                }
            }

            json = JsonConvert.SerializeObject(listObjResult);
            return json;
        }
    }
}