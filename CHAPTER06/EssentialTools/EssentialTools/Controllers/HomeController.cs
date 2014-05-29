using System;
using System.Linq;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calculator;
        private IShoppingCart cart;
        private Product[] products =
                new Product[]
                {
                    new Product{Name="Kayak", Price=275M},
                    new Product{Name="Lifejacket", Price=48.95M},
                    new Product{Name="Soccer ball", Price=19.50M},
                    new Product{Name="Corner Flag", Price=34.95M},
                };
        public HomeController(IValueCalculator calculator, IShoppingCart cart, IValueCalculator calc)
        {
            this.calculator = calculator;
            this.cart = cart;
            cart.Products = this.products;
        }

        public ActionResult Index()
        {
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}