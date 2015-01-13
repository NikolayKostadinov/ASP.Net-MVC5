﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        public IEnumerable<Product> Products
        {
            get
            {
                return this.context.Products;
            }
        }
    }
}