using System.Collections.Generic;
using System.Data.SqlClient;

namespace Coirius.Orm
{
    static class OrmHelper
    {
        internal static OrmDataEntry GetOrmDataEntry(this SqlDataReader reader)
        {
            OrmDataEntry result = new OrmDataEntry();
            List<OrmColumn> columns = new List<OrmColumn>();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                OrmColumn column = new OrmColumn
                {
                    Name = reader.GetName(i),
                    Type = reader.GetDbType(i),
                    Value = reader.GetValue(i)
                };
                columns.Add(column);
            }
            result.Columns = columns.ToArray();
            return result;
        }

        internal static DbType GetDbType(this SqlDataReader reader, int i)
        {
            // todo debug this and extend switch
            switch (reader.GetFieldType(i).Name)
            {
                default:
                    break;
            }
            return DbType.Unknown;
        }
    }
}
