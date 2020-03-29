using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class AdminTypeRoutesModel
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public List<RouteModel> RouteList { get; set; }

    }
}