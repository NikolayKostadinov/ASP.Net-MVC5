namespace SportStore.WebUI.Infrastructure.Binders
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using SportStore.Domain.Entities;

    public class CartModelBinder:IModelBinder
    {
        private const string sessionKey = "Cart";
        
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
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            // return the cart
            return cart;
        }
    }
}