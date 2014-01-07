
namespace Coirius.Orm
{
    public abstract class OrmExpression
    {
    }

    public class EqualExpression : OrmExpression
    {
        private OrmColumn column;
        private object value;

        public EqualExpression(OrmColumn column, object value)
        {
            this.column = column;
            this.value = value;
        }

        public override string ToString()
        {
            return string.Format("({0} = {1})", column.Name, this.value);
        }
    }

    public class AndExpression : OrmExpression
    {
        private OrmExpression expr1;
        private OrmExpression expr2;

        public AndExpression(OrmExpression expr1, OrmExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public override string ToString()
        {
            return string.Format("({0}) AND ({1})", this.expr1.ToString(), this.expr2.ToString());
        }
    }
}
