using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Services.Employees
{
    public interface IEmployee
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Position { get; set; }
        string Office { get; set; }
        char Sex { get; set; }
        int Age { get; set; }
        DateTime StartDate { get; set; }
        decimal Salary { get; set; }
    }
}
