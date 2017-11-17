using System;
using System.Configuration;

namespace EmployeeTracker.Services.Common
{
    public class Connection : IConnection
    {
        public Connection(ConnectionStringSettings connectionStringSettings)
        {
            if (connectionStringSettings == null)
            {
                throw new ArgumentNullException("connectionStringSettings", "ConnectionString must be injected");
            }

            ConnectionString = connectionStringSettings.ConnectionString;
        }

        public string ConnectionString { get; set; }
    }
}