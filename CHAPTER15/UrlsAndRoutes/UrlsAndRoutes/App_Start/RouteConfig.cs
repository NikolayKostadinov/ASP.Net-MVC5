using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.MapRoute("CustomeConstraintRoute", "Customer/List/{id}/{*catchall}",
                new
                {
                    controller= "Customer",
                    action="List",
                    id = UrlParameter.Optional
                },
                new
                {
                    customConstraint = new UserAgentConstraint("Chrome")
                });

            routes.MapRoute("DefaultRoute", "{controller}/{action}/{id}/{*catchall}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = 0
                },
                new
                {
                    controller = "^H.*",
                    action = "^Index$|^About$|^CustomVariable$",
                    httpMethod = new HttpMethodConstraint("GET"),
                    id = new IntRouteConstraint()
                },
                new[] { "UrlsAndRoutes.Controllers" });
        }
    }
}