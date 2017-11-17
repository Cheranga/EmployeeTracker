using System.Collections.Generic;
using EmployeeTracker.Services.Chart;

namespace EmployeeTracker.Services.Dashboard
{
    public class Dashboard : IDashboard
    {
        public int TotalPositions { get; set; }
        public int TotalOffices { get; set; }
        public int TotalEmployees { get; set; }
        public IEnumerable<ChartData> EmployeesPerYear { get; set; }
        public IEnumerable<ChartData> EmployeesPerOffice { get; set; }
    }
}