using ShoppingCMS_V002.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.ModelViews
{
    public class AddProductModelV_3
    {
        public int Id { get; set; }
        public List<AddPro_SubValues> Item_List { get; set; }
        public AddPro_Options OptionItem { get; set; }

    }
}