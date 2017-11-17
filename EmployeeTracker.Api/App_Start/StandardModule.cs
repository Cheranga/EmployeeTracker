using System;
using System.Configuration;
using Autofac;
using Autofac.Core;
using EmployeeTracker.Services.Common;
using EmployeeTracker.Services.Dashboard;
using EmployeeTracker.Services.Employees;

namespace EmployeeTracker.Api
{
    public class StandardModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var con = ConfigurationManager.ConnectionStrings["DbConnection"];
            builder.RegisterType<Connection>().As<IConnection>().WithParameter("settings", con).InstancePerRequest();

            builder.RegisterType<Repository>().As<IRepository>().InstancePerRequest();

            builder.RegisterType<DashboardService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<EmployeeService>().AsImplementedInterfaces().InstancePerRequest();
        }
    }
}