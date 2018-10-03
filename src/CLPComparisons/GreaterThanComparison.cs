using System;
using CLPClasses;

namespace CLPComparisons
{
    public static class GreaterThanComparison
    {
        public static bool GreaterThan(int a, int b)
        {
            if (a > b)
                return true;

            return false;
        }

        public static bool GreaterThan(long a, long b)
        {
            if (a > b)
                return true;

            return false;
        }

        public static bool GreaterThan(uint a, uint b)
        {
            if (a > b)
                return true;

            return false;
        }

        public static bool GreaterThan(ulong a, ulong b)
        {
            if (a > b)
                return true;

            return false;
        }

        public static bool GreaterThan(double a, double b)
        {
            if (a > b)
                return true;

            return false;
        }

        public static bool GreaterThan(float a, float b)
        {
            if (a > b)
                return true;

            return false;
        }

        public static bool GreaterThan(char a, char b)
        {
            if (a > b)
                return true;

            return false;
        }

        public static bool GreaterThan(byte a, byte b)
        {
            if (a > b)
                return true;

            return false;
        }

        public static bool GreaterThan(DateTime a, string b)
        {
            var bee = Utility.ParseBDate(b);

            if (a > bee)
                return true;

            return false;
        }
    }
}