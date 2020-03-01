using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class ProductModel
    {
        public int Num { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicPath { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public string MainPrice { get; set; }
        public string AddBy { get; set; }
        public bool deleted { get; set; }
        public bool disabled { get; set; }

    }
}