using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPRules
{
    public static class GreaterThanComparison
    {
        public static bool GreaterThan(int a, int b)
        {
            if (a > b)
                return true;

            return false;
        }
        public static bool GreaterThan(Int64 a, Int64 b)
        {
            if (a > b)
                return true;

            return false;
        }
        public static bool GreaterThan(UInt32 a, UInt32 b)
        {
            if (a > b)
                return true;

            return false;
        }
        public static bool GreaterThan(UInt64 a, UInt64 b)
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
    }
}
