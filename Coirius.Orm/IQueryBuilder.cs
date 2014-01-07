using System;

namespace Coirius.Orm
{
    public interface IQueryBuilder
    {
        IQueryBuilder Select(params string[] columnNames);
        IQueryBuilder Where(OrmExpression expr);
    }
}
