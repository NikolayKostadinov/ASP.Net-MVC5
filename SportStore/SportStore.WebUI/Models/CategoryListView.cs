using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.WebUI.Models
{
    public class CategoryListView
    {
        public IEnumerable<string> Categories { get; set; }
        public string CurrentCategory { get; set; }
    }
}