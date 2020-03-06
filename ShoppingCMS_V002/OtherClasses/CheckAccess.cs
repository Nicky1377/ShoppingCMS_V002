using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.OtherClasses
{
    public class CheckAccess
    {
        public bool HasAccess { get; set; }

        public CheckAccess()
        {
            HasAccess = true;
        }
    }
}