using System.Collections.Generic;
using EmployeeTracker.Services.Chart;

namespace EmployeeTracker.Services.Dashboard
{
    public interface IDashboard
    {
        int TotalPositions { get; set; }
        int TotalOffices { get; set; }
        int TotalEmployees { get; set; }

        IEnumerable<ChartData> EmployeesPerYear { get; set; }
        IEnumerable<ChartData> EmployeesPerOffice { get; set; }
    }
}