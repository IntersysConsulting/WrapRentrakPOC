using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WrapRentrak.Data.Infrastructure;
using WrapRentrak.Data.Repositories;
using WrapRentrak.Reports.Service;
using WrapRentrakWeb1.Mappings;

namespace WrapRentrakWeb1.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();

            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
 
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDBFactory>().InstancePerRequest();
 
            // Repositories
            builder.RegisterAssemblyTypes(typeof(ReportRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(ReportService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
 
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    
    }
}