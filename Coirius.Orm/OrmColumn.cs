
namespace Coirius.Orm
{
    public class OrmColumn
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private DbType type;

        internal DbType Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
