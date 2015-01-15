namespace SportStore.WebUI.Infrastructure.Binders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SportStore.WebUI.Models;

    public class UserModelBinder:IModelBinder
    {
        private const string sessionKey = "user";
        /// <summary>
        /// Binds the model to a value by using the specified controller context
        /// and binding context.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The bound value.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            UserViewModel user = null;
            if (controllerContext.HttpContext.Session != null)
            {
                user = (UserViewModel)controllerContext.HttpContext.Session[sessionKey];
            }

            if (user==null)
            {
                user = new UserViewModel { UserName = null };
            }
            // return the cart
            return user;
        }
    }
}