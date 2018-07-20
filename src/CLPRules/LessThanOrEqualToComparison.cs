using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPRules
{
    public static class LessThanOrEqualToComparison
    {
        public static bool LessThanOrEqualTo(int a, int b)
        {
            if (a <= b)
                return true;

            return false;
        }
        public static bool LessThanOrEqualTo(Int64 a, Int64 b)
        {
            if (a <= b)
                return true;

            return false;
        }
        public static bool LessThanOrEqualTo(UInt32 a, UInt32 b)
        {
            if (a <= b)
                return true;

            return false;
        }
        public static bool LessThanOrEqualTo(UInt64 a, UInt64 b)
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
    }
}
