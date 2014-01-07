using Coirius.Orm.Exceptions;
using System;
using System.Data.SqlClient;

namespace Coirius.Orm
{
    public sealed class Context : IDisposable
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

        public void Dispose()
        {
            if (this.connection != null)
            {
                this.connection.Dispose();
            }
        }
    }
}
