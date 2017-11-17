using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTracker.Services.Common
{
    public interface IConnection
    {
        string ConnectionString { get; set; }
    }
}
