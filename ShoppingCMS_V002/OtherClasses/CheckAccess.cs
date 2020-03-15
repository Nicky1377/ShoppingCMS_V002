using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.OtherClasses
{
    public class CheckAccess
    {
        public bool HasAccess { get; set; }
        public string exs = "Logged In";
        public CheckAccess(string sessionss)
        {
            HasAccess = true;
            //try
            //{
            //    if (!string.IsNullOrEmpty(sessionss))
            //    {
            //        exs += "HttpContext.Current.Session[\"login\"] != null \n";
            //        if (sessionss == "1")
            //        {
            //            HttpContext.Current.Session["login"] = "1";
            //            exs += "HttpContext.Current.Session[\"login\"] == 1 \n";
            //            HasAccess = true;

            //        }
            //        else
            //        {
            //            HasAccess = false;
            //            exs += "HttpContext.Current.Session[\"login\"] != 1 \n";
            //        }
            //    }
            //    else
            //    {
            //        HasAccess = false;
            //        exs += "HttpContext.Current.Session[\"login\"] == null \n";
            //    }
            //}
            //catch (Exception e)
            //{
            //    HasAccess = false;
            //    exs += "\n" + e.ToString();
            //}
        }
    }
}