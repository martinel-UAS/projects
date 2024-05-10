using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "HomePage",
                "",
                new { controller = "Home", action = "Index" }
            );  

            routes.MapRoute(
                "ErrorPage",
                "",
                new { controller = "Error", action = "Index" }
            );

            routes.MapRoute(
                "MailError",
                "",
                new { controller = "Error", action = "Mail" }
            );

            routes.MapRoute(
                  "Catchall",
                  "{*anything}",
                  new { controller = "Error", action = "Index" }
                );
        }
    }
}
