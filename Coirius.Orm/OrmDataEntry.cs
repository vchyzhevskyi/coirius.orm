
namespace Coirius.Orm
{
    public class OrmDataEntry
    {
        private OrmColumn[] columns;

        public OrmColumn[] Columns
        {
            get { return columns; }
            internal set { columns = value; }
        }
    }
}
