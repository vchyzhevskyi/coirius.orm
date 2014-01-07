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
            Assert.AreEqual("(Test = N'test')", expr.ToString());
            Assert.AreNotEqual("Test IN N'test'", expr.ToString());

            expr = new EqualExpression(column, 10);
            Assert.AreEqual("(Test = 10)", expr.ToString());
            Assert.AreNotEqual("Test IN 10", expr.ToString());
        }

        [TestMethod]
        public void AndExpressionTest()
        {
            OrmColumn column = new OrmColumn { Name = "Test" };
            EqualExpression expr1 = new EqualExpression(column, "Test");
            EqualExpression expr2 = new EqualExpression(column, "test");
            AndExpression expr = new AndExpression(expr1, expr2);
            Assert.AreEqual("((Test = N'Test') AND (Test = N'test'))", expr.ToString());
            Assert.AreNotEqual("((Test = N'Test')) AND ((Test = N'test'))", expr.ToString());
        }
    }
}
