using ShoppingCMS_V002.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.ModelViews
{
    public class AddProductModelV_4
    {
        public List<Id_ValueModel> PriceType { get; set; }
        public List<Id_ValueModel> QuantityTypes { get; set; }
        public List<Id_ValueModel> OffTypes { get; set; }
        public List<Id_ValueModel> PriceShow { get; set; }
        public List<Id_ValueModel> Tags { get; set; }
        public List<Id_ValueModel> MainTags { get; set; }

    }
}