using System.Web.Mvc;
using Tms.Service.Vehicle;
using Unity;
using Unity.Mvc5;

namespace Tms
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IVehicleService, VehicleService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}