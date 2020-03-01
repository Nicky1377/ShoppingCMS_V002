using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class AddProduct_P2
    {
        public int TypeId { get; set; }
        public int MainCatId { get; set; }
        public int SubCatId { get; set; }
        public List<int> SCKeys { get; set; }

    }
}