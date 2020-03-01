using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class MainCategory
    {
        public string id_MC { get; set; }
        public string id_PT { get; set; }
        public string MCName { get; set; }
        public string ISDESABLED { get; set; }
        public string ISDelete { get; set; }
        public string DateDesabled { get; set; }
        public string DateDeleted { get; set; }
        public string count { get; set; }

    }
}