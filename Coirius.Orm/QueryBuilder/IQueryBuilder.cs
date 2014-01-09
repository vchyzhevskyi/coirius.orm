
namespace Coirius.Orm
{
    public interface IQueryBuilder
    {
        IQueryBuilder From(string tableName);
        IQueryBuilder Select(params string[] columnNames);
        IQueryBuilder Where(OrmExpression expr);
        IQueryBuilder OrderBy(string columnName, OrmOrderBy by);
        IQueryBuilder Take(int count);

        string ToString();
    }
}
