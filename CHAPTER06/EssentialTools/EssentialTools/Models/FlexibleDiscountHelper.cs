using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class FlexibleDiscountHelper:IDiscountHelper
    {
        /// <summary>
        /// Applies the discount.
        /// </summary>
        /// <param name="toptalParam">The toptal param.</param>
        /// <returns></returns>
        public decimal ApplyDiscount(decimal toptalParam)
        {
            decimal discount = toptalParam > 100 ? 70 : 25;
            return (toptalParam - (discount / 100M * toptalParam));
        }
    }
}