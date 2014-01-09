using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coirius.Orm.Test
{
    [TestClass]
    public class OrmContextTest
    {
        private Context context;

        [TestInitialize]
        public void Initialize()
        {
            context = new Context(@"Data Source=.\MSSQL;Initial Catalog=Coirius.Orm;User ID=sa;Password=s@password;Integrated Security=True;");
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.context.Dispose();
        }

        [TestMethod]
        public void ExecTest()
        {
            QueryBuilder query = new QueryBuilder();
            IQueryBuilder builder = query as IQueryBuilder;

            builder = builder.From("TestTable");

            OrmDataEntry[] result = this.context.Exec(query);
        }
    }
}
