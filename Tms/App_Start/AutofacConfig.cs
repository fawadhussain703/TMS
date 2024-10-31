using Autofac;
using Tms.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace Tms.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            // var configuration = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();

            var serviceAssembly = Assembly.GetAssembly(typeof(BaseService));
            //builder.RegisterAssemblyTypes(serviceAssembly).Where(t => t.BaseType == typeof(BaseService)).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(serviceAssembly).Where(t => t.BaseType == typeof(BaseService)).InstancePerRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterApiControllers(typeof(ApiController).Assembly);
            builder.RegisterFilterProvider();

            var container = builder.Build();

            var mvcResolver = new Autofac.Integration.Mvc.AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}