using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using CLPClasses;

namespace CLPActions
{
    public static class IncludeAction
    {
        public static void Execute(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            var rowId = (int)src["RuleRowId"];

            //foreach (var row in dest)
            //    if (Convert.ToInt32(PropertyUtils.GetPropertyValueByName(row, "RuleRowId")) == rowId)
            //        return;
            var row = dest.Any(x => Convert.ToInt32(x.FirstOrDefault(y => y.Key == "RuleRowId").Value) == rowId);
            if(row == true)
                return;

            dest.Add(src as ExpandoObject);
        }
    }
}