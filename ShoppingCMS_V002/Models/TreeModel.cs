using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class TreeModel
    {
        public int Id { get; set; }
        public string NameSub { get; set; }
        public bool IsActive { get; set; }
        public List<TreeModel> Subs { get; set; }
    }
}