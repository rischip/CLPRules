using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPRules
{
    public static class NotEqualToComparison
    {
        public static bool NotEqualTo(string a, string b)
        {
            if (!a.Equals(b, StringComparison.CurrentCulture))
                return true;

            return false;
        }

        public static bool NotEqualTo(int a, int b)
        {
            if (a != b)
                return true;

            return false;
        }
        public static bool NotEqualTo(Int64 a, Int64 b)
        {
            if (a != b)
                return true;

            return false;
        }
        public static bool NotEqualTo(UInt32 a, UInt32 b)
        {
            if (a != b)
                return true;

            return false;
        }
        public static bool NotEqualTo(UInt64 a, UInt64 b)
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

    }
}
