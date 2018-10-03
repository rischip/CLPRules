using System.Collections.Generic;
using System.Dynamic;

namespace CLPActions
{
    public static class ExcludeAction
    {
        public static void Execute(IDictionary<string, object> src, ref List<ExpandoObject> dest)
        {
            dest.Remove(src as ExpandoObject);
        }
    }
}