using ShoppingCMS_V002.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCMS_V002.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AddAdminType()
        {
            string SSSession = ""; CheckAccess check = new CheckAccess(SSSession);
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();

                return View(MF.AdminTypeFiller());
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
    }
}