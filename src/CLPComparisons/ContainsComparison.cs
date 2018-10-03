namespace CLPComparisons
{
    public static class ContainsComparison
    {
        /// <summary>
        ///     Case insensitive string comparison
        /// </summary>
        /// <param name="a">Source string that contains b</param>
        /// <param name="b">String that is contained in source string</param>
        /// <returns>bool</returns>
        public static bool ContainsCI(string a, string b)
        {
            if (a.ToLower().Contains(b.ToLower()))
                return true;

            return false;
        }

        /// <summary>
        ///     Case sensitive string comparison
        /// </summary>
        /// <param name="a">Source string that contains b</param>
        /// <param name="b">String that is contained in source string</param>
        /// <returns>bool</returns>
        public static bool ContainsCS(string a, string b)
        {
            if (a.Contains(b))
                return true;

            return false;
        }

        /// <summary>
        ///     Case insensitive string comparison
        /// </summary>
        /// <param name="a">Source string that NOT contains b</param>
        /// <param name="b">String that is NOT contained in source string</param>
        /// <returns>bool</returns>
        public static bool NOTContainsCI(string a, string b)
        {
            if (!a.ToLower().Contains(b.ToLower()))
                return true;

            return false;
        }

        /// <summary>
        ///     Case sensitive string comparison
        /// </summary>
        /// <param name="a">Source string that NOT contains b</param>
        /// <param name="b">String that is NOT contained in source string</param>
        /// <returns>bool</returns>
        public static bool NOTContainsCS(string a, string b)
        {
            if (!a.Contains(b))
                return true;

            return false;
        }
    }
}