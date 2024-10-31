using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Tms.Models;
using Tms.Service.Vehicle;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Tms
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            
            container.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());

            
          //  container.RegisterType<IVehicleService, VehicleService>();

            
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());

            
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(c =>
            {
                var context = HttpContext.Current.GetOwinContext();
                return context?.Authentication;
            }));

            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}