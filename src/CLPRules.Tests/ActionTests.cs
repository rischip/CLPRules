using CLPActions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLPRules.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void TestActions()
        {
            var emailAction = new EmailAction();
            //emailAction.Execute();
        }

        [TestMethod]
        public void TestBoolAnds()
        {
            var groupResult = true;

            groupResult = true;
            Assert.IsTrue(groupResult && true && true);

            groupResult = true;
            Assert.IsFalse(groupResult && false && true);

            groupResult = true;
            Assert.IsFalse(groupResult && true && false);
        }
    }
}