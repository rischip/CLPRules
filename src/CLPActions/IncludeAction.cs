using System;
using System.Collections.Generic;
using System.Dynamic;
using CLPClasses;

namespace CLPActions
{
    public static class IncludeAction
    {
        public static void Execute(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            var rowId = (int)src["RuleRowId"];

            foreach (var row in dest)
                if (Convert.ToInt32(PropertyUtils.GetPropertyValueByName(row, "RuleRowId")) == rowId)
                    return;

            dest.Add(src as ExpandoObject);
        }
    }
}