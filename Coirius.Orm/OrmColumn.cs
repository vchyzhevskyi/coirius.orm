
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

        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
