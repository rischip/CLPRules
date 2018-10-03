using System.Collections.Generic;
using System.Dynamic;

namespace CLPInterfaces
{
    public interface IAction
    {
        void Execute(IDictionary<string, object> src, List<ExpandoObject> dest);
    }

}