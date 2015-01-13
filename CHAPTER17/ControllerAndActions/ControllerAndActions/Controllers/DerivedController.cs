using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerAndActions.Controllers
{
    public class DerivedController : Controller
    {
        //
        // GET: /Derived/
        public ActionResult Index()
        {
            ViewBag.Message = "Hello fromDerivedController Index method";
            return View("MyView");
        }

        public ActionResult Drama() 
        {
            return new HttpUnauthorizedResult();
        }
	}
}