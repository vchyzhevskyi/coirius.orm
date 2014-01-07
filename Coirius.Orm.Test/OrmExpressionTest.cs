using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coirius.Orm.Test
{
    [TestClass]
    public class OrmExpressionTest
    {
        [TestMethod]
        public void EqualExpressionTest()
        {
            OrmColumn column = new OrmColumn { Name = "Test" };
            EqualExpression expr = new EqualExpression(column, "test");
            Assert.AreEqual("(Test = test)", expr.ToString());
            Assert.AreNotEqual("Test IN test", expr.ToString());

            expr = new EqualExpression(column, 10);
            Assert.AreEqual("(Test = 10)", expr.ToString());
            Assert.AreNotEqual("Test IN 10", expr.ToString());
        }
    }
}
