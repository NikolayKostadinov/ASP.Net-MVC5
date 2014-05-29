using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class DefaultDiscountHelper:IDiscountHelper
    {
        private decimal discountSize;
        public DefaultDiscountHelper(decimal discountSize) 
        {
            this.discountSize = discountSize;
        }
        /// <summary>
        /// Applies the discount.
        /// </summary>
        /// <param name="toptalParam">The toptal param.</param>
        /// <returns></returns>
        public decimal ApplyDiscount(decimal toptalParam)
        {
            return (toptalParam - (this.discountSize / 100m * toptalParam));
        }
    }
}