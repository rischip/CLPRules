using System.Collections.Generic;
using System.Dynamic;
using CLPComparisons;
using CLPInterfaces;

namespace CLPRules
{

    public class Comparisons
    {
        public IList<string> GetComparisonOperators()
        {
            return new List<string>
            {
                "==",
                "!=",
                "<",
                ">",
                "<=",
                ">=",
                "ContainsCS",
                "ContainsCI",
                "NotContainsCS",
                "NotContainsCI",
                "NotContainsCS",
                "Match"
            };
        }

        public IList<string> GetComparisonTypes()
        {
            return new List<string>
            {
                "string",
                "int",
                "Int64",
                "UInt32",
                "UInt64",
                "double",
                "float",
                "char",
                "byte",
                "bool",
                "Guid"
            };
        }
    }
}