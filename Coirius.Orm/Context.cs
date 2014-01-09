using Coirius.Orm.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Coirius.Orm
{
    public class Context : IDisposable
    {
        private SqlConnection connection;
        private string connectionString;

        #region Properties
        public string ConnectionString
        {
            get { return this.connectionString; }
        }

        protected SqlConnection Connection
        {
            get { return this.connection; }
        }
        #endregion

        public Context(string connectionString)
        {
            this.connectionString = connectionString;
            this.connection = new SqlConnection(this.ConnectionString);
            this.connection.Open();
        }

        /// <summary>
        /// Adds object to database table
        /// Orm will automatically detect type of object and add to properly configured table
        /// </summary>
        /// <param name="entity"></param>
        public void Add(object entity)
        {
            if (this.Connection == null)
            {
                throw new OrmConnectionConfigurationException();
            }
        }

        /// <summary>
        /// Executes scalar query on context
        /// </summary>
        /// <param name="query">An instance of IQueryBuilder</param>
        /// <returns></returns>
        public OrmDataEntry ExecScalar(IQueryBuilder query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Executes query on context
        /// </summary>
        /// <param name="query">An instance of IQueryBuilder</param>
        /// <returns></returns>
        public OrmDataEntry[] Exec(IQueryBuilder query)
        {
            SqlDataReader reader = null;
            SqlCommand command = null;
            try
            {
                command = new SqlCommand(query.ToString(), this.connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<OrmDataEntry> result = new List<OrmDataEntry>();
                    while (reader.Read())
                    {
                        result.Add(reader.GetOrmDataEntry());
                    }
                    return result.ToArray();
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.connection.Close();
                this.connection.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
