using System;
using CLPClasses;

namespace CLPComparisons
{
    public class EqualToComparison
    {
        public static bool EqualTo(string a, string b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(int a, int b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(long a, long b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(uint a, uint b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(ulong a, ulong b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(double a, double b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(float a, float b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(char a, char b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(byte a, byte b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(bool a, bool b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(Guid a, Guid b)
        {
            if (a == b)
                return true;

            return false;
        }

        public static bool EqualTo(DateTime a, string b)
        {
            var bee = Utility.ParseBDate(b);

            if (a == bee)
                return true;

            return false;
        }
    }
}