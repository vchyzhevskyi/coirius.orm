using System.Text;

namespace Coirius.Orm
{
    internal class AbstractQueryBuilder
    {
        protected StringBuilder query;

        public string Query
        {
            get { return this.query.ToString(); }
        }

        public AbstractQueryBuilder()
        {
            query = new StringBuilder();
        }
    }
}
