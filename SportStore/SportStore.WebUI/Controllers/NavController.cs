namespace SportStore.WebUI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SportStore.Domain.Abstract;
    using SportStore.WebUI.Models;

    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repositoryPram)
        {
            this.repository = repositoryPram;
        }

        [ChildActionOnly]
        public PartialViewResult Menu(string category = null)
        {
            var categories = new CategoryListView 
            {
                Categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x),
                CurrentCategory = category
            };
            return PartialView(categories);
        }
    }
}