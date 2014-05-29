using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator: IValueCalculator
    {
        private IDiscountHelper discounter;
        private static int instanceNumber;

        public LinqValueCalculator(IDiscountHelper discounterParam) 
        {
            this.discounter = discounterParam;
            Debug.WriteLine("Instance {0} created", ++instanceNumber);
        }
        public decimal ValueProducts(IEnumerable<Product> products) 
        {
            return discounter.ApplyDiscount( products.Sum(x => x.Price));
        }
    }
}