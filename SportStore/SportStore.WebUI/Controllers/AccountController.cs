using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.WebUI.Infrastructure.Abstract;
using SportStore.WebUI.Models;

namespace SportStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController" /> class.
        /// </summary>
        public AccountController(IAuthProvider providerParam)
        {
            this.authProvider = providerParam;
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    TempData["user"] = new UserViewModel { UserName = model.UserName };
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Logout(UserViewModel user, string returnUrl = null) 
        {
            authProvider.Logout();
            TempData["user"] = null;
            return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
        }
    }
}