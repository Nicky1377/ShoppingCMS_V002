using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class UpdateProModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SEO_keyword { get; set; }
        public string SEO_Description { get; set; }
        public string IsAd { get; set; }
        public string Pics { get; set; }
        public int SearchGravity { get; set; }
    }
}