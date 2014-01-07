using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Coirius.Orm
{
    internal class QueryBuilder<T> : AbstractQueryBuilder, IQueryBuilder<T>
    {
        public IQueryBuilder<T> Select(params string[] columnNames)
        {
            if (columnNames == null || columnNames.Length == 0)
            {
                throw new Exception(); // todo change this
            }

            if (query.Length > 0)
            {
                query.Length--;
            }

            query.Append("SELECT ");
            foreach (string columnName in columnNames)
            {
                query.AppendFormat("{0},", columnName);
            }
            if (columnNames.Length > 0)
            {
                query.Length--;
            }
            return this;
        }

        public IQueryBuilder<T> Where(OrmExpression expr)
        {
            if (query.Length > 0)
            {
                query.Length--;
            }

            query.Append(" WHERE ");
            query.AppendFormat("{0};", expr);
            return this;
        }
    }
}
