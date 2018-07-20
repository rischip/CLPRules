using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPRules
{
    public class EqualToComparison
    {
        public static bool EqualTo(string a, string b)
        {
            if (a.Equals(b, StringComparison.CurrentCulture))
                return true;

            return false;
        }

        public static bool EqualTo(int a, int b)
        {
            if (a == b)
                return true;

            return false;
        }
        public static bool EqualTo(Int64 a, Int64 b)
        {
            if (a == b)
                return true;

            return false;
        }
        public static bool EqualTo(UInt32 a, UInt32 b)
        {
            if (a == b)
                return true;

            return false;
        }
        public static bool EqualTo(UInt64 a, UInt64 b)
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

    }
}
