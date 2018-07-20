﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPRules
{
    public interface IRuleComparer
    {
        bool EqualTo<T>(object a, object b);
        bool LessThan<T>(object a, object b);
        bool GreaterThan<T>(object a, object b);
        bool NotEqualTo<T>(object a, object b);
        bool LessThanOrEqualTo<T>(object a, object b);
        bool GreaterThanOrEqualTo<T>(object a, object b);
        bool ContainsCS<T>(object a, object b);
        bool ContainsCI<T>(object a, object b);
        bool NotContainsCS<T>(object a, object b);
        bool NotContainsCI<T>(object a, object b);
    }
    public class RuleComparer : IRuleComparer
    {
        public bool ContainsCI<T>(object a, object b)
        {
            if (typeof(T) == typeof(string))
            {
                return ContainsComparison.ContainsCI(a.ToString(), b.ToString());
            }
            return false;
        }

        public bool ContainsCS<T>(object a, object b)
        {
            if (typeof(T) == typeof(string))
            {
                return ContainsComparison.ContainsCS(a.ToString(), b.ToString());
            }
            return false;
        }

        public bool NotContainsCI<T>(object a, object b)
        {
            if (typeof(T) == typeof(string))
            {
                return ContainsComparison.NOTContainsCI(a.ToString(), b.ToString());
            }
            return false;
        }

        public bool NotContainsCS<T>(object a, object b)
        {
            if (typeof(T) == typeof(string))
            {
                return ContainsComparison.NOTContainsCS(a.ToString(), b.ToString());
            }
            return false;
        }

        public bool EqualTo<T>(object a, object b)
        {
            if (typeof(T) == typeof(string))
            {
                return EqualToComparison.EqualTo(a.ToString(), b.ToString());
            }
            if (typeof(T) == typeof(int))
            {
                return EqualToComparison.EqualTo(Convert.ToInt32(a), Convert.ToInt32(b));
            }
            if (typeof(T) == typeof(Int64))
            {
                return EqualToComparison.EqualTo(Convert.ToInt64(a), Convert.ToInt64(b));
            }
            if (typeof(T) == typeof(UInt32))
            {
                return EqualToComparison.EqualTo(Convert.ToUInt32(a), (UInt32)b);
            }
            if (typeof(T) == typeof(UInt64))
            {
                return EqualToComparison.EqualTo(Convert.ToUInt64(a), Convert.ToUInt64(b));
            }
            if (typeof(T) == typeof(double))
            {
                return EqualToComparison.EqualTo(Convert.ToDouble(a), Convert.ToDouble(b));
            }
            if (typeof(T) == typeof(float))
            {
                return EqualToComparison.EqualTo(Convert.ToSingle(a), Convert.ToSingle(b));
            }
            if (typeof(T) == typeof(char))
            {
                return EqualToComparison.EqualTo(Convert.ToChar(a), Convert.ToChar(b));
            }
            if (typeof(T) == typeof(byte))
            {
                return EqualToComparison.EqualTo(Convert.ToByte(a), Convert.ToByte(b));
            }
            if (typeof(T) == typeof(bool))
            {
                return EqualToComparison.EqualTo(Convert.ToBoolean(a), Convert.ToBoolean(b));
            }
            if (typeof(T) == typeof(Guid))
            {
                return EqualToComparison.EqualTo(Guid.ParseExact(a.ToString(), "N"), Guid.ParseExact(b.ToString(), "N"));
            }
            return false;
        }

        public bool GreaterThan<T>(object a, object b)
        {
            if (typeof(T) == typeof(int))
            {
                return GreaterThanComparison.GreaterThan(Convert.ToInt32(a), Convert.ToInt32(b));
            }
            if (typeof(T) == typeof(Int64))
            {
                return GreaterThanComparison.GreaterThan(Convert.ToInt64(a), Convert.ToInt64(b));
            }
            if (typeof(T) == typeof(UInt32))
            {
                return GreaterThanComparison.GreaterThan(Convert.ToUInt32(a), (UInt32)b);
            }
            if (typeof(T) == typeof(UInt64))
            {
                return GreaterThanComparison.GreaterThan(Convert.ToUInt64(a), Convert.ToUInt64(b));
            }
            if (typeof(T) == typeof(double))
            {
                return GreaterThanComparison.GreaterThan(Convert.ToDouble(a), Convert.ToDouble(b));
            }
            if (typeof(T) == typeof(float))
            {
                return GreaterThanComparison.GreaterThan(Convert.ToSingle(a), Convert.ToSingle(b));
            }
            if (typeof(T) == typeof(char))
            {
                return GreaterThanComparison.GreaterThan(Convert.ToChar(a), Convert.ToChar(b));
            }
            if (typeof(T) == typeof(byte))
            {
                return GreaterThanComparison.GreaterThan(Convert.ToByte(a), Convert.ToByte(b));
            }
            return false;
        }

        public bool GreaterThanOrEqualTo<T>(object a, object b)
        {
            if (typeof(T) == typeof(int))
            {
                return GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(Convert.ToInt32(a), Convert.ToInt32(b));
            }
            if (typeof(T) == typeof(Int64))
            {
                return GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(Convert.ToInt64(a), Convert.ToInt64(b));
            }
            if (typeof(T) == typeof(UInt32))
            {
                return GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(Convert.ToUInt32(a), (UInt32)b);
            }
            if (typeof(T) == typeof(UInt64))
            {
                return GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(Convert.ToUInt64(a), Convert.ToUInt64(b));
            }
            if (typeof(T) == typeof(double))
            {
                return GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(Convert.ToDouble(a), Convert.ToDouble(b));
            }
            if (typeof(T) == typeof(float))
            {
                return GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(Convert.ToSingle(a), Convert.ToSingle(b));
            }
            if (typeof(T) == typeof(char))
            {
                return GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(Convert.ToChar(a), Convert.ToChar(b));
            }
            if (typeof(T) == typeof(byte))
            {
                return GreaterThanOrEqualToComparison.GreaterThanOrEqualTo(Convert.ToByte(a), Convert.ToByte(b));
            }
            return false;
        }

        public bool LessThan<T>(object a, object b)
        {
            if (typeof(T) == typeof(int))
            {
                return LessThanComparison.LessThan(Convert.ToInt32(a), Convert.ToInt32(b));
            }
            if (typeof(T) == typeof(Int64))
            {
                return LessThanComparison.LessThan(Convert.ToInt64(a), Convert.ToInt64(b));
            }
            if (typeof(T) == typeof(UInt32))
            {
                return LessThanComparison.LessThan(Convert.ToUInt32(a), (UInt32)b);
            }
            if (typeof(T) == typeof(UInt64))
            {
                return LessThanComparison.LessThan(Convert.ToUInt64(a), Convert.ToUInt64(b));
            }
            if (typeof(T) == typeof(double))
            {
                return LessThanComparison.LessThan(Convert.ToDouble(a), Convert.ToDouble(b));
            }
            if (typeof(T) == typeof(float))
            {
                return LessThanComparison.LessThan(Convert.ToSingle(a), Convert.ToSingle(b));
            }
            if (typeof(T) == typeof(char))
            {
                return LessThanComparison.LessThan(Convert.ToChar(a), Convert.ToChar(b));
            }
            if (typeof(T) == typeof(byte))
            {
                return LessThanComparison.LessThan(Convert.ToByte(a), Convert.ToByte(b));
            }
            return false;
        }

        public bool LessThanOrEqualTo<T>(object a, object b)
        {
            if (typeof(T) == typeof(int))
            {
                return LessThanOrEqualToComparison.LessThanOrEqualTo(Convert.ToInt32(a), Convert.ToInt32(b));
            }
            if (typeof(T) == typeof(Int64))
            {
                return LessThanOrEqualToComparison.LessThanOrEqualTo(Convert.ToInt64(a), Convert.ToInt64(b));
            }
            if (typeof(T) == typeof(UInt32))
            {
                return LessThanOrEqualToComparison.LessThanOrEqualTo(Convert.ToUInt32(a), (UInt32)b);
            }
            if (typeof(T) == typeof(UInt64))
            {
                return LessThanOrEqualToComparison.LessThanOrEqualTo(Convert.ToUInt64(a), Convert.ToUInt64(b));
            }
            if (typeof(T) == typeof(double))
            {
                return LessThanOrEqualToComparison.LessThanOrEqualTo(Convert.ToDouble(a), Convert.ToDouble(b));
            }
            if (typeof(T) == typeof(float))
            {
                return LessThanOrEqualToComparison.LessThanOrEqualTo(Convert.ToSingle(a), Convert.ToSingle(b));
            }
            if (typeof(T) == typeof(char))
            {
                return LessThanOrEqualToComparison.LessThanOrEqualTo(Convert.ToChar(a), Convert.ToChar(b));
            }
            if (typeof(T) == typeof(byte))
            {
                return LessThanOrEqualToComparison.LessThanOrEqualTo(Convert.ToByte(a), Convert.ToByte(b));
            }
            return false;
        }

        public bool NotEqualTo<T>(object a, object b)
        {
            if (typeof(T) == typeof(string))
            {
                return NotEqualToComparison.NotEqualTo(a.ToString(), b.ToString());
            }
            if (typeof(T) == typeof(int))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToInt32(a), Convert.ToInt32(b));
            }
            if (typeof(T) == typeof(Int64))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToInt64(a), Convert.ToInt64(b));
            }
            if (typeof(T) == typeof(UInt32))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToUInt32(a), (UInt32)b);
            }
            if (typeof(T) == typeof(UInt64))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToUInt64(a), Convert.ToUInt64(b));
            }
            if (typeof(T) == typeof(double))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToDouble(a), Convert.ToDouble(b));
            }
            if (typeof(T) == typeof(float))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToSingle(a), Convert.ToSingle(b));
            }
            if (typeof(T) == typeof(char))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToChar(a), Convert.ToChar(b));
            }
            if (typeof(T) == typeof(byte))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToByte(a), Convert.ToByte(b));
            }
            if (typeof(T) == typeof(bool))
            {
                return NotEqualToComparison.NotEqualTo(Convert.ToBoolean(a), Convert.ToBoolean(b));
            }
            return false;
        }

    }
}
