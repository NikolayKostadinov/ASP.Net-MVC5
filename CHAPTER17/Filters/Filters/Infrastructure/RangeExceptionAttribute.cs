using System;
using System.Linq;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class RangeExceptionAttribute:FilterAttribute,IExceptionFilter
    {
        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && 
                filterContext.Exception is ArgumentOutOfRangeException) 
            {
                int val = (int)(((ArgumentOutOfRangeException)filterContext.Exception).ActualValue);
                filterContext.Result = new ViewResult
                {
                    ViewName="RangeError",
                    ViewData=new ViewDataDictionary<int>(val)
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}