using System;
using CLPClasses;

namespace CLPComparisons
{
    public static class GreaterThanOrEqualToComparison
    {
        public static bool GreaterThanOrEqualTo(int a, int b)
        {
            if (a >= b)
                return true;

            return false;
        }

        public static bool GreaterThanOrEqualTo(long a, long b)
        {
            if (a >= b)
                return true;

            return false;
        }

        public static bool GreaterThanOrEqualTo(uint a, uint b)
        {
            if (a >= b)
                return true;

            return false;
        }

        public static bool GreaterThanOrEqualTo(ulong a, ulong b)
        {
            if (a >= b)
                return true;

            return false;
        }

        public static bool GreaterThanOrEqualTo(double a, double b)
        {
            if (a >= b)
                return true;

            return false;
        }

        public static bool GreaterThanOrEqualTo(float a, float b)
        {
            if (a >= b)
                return true;

            return false;
        }

        public static bool GreaterThanOrEqualTo(char a, char b)
        {
            if (a >= b)
                return true;

            return false;
        }

        public static bool GreaterThanOrEqualTo(byte a, byte b)
        {
            if (a >= b)
                return true;

            return false;
        }

        public static bool GreaterThanOrEqualTo(DateTime a, string b)
        {
            var bee = Utility.ParseBDate(b);

            if (a >= bee)
                return true;

            return false;
        }
    }
}