using System;
using CLPInterfaces;

namespace CLPComparisons
{
    public class ComparisonExecutor : RuleComparer, IComparisonExecutor
    {
        public ComparisonExecutor()
        {
        }

        public ComparisonExecutor(string comparisonOperator, string comparisonType, object compareRuleObject,
            object compareSourceObject)
        {
            ComparisonOperator = comparisonOperator;
            ComparisonType = comparisonType;
            CompareRuleObject = compareRuleObject;
            CompareSourceObject = compareSourceObject;
        }

        public string ComparisonOperator { get; set; }
        public string ComparisonType { get; set; }
        public object CompareRuleObject { get; set; }
        public object CompareSourceObject { get; set; }

        public bool ExecuteComparison()
        {
            ArgumentValidator();
            switch (ComparisonType.ToLower())
            {
                case "string":
                    return DoComparison<string>();
                case "int":
                    return DoComparison<int>();
                case "int64":
                    return DoComparison<long>();
                case "uint32":
                    return DoComparison<uint>();
                case "uint64":
                    return DoComparison<ulong>();
                case "double":
                    return DoComparison<double>();
                case "float":
                    return DoComparison<float>();
                case "char":
                    return DoComparison<char>();
                case "byte":
                    return DoComparison<byte>();
                case "bool":
                    return DoComparison<bool>();
                case "guid":
                    return DoComparison<Guid>();
                case "datetime":
                    return DoComparison<DateTime>();
                default:
                    throw new ArgumentException(
                        $"ComparisonType value of {ComparisonType} is invalid or not yet implemented.",
                        $"ComparisonType");
            }
        }

        private void ArgumentValidator()
        {
            if (string.IsNullOrWhiteSpace(ComparisonType))
                throw new ArgumentNullException($"ComparisonType",
                    "ComparisonType cannot be null, empty or whitespace.");

            if (string.IsNullOrWhiteSpace(ComparisonOperator))
                throw new ArgumentNullException($"ComparisonOperator",
                    "ComparisonOperator cannot be null, empty or whitespace.");

            //if (string.IsNullOrWhiteSpace(CompareRuleObject.ToString()))
            //    throw new ArgumentNullException($"CompareRuleObject",
            //        "CompareRuleObject cannot be null, empty or whitespace.");

            //if (string.IsNullOrWhiteSpace(CompareSourceObject.ToString()))
            //    throw new ArgumentNullException($"CompareSourceObject",
            //        "CompareSourceObject cannot be null, empty or whitespace.");
        }

        private bool DoComparison<T>()
        {
            if (typeof(T) == typeof(string)) return DoStringComparison();
            if (typeof(T) == typeof(int)) return DoIntComparison();
            if (typeof(T) == typeof(long)) return DoInt64Comparison();
            if (typeof(T) == typeof(uint)) return DoUInt32Comparison();
            if (typeof(T) == typeof(ulong)) return DoUInt64Comparison();
            if (typeof(T) == typeof(double)) return DoDoubleComparison();
            if (typeof(T) == typeof(float)) return DoFloatComparison();
            if (typeof(T) == typeof(char)) return DoCharComparison();
            if (typeof(T) == typeof(byte)) return DoByteComparison();
            if (typeof(T) == typeof(bool)) return DoBoolComparison();
            if (typeof(T) == typeof(Guid)) return DoGuidComparison();
            if (typeof(T) == typeof(DateTime)) return DoDateTimeComparison();

            throw new ArgumentException($"Comparison of Type {typeof(T)} is invalid or not yet implemented.",
                $"ComparisonType");
        }

        private bool DoStringComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<string>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<string>(CompareSourceObject, CompareRuleObject);
                    break;
                case "containscs":
                    result = ContainsCS<string>(CompareSourceObject, CompareRuleObject);
                    break;
                case "containsci":
                    result = ContainsCI<string>(CompareSourceObject, CompareRuleObject);
                    break;
                case "notcontainscs":
                    result = NotContainsCS<string>(CompareSourceObject, CompareRuleObject);
                    break;
                case "notcontainsci":
                    result = NotContainsCI<string>(CompareSourceObject, CompareRuleObject);
                    break;
                case "match":
                    result = Match<string>(CompareSourceObject, CompareRuleObject);
                    break;

                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }


        private bool DoIntComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<int>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<int>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<int>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<int>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<int>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<int>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoInt64Comparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<long>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<long>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<long>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<long>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<long>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<long>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoUInt32Comparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<uint>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<uint>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<uint>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<uint>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<uint>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<uint>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoUInt64Comparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<ulong>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<ulong>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<ulong>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<ulong>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<ulong>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<ulong>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoDoubleComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<double>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<double>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<double>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<double>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<double>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<double>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoFloatComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<float>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<float>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<float>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<float>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<float>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<float>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoCharComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<char>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<char>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<char>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<char>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<char>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<char>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoByteComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<byte>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<byte>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<byte>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<byte>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<byte>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<byte>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoBoolComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<bool>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<bool>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<bool>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<bool>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<bool>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<bool>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoGuidComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<Guid>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<Guid>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }

        private bool DoDateTimeComparison()
        {
            var result = false;
            switch (ComparisonOperator.ToLower())
            {
                case "==":
                    result = EqualTo<DateTime>(CompareSourceObject, CompareRuleObject);
                    break;
                case "!=":
                    result = NotEqualTo<DateTime>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<":
                    result = LessThan<DateTime>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">":
                    result = GreaterThan<DateTime>(CompareSourceObject, CompareRuleObject);
                    break;
                case "<=":
                    result = LessThanOrEqualTo<DateTime>(CompareSourceObject, CompareRuleObject);
                    break;
                case ">=":
                    result = GreaterThanOrEqualTo<DateTime>(CompareSourceObject, CompareRuleObject);
                    break;
                default:
                    throw new ArgumentException(
                        $"ComparisonOperator value of {ComparisonOperator} is invalid or not yet implemented.",
                        $"ComparisonOperator");
            }

            return result;
        }
    }
}