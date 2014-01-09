using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Coirius.Orm
{
    static class OrmHelper
    {
        internal static Dictionary<string, DbType> TypeMap = new Dictionary<string, DbType>()
        {
            {"Int32", DbType.Int},
            {"String", DbType.String},
            {"Xml", DbType.Xml}
        };

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
            try
            {
                return OrmHelper.TypeMap.FirstOrDefault(x => x.Key == reader.GetFieldType(i).Name).Value;
            }
            catch (NullReferenceException)
            {
                return DbType.Unknown;
            }
        }
    }
}
