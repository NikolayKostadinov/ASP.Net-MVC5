using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Abstract;
using SportStore.WebUI.Models;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController" /> class.
        /// </summary>
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        //Get
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                                     .OrderBy(pr => pr.ProductID)
                                     .Where(pr => category == null || pr.Category == category)
                                     .Skip((page - 1) * PageSize)
                                     .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                            repository.Products.Count() : 
                            repository.Products.Where(x => x.Category == category).Count(),
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}