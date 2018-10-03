using System.Collections.Generic;
using System.Dynamic;
using CLPInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    /// <summary>
    ///     Summary description for RuleSetTests
    /// </summary>
    [TestClass]
    public class RuleSetTests
    {
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestMethod1()
        {
            IDictionary<string, object> src = new Dictionary<string, object>();
            var dest = new List<ExpandoObject>();

            src.Add(new KeyValuePair<string, object>("objectOne", "valueOne"));
            src.Add(new KeyValuePair<string, object>("objectTwo", "valueTwo"));
            src.Add(new KeyValuePair<string, object>("objectThree", "valueThree"));
            src.Add(new KeyValuePair<string, object>("objectFour", "valueFour"));

            var ruleList = new RuleList();
            var ruleOne = new IncludeRule("!=", "string", "valueZero", true);
            var ruleSet = new RuleSet();
            var iRules = new List<IRule> {ruleOne};
            ruleList.RuleSets.Add(ruleSet);
            var ruleTwo = new IncludeRule("==", "string", "valueOne", true);
            var ruleThree = new IncludeRule("==", "string", "valueTwo", true);
            var ruleFour = new IncludeRule("==", "string", "valueThree", true);
            var ruleFive = new ExcludeRule("==", "string", "valueThree", true);
            var ruleSix = new ErrorCheckRule("!=", "string", "valueZero", true);


            //ruleList.RuleSets.Add();
            ruleList.Execute(src, ref dest);
        }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion
    }
}