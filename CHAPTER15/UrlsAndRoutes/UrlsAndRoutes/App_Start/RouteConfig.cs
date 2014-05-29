using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("AdditionalControllerRoute", "Home/{action}/{id}/{*catchall}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                }, new[] { "UrlsAndRoutes.AdditionalControllers" });
            
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                }, new[] { "UrlsAndRoutes.Controllers" });
            
            
        }
    }
}