using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class opinion
    {
        public string id_MProduct { get; set; }
        public string id_Customer { get; set; }
        public string id_AccByAdmin { get; set; }
        public string CreateDate { get; set; }
        public string DateAccepted { get; set; }
        public string Is_Accepted { get; set; }
        public string OpinionDescription { get; set; }
        public string Rate { get; set; }
        public string ISDELETE { get; set; }
        public string id_Opinion { get; set; }
    }
}