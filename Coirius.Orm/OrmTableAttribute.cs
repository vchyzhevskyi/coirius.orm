using System;

namespace Coirius.Orm
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class OrmDataEntryAttribute : Attribute
    {
        public string Name { get; set; }
        public string TableName { get; set; }
    }
}
