using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmployeeTracker.Services.Common
{
    public interface IRepository
    {
        Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getDataFunc);
        SqlConnection GetConnection(bool multipleActiveSets = false);
    }
}