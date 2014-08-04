using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerAndActions.Controllers
{
    public class BasicController:IController
    {
        /// <summary>
        /// Executes the specified request context.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
     [Route("Basic")]
        public void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];
            requestContext.HttpContext.Response.Write(
                string.Format("Controller: <b>{0}</b>, action: <b>{1}</b>",controller,action)
                );
        }
    }
}