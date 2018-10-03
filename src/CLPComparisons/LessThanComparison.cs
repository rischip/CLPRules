using System;
using CLPClasses;

namespace CLPComparisons
{
    public static class LessThanComparison
    {
        public static bool LessThan(int a, int b)
        {
            if (a < b)
                return true;

            return false;
        }

        public static bool LessThan(long a, long b)
        {
            if (a < b)
                return true;

            return false;
        }

        public static bool LessThan(uint a, uint b)
        {
            if (a < b)
                return true;

            return false;
        }

        public static bool LessThan(ulong a, ulong b)
        {
            if (a < b)
                return true;

            return false;
        }

        public static bool LessThan(double a, double b)
        {
            if (a < b)
                return true;

            return false;
        }

        public static bool LessThan(float a, float b)
        {
            if (a < b)
                return true;

            return false;
        }

        public static bool LessThan(char a, char b)
        {
            if (a < b)
                return true;

            return false;
        }

        public static bool LessThan(byte a, byte b)
        {
            if (a < b)
                return true;

            return false;
        }

        public static bool LessThan(DateTime a, string b)
        {
            var bee = Utility.ParseBDate(b);

            if (a < bee)
                return true;

            return false;
        }
    }
}