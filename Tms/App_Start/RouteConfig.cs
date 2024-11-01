using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tms
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vehicle", action = "List", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Vehicles",
            //    url: "",
            //    defaults: new { controller = "Vehicle", action = "List" }
            //);
        }
    }
}
