using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CLPClasses
{
    public class CSV
    {
        public string Stringify(ref string csvValue)
        {
            string json;
            var csv = new List<string[]>();
            char[] chars = new char[]{ '\r'};//, '\n'};
            foreach (var line in csvValue.Trim().Split(chars))
                csv.Add(line.Split(',')); // or, populate YourClass          
            var line1 = csvValue.Split(chars)[0];
            var properties = line1.Split(',');
            int i = 0;
            int j = 0;
            int l = 0;
            for (l = properties.Length - 1; l >= 0; l--) properties[l] = properties[l].Trim();

            var listObjResult = new List<Dictionary<string, string>>();

            for (i = 1; i < csv.Count; i++)
            {
                
                    if (csv[i].Length < properties.Length)
                        continue;
                    var objResult = new Dictionary<string, string>();
                    try
                    {
                        for (j = 0; j < properties.Length; j++)
                        {
                            string value = null;
                            if (csv[i][j] == null || csv[i][j]?.Trim('\n').ToLower() == "null" ||
                                csv[i][j]?.Trim('\n').ToLower() == "\"null\"")
                            {
                                objResult.Add(properties[j], value);
                            }
                        else
                            {
                                value = csv[i][j]?.Trim('\n');
                                objResult.Add(properties[j], value);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var message = ex.Message;
                        throw  new Exception(ex.Message + $" Error on Item {i} on Property {j}.");
                    }

                try
                {
                    listObjResult.Add(objResult);
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }

                if (i > csv.Count - 10)
                {
                }
            }

            json = JsonConvert.SerializeObject(listObjResult);
            return json;
        }
    }
}