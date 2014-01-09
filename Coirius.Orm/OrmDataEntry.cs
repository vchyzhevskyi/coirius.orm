
namespace Coirius.Orm
{
    public class OrmDataEntry
    {
        private OrmColumn[] columns;

        protected OrmColumn[] Columns
        {
            get { return columns; }
            internal set { columns = value; }
        }
    }
}
