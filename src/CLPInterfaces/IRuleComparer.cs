namespace CLPInterfaces
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
        bool Match<T>(object a, object b);
    }
}