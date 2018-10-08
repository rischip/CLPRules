using CLPComparisons;
using CLPInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void TestMatch()
        {
            IRuleComparer ruleComparer = new RuleComparer();
            Assert.IsTrue(ruleComparer.Match<string>("oemcopiwecmwc", @"\boem\w*\b"));
            Assert.IsTrue(ruleComparer.Match<string>("oemcopiwecmwc", @"\boem\w*\b"));
            Assert.IsFalse(ruleComparer.Match<string>("oemcopiwecmwc", @"\boemd\w*\b"));
            Assert.IsTrue(ruleComparer.Match<string>("oemcopiwecmwc;", @"^oem\w*wec\w*\;$"));
            Assert.IsFalse(ruleComparer.Match<string>("oemcopiwecmwc", @"^oem\w*wec\w*\;$"));
            Assert.IsTrue(ruleComparer.Match<string>("oemcopiwecmwc", @"(?:copiwec)"));
            Assert.IsFalse(ruleComparer.Match<string>("oemcopiwecmwc", @"(?:oemI)"));

            Assert.IsTrue(ruleComparer.Match<string>("119197393146723", @"\b1191973\w*"));
        }
    }
}