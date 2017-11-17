using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using EmployeeTracker.Services.Common;
using Dapper;
using EmployeeTracker.Services.Chart;

namespace EmployeeTracker.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        //
        // TODO: Put all magic strings (sps, queries in a constant file)
        //
        private const string SpGetDashboardSetting = "GetDashboardSetting";

        private readonly IRepository _repository;

        public DashboardService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<Dashboard> GetDashboardSettingAsync()
        {
            return _repository.WithConnection(async connection =>
            {
                var reader = await connection.QueryMultipleAsync(SpGetDashboardSetting, commandType: CommandType.StoredProcedure);

                var totalPositions = await reader.ReadSingleOrDefaultAsync<int>();
                var totalOffices = await reader.ReadSingleOrDefaultAsync<int>();
                var totalEmployees = await reader.ReadSingleOrDefaultAsync<int>();
                var employeeCountPerYear = await reader.ReadAsync<ChartData>();
                var employeeCountPerOffice = await reader.ReadAsync<ChartData>();

                return new Dashboard
                {
                    TotalPositions = totalPositions,
                    TotalOffices = totalOffices,
                    TotalEmployees = totalEmployees,
                    EmployeesPerYear = employeeCountPerYear,
                    EmployeesPerOffice = employeeCountPerOffice
                };
            });
        }
    }
}