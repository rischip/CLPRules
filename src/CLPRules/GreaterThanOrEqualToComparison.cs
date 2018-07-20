using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPRules
{
    public static class GreaterThanOrEqualToComparison
    {
        public static bool GreaterThanOrEqualTo(int a, int b)
        {
            if (a >= b)
                return true;

            return false;
        }
        public static bool GreaterThanOrEqualTo(Int64 a, Int64 b)
        {
            if (a >= b)
                return true;

            return false;
        }
        public static bool GreaterThanOrEqualTo(UInt32 a, UInt32 b)
        {
            if (a >= b)
                return true;

            return false;
        }
        public static bool GreaterThanOrEqualTo(UInt64 a, UInt64 b)
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
    }
}
