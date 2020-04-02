using ShoppingCMS_V002.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCMS_V002.Controllers
{
    public class BlogAPI_DesignerController : Controller
    {
        // GET: BlogAPI_Designer
        public ActionResult Index()
        {
            string SSSession = ""; CheckAccess check = new CheckAccess(SSSession);
            if (check.HasAccess)
            {
                

                return View();
            }
            else
                return Content("No Access");
        }
    }
}