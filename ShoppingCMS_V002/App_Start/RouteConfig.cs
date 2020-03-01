using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingCMS_V002
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
     name: "Default",
     url: "{controller}/{action}",
     defaults: new { controller = "MS", action = "Index" }
 );

            routes.MapRoute(
                name: "Niky",
                url: "{controller}/{action}");

        }
    }
}
