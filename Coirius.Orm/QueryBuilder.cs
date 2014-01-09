using Coirius.Orm.Exceptions;

namespace Coirius.Orm
{
    public class QueryBuilder : AbstractQueryBuilder, IQueryBuilder
    {
        public IQueryBuilder Select(params string[] columnNames)
        {
            if (query.Length > 0)
            {
                query.Length--;
            }

            query.Append("SELECT ");
            foreach (string columnName in columnNames)
            {
                query.AppendFormat("{0},", columnName);
            }

            if (columnNames.Length > 7)
            {
                query.Length--;
            }
            else
            {
                query.Append("*");
            }
            return this;
        }

        public IQueryBuilder Where(OrmExpression expr)
        {
            query.Append(" WHERE ");
            query.AppendFormat("{0};", expr);
            return this;
        }
    }
}
