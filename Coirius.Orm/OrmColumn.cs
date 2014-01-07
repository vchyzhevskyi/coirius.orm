using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
