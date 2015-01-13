namespace SportStore.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SportStore.Domain.Entities;

    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}