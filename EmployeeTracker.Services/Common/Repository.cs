using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmployeeTracker.Services.Common
{
    public class Repository : IRepository
    {
        private readonly IConnection _connection;

        public Repository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getDataFunc)
        {
            try
            {
                using (var connection = new SqlConnection(_connection.ConnectionString))
                {
                    await connection.OpenAsync();
                    return await getDataFunc(connection);
                }
            }
                // TODO: Add logging
            catch (TimeoutException timeoutException)
            {
                throw;
            }
            catch (SqlException sqlException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public SqlConnection GetConnection(bool multipleActiveSets = false)
        {
            try
            {
                if (multipleActiveSets)
                {
                    _connection.ConnectionString = new SqlConnectionStringBuilder(_connection.ConnectionString)
                    {
                        MultipleActiveResultSets = true
                    }.ConnectionString;
                }

                var connection = new SqlConnection(_connection.ConnectionString);
                return connection;
            }
            catch (TimeoutException timeoutException)
            {
                throw;
            }
            catch (SqlException sqlException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}