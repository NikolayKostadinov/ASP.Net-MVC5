using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart:IShoppingCart
    {
        private IValueCalculator calculator;
        public ShoppingCart(IValueCalculator calcParam) 
        {
            calculator = calcParam;
        }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public IEnumerable<Product> Products { get; set; }
        

        public decimal CalculateProductTotal() 
        {
            return calculator.ValueProducts(Products);
        }
    }
}