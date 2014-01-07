using System;

namespace Coirius.Orm
{
    internal interface IQueryBuilder<T>
    {
        IQueryBuilder<T> Select(params string[] columnNames);
        IQueryBuilder<T> Where(OrmExpression expr);
    }
}
