using System;
using CLPClasses;

namespace CLPComparisons
{
    public static class NotEqualToComparison
    {
        public static bool NotEqualTo(string a, string b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(int a, int b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(long a, long b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(uint a, uint b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(ulong a, ulong b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(double a, double b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(float a, float b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(char a, char b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(byte a, byte b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(bool a, bool b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(object a, object b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(Guid a, Guid b)
        {
            if (a != b)
                return true;

            return false;
        }

        public static bool NotEqualTo(DateTime a, string b)
        {
            var bee = Utility.ParseBDate(b);

            if (a != bee)
                return true;

            return false;
        }
    }
}