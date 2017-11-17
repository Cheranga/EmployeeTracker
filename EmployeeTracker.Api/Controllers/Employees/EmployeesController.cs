using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EmployeeTracker.Services.Employees;

namespace EmployeeTracker.Api.Controllers.Employees
{
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("")]
        public async Task<IHttpActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            var employeeArray = employees as Employee[] ?? employees.ToArray();

            if (employees == null || employeeArray.Any() == false)
            {
                return NotFound();
            }

            return Ok(employeeArray);
        }
    }
}