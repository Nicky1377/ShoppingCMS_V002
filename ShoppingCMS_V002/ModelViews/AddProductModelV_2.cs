using ShoppingCMS_V002.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.ModelViews
{
    public class AddProductModelV_2
    {
        public int Id { get; set; }
        public IEnumerable<Id_ValueModel> Types { get; set; }

        public IEnumerable<Id_ValueModel> MainCats { get; set; }

        public IEnumerable<Id_ValueModel> SubCats { get; set; }

        public AddProduct_P2 GetAddProduct_P2 { get; set; }
    }
}