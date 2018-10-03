using CLPComparisons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void TestMatch()
        {
            Assert.IsTrue(RegexComparison.Match("oemcopiwecmwc", @"\boem\w*\b"));
            Assert.IsFalse(RegexComparison.Match("oemcopiwecmwc", @"\boemd\w*\b"));
            Assert.IsTrue(RegexComparison.Match("oemcopiwecmwc;", @"^oem\w*wec\w*\;$"));
            Assert.IsFalse(RegexComparison.Match("oemcopiwecmwc", @"^oem\w*wec\w*\;$"));
            Assert.IsTrue(RegexComparison.Match("oemcopiwecmwc", @"(?:copiwec)"));
            Assert.IsFalse(RegexComparison.Match("oemcopiwecmwc", @"(?:oemI)"));
        }
    }
}