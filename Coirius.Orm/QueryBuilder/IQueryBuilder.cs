
namespace Coirius.Orm
{
    public interface IQueryBuilder
    {
        IQueryBuilder Select(params string[] columnNames);
        IQueryBuilder Where(OrmExpression expr);
        IQueryBuilder OrderBy(string columnName, OrmOrderBy by);
    }
}
