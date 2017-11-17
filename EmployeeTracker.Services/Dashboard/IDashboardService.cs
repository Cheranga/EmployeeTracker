using System.Threading.Tasks;

namespace EmployeeTracker.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<Dashboard> GetDashboardSettingAsync();
    }
}