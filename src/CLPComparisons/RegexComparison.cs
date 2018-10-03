using System.Text.RegularExpressions;

namespace CLPComparisons
{
    public class RegexComparison
    {
        public static bool Match(string a, string b)
        {
            if (Regex.Match(a, b).Success)
                return true;

            return false;
        }
        // Regex replace requires an additional parameter
        //public static bool Replace(string a, string b)
        //{
        //    Regex regex = new Regex(b);
        //    var val = regex.Replace(a, "");

        //    return false;
        //}
    }
}