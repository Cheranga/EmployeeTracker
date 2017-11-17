using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using EmployeeTracker.Services.Common;

namespace EmployeeTracker.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private const string SpGetEmployees = "GetEmployees";

        private readonly IRepository _repository;

        public EmployeeService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return _repository.WithConnection(async connection =>
            {
                return await connection.QueryAsync<Employee>(SpGetEmployees, commandType: CommandType.StoredProcedure);
            });
        }
    }
}