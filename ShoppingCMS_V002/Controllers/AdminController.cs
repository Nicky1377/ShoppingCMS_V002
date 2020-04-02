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

        public ActionResult ModalTree(int id=0)
        {
            string SSSession = ""; CheckAccess check = new CheckAccess(SSSession);
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();

                return View(MF.Modal_admin_Type(id));
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult AdminTbl()
        {
            string SSSession = ""; CheckAccess check = new CheckAccess(SSSession);
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();

                return View(MF.AdminTypeTbl());
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult Add_Update_AdminType(string ActToDo, string Ad_Name,string Routes,int id=0)
        {
            string SSSession = ""; CheckAccess check = new CheckAccess(SSSession);
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();

                return Content(MF.Add_Update_AdType_( ActToDo, Ad_Name, Routes, id));
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
    }
}