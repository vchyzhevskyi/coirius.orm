using Coirius.Orm.Exceptions;
using System;
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
