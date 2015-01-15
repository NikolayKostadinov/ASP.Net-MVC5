namespace SportStore.WebUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SportStore.Domain.Abstract;
    using SportStore.Domain.Entities;
    using SportStore.WebUI.Models;

    public class CartController : Controller
    {

        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repositoryParam, IOrderProcessor orderProccessorParam)
        {
            this.repository = repositoryParam;
            this.orderProcessor = orderProccessorParam;
        }

        public PartialViewResult Index(string returnUrl, Cart cart)
        {
            return PartialView(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl,
            });
        }

        public RedirectResult AddToCart(int productId, string returnUrl, Cart cart)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return Redirect(returnUrl);
        }

        public RedirectResult RemoveFromCart(int productId, string returnUrl, Cart cart)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return Redirect(returnUrl);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }


        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}