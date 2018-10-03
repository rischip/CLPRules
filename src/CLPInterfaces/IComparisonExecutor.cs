namespace CLPInterfaces
{
    public interface IComparisonExecutor
    {
        string ComparisonOperator { get; set; }
        string ComparisonType { get; set; }
        object CompareRuleObject { get; set; }
        object CompareSourceObject { get; set; }
        bool ExecuteComparison();
    }
}