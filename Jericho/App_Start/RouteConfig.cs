using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Jericho
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.Ignore("{resource}.ashx/{*pathInfo}");
            routes.Ignore(@"{resource}.asmx/{*pathInfo}");
            routes.Ignore("{resource}.aspx/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
            routes.MapMvcAttributeRoutes();
        }
    }
}