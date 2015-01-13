namespace SportStore.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PagingInfo
    {
        
        /// <summary>
        /// Gets or sets the total items.
        /// </summary>
        /// <value>The total items.</value>
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the items per page.
        /// </summary>
        /// <value>The items per page.</value>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)this.TotalItems / this.ItemsPerPage);  
            }
        }
    }
}