using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPRules
{
    public static class LessThanComparison
    {
        public static bool LessThan(int a, int b)
        {
            if (a < b)
                return true;

            return false;
        }
        public static bool LessThan(Int64 a, Int64 b)
        {
            if (a < b)
                return true;

            return false;
        }
        public static bool LessThan(UInt32 a, UInt32 b)
        {
            if (a < b)
                return true;

            return false;
        }
        public static bool LessThan(UInt64 a, UInt64 b)
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
    }
}
