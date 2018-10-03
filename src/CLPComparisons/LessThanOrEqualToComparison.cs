using System;
using CLPClasses;

namespace CLPComparisons
{
    public static class LessThanOrEqualToComparison
    {
        public static bool LessThanOrEqualTo(int a, int b)
        {
            if (a <= b)
                return true;

            return false;
        }

        public static bool LessThanOrEqualTo(long a, long b)
        {
            if (a <= b)
                return true;

            return false;
        }

        public static bool LessThanOrEqualTo(uint a, uint b)
        {
            if (a <= b)
                return true;

            return false;
        }

        public static bool LessThanOrEqualTo(ulong a, ulong b)
        {
            if (a <= b)
                return true;

            return false;
        }

        public static bool LessThanOrEqualTo(double a, double b)
        {
            if (a <= b)
                return true;

            return false;
        }

        public static bool LessThanOrEqualTo(float a, float b)
        {
            if (a <= b)
                return true;

            return false;
        }

        public static bool LessThanOrEqualTo(char a, char b)
        {
            if (a <= b)
                return true;

            return false;
        }

        public static bool LessThanOrEqualTo(byte a, byte b)
        {
            if (a <= b)
                return true;

            return false;
        }

        public static bool LessThanOrEqualTo(DateTime a, string b)
        {
            var bee = Utility.ParseBDate(b);

            if (a <= bee)
                return true;

            return false;
        }
    }
}