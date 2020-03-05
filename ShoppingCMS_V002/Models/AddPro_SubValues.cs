using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class AddPro_SubValues
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Id_ValueModel> Item_List { get; set; }
    }
}