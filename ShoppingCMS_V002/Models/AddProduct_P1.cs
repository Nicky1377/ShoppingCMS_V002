using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class AddProduct_P1
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SEO_description { get; set; }
        public string SEO_keyword { get; set; }
        public int SearchGravity { get; set; }
        public bool IsAd { get; set; }
        public List<Pictures> pictures { get; set; }
    }
}