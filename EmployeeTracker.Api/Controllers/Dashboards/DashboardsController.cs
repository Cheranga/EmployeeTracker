using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EmployeeTracker.Services.Dashboard;

namespace EmployeeTracker.Api.Controllers.Dashboards
{
    [RoutePrefix("api/dashboards")]
    public class DashboardsController : ApiController
    {
        private readonly IDashboardService _dashboardService;

        public DashboardsController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [Route("")]
        public async Task<IHttpActionResult> GetDashboardSetting()
        {
            var dashboardSettings = await _dashboardService.GetDashboardSettingAsync();

            if (dashboardSettings == null)
            {
                return NotFound();
            }

            return Ok(dashboardSettings);
        }
    }
}