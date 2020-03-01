using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class SubCategoryOptionKey
    {
        public string id_SCOK { get; set; }
        public string id_SC { get; set; }
        public string SCOKName { get; set; }
        public string ISDESABLED { get; set; }
        public string ISDelete { get; set; }
        public string DateDesabled { get; set; }
        public string DateDeleted { get; set; }
        public string count { get; set; }
    }
}