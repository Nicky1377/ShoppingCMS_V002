using ShoppingCMS_V002.DBConnect;
using ShoppingCMS_V002.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Web.UI.WebControls;
using ShoppingCMS_V002.OtherClasses;

namespace ShoppingCMS_V002.Controllers
{
    public class MSController : Controller
    {
        /////////////////////////////{   START Index   }//////////////////////////////
        public TypeASPX model;
        public type data_type;
        List<type> list_dat = new List<type>();
        // GET: MS


        public ActionResult NotAccess()
        {
            return View();
        }
        
        /////////////////////////////////////////////////////////// Index : get
        [HttpGet]
        public ActionResult Index()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");
        }
        /////////////////////////////////////////////////////////// New_type : get

        public ActionResult Add_Type()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");
        }

        [HttpGet]
        public ActionResult New_type()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                model = new TypeASPX();
                if (Session["edit"] != null)
                {
                    model = (TypeASPX)Session["edit"];
                    ViewBag.model = model;
                }
                else
                {
                    ViewBag.model = model;
                }
                return View();
            }
            else
                return RedirectToAction("NotAccess");

        }
        /////////////////////////////////////////////////////////// TypePage : post
        [HttpPost]
        public ActionResult TypePage(string action, string value, string id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string query_new, query_edit;
                string res = " ";


                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                if (action == "new")
                {

                    query_new = "INSERT INTO [tbl_Product_Type]([PTname],[ISDESABLED],[ISDelete])VALUES(@PTname,0,0)";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@PTname",
                        _VALUE = value
                    };
                    paramss.Add(parameters);

                    res = db.Script(query_new, paramss);

                }

                else if (action == "edit")
                {

                    query_edit = "UPDATE [tbl_Product_Type] SET [PTname] = @PTname WHERE id_PT =@id_PT";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@id_PT",
                        _VALUE = id
                    };

                    paramss.Add(parameters);

                    parameters = new ExcParameters()
                    {
                        _KEY = "@PTname",
                        _VALUE = value
                    };

                    paramss.Add(parameters);

                    res = db.Script(query_edit, paramss);

                }

                return Content(res);

            }
            else
                return RedirectToAction("NotAccess");

        }
        //////////////////////////////////////////////////// list type : get
        public ActionResult table_Type()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string query_type;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                // query_type = "SELECT [id_PT],[PTname],[ISDESABLED],[ISDelete] FROM [dbo].[tbl_Product_Type]";
                query_type = "select [id_PT] ,[PTname],[ISDESABLED],[ISDelete],( select count (id_SC) from [tbl_Product_SubCategoryOptionKey] where id_SC in ( select id_SC from [tbl_Product_SubCategory] where id_MC in ( select id_MC from [tbl_Product_MainCategory] where [id_PT]=[tbl_Product_Type].[id_PT] )))  as 'count' from [tbl_Product_Type]";
                using (DataTable dt = db.Select(query_type))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_type = new type();

                        data_type.id_PT = dt.Rows[i]["id_PT"].ToString();
                        data_type.PTname = dt.Rows[i]["PTname"].ToString();
                        data_type.ISDelete = dt.Rows[i]["ISDelete"].ToString();
                        data_type.ISDESABLED = dt.Rows[i]["ISDESABLED"].ToString();
                        data_type.count = dt.Rows[i]["count"].ToString();
                        list_dat.Add(data_type);
                    }
                    ViewBag.type = list_dat;
                }

                return View();

            }
            else
                return RedirectToAction("NotAccess");


        }
        /////////////////////////////////////////////////////////// list type : post
        [HttpPost]
        public ActionResult Type_Switch(string action, string id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string str = " ", query;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                parameters = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = id
                };

                paramss.Add(parameters);

                if (action == "edit")
                {
                    using (DataTable dt = db.Select($"SELECT [id_PT],[PTname] FROM [tbl_Product_Type] where id_PT= '{id}'"))
                    {
                        model = new TypeASPX()
                        {
                            ChangeID = dt.Rows[0]["id_PT"].ToString(),
                            HasChange = true,
                            ChangeValue = dt.Rows[0]["PTname"].ToString()
                        };

                        Session["edit"] = model;
                        return RedirectToAction("New_type");

                    };
                }
                else if (action == "delete")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [tbl_Product_Type] SET [ISDelete] = @value ,[DateDeleted] = GETDATE() WHERE id_PT = @id_PT";

                    str = db.Script(query, paramss);
                    db.Script("UPDATE [tbl_Product]SET[ISDELETE] = 1 WHERE [id_Type]=" + id);
                    db.Script("UPDATE P SET P.ISDelete=1,P.DateDeleted= GETDATE() FROM[tbl_Product_SubCategory] AS P inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=" + id);
                    db.Script("UPDATE [tbl_Product_MainCategory] SET ISDelete = 1 , DateDeleted= GETDATE() WHERE id_PT=" + id);
                    db.Script("UPDATE R SET R.ISDelete=1,R.DateDeleted= GETDATE() FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=" + id);
                }
                else if (action == "off")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE[tbl_Product_Type] SET [ISDESABLED] = @value ,[DateDesabled] = GETDATE()  WHERE id_PT = @id_PT";

                    str = db.Script(query, paramss);
                    db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 0 WHERE [id_Type]=" + id);
                    db.Script("UPDATE P SET P.ISDESABLED=1,P.DateDesabled= GETDATE() FROM[tbl_Product_SubCategory] AS P inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=" + id);
                    db.Script("UPDATE [tbl_Product_MainCategory] SET ISDESABLED = 1 , DateDesabled= GETDATE() WHERE id_PT=" + id);
                    db.Script("UPDATE R SET R.ISDESABLED=1,R.DateDesabled= GETDATE() FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=" + id);
                }
                else if (action == "on")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "0"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE[tbl_Product_Type] SET [ISDESABLED] = @value ,[DateDesabled] = GETDATE() WHERE id_PT = @id_PT";

                    str = db.Script(query, paramss);
                    db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 1 WHERE [id_Type]=" + id);
                    db.Script("UPDATE P SET P.ISDESABLED=0 FROM[tbl_Product_SubCategory] AS P inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=" + id);
                    db.Script("UPDATE [tbl_Product_MainCategory] SET ISDESABLED = 0 WHERE id_PT=" + id);
                    db.Script("UPDATE R SET R.ISDESABLED=0 FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=" + id);

                }
                return RedirectToAction("table_Type");

            }
            else
                return RedirectToAction("NotAccess");

        }

        ///------///////////////////////{   End Index   }//////////////////////////////


        //////////////////////////{   START maincat   }//////////////////////////////
        public MainCategory data_cat;
        List<MainCategory> list_cat = new List<MainCategory>();
        /////////////////////////////////////////////////////////// maincat : get
        [HttpGet]
        public ActionResult maincat()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");

        }
        /////////////////////////////////////////////////////////// New_Cat : get
        [HttpGet]
        public ActionResult New_Cat()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                model = new TypeASPX();
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                using (DataTable dt = db.Select("SELECT [id_PT],[PTname] FROM [tbl_Product_Type]WHERE ISDelete=0 AND ISDESABLED=0"))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_type = new type();



                        data_type.id_PT = dt.Rows[i]["id_PT"].ToString();
                        data_type.PTname = dt.Rows[i]["PTname"].ToString();
                        list_dat.Add(data_type);

                    }
                    ViewBag.Cat = list_dat;
                };


                if (Session["edit_cat"] != null)
                {
                    model = (TypeASPX)Session["edit_cat"];
                    ViewBag.model = model;
                }
                else
                {
                    ViewBag.model = model;
                }

                return View();

            }
            else
                return RedirectToAction("NotAccess");

        }
        /////////////////////////////////////////////////////////// CatPage : post
        [HttpPost]
        public ActionResult CatPage(string action, string value, string id, string data_typa)
        {

            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {


                string query_new, query_edit;
                string res = " ";


                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                if (action == "new")
                {

                    query_new = "INSERT INTO [tbl_Product_MainCategory]([id_PT],[MCName],[ISDESABLED],[ISDelete])VALUES (@data_typa, @value,0,0)";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = value
                    };
                    paramss.Add(parameters);

                    parameters = new ExcParameters()
                    {
                        _KEY = "@data_typa",
                        _VALUE = data_typa
                    };
                    paramss.Add(parameters);

                    res = db.Script(query_new, paramss);

                }

                else if (action == "edit")
                {

                    query_edit = "UPDATE [tbl_Product_MainCategory]SET [MCName] = @value WHERE id_MC = @id ";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@id",
                        _VALUE = id
                    };

                    paramss.Add(parameters);

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = value
                    };

                    paramss.Add(parameters);


                    res = db.Script(query_edit, paramss);

                }

                return Content(res);

            }
            else
                return RedirectToAction("NotAccess");
        }
        //////////////////////////////////////////////////// list cat : get
        public ActionResult table_Cat()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string query_type;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                query_type = "SELECT [id_MC],[id_PT],[MCName],[ISDESABLED],[ISDelete],(select PTname from [tbl_Product_Type]where [id_PT]=[tbl_Product_MainCategory].[id_PT] ) as 'name_PT',( select count (id_SC) from [tbl_Product_SubCategoryOptionKey] where id_SC in( select id_SC from[tbl_Product_SubCategory] where id_MC =[tbl_Product_MainCategory].[id_MC] ))  as 'count' FROM [tbl_Product_MainCategory]";
                // query_type = "select [id_PT] ,[PTname],[ISDESABLED],[ISDelete],( select count (id_SC) from [dbo].[tbl_Product_SubCategoryOptionKey] where id_SC in ( select id_SC from [dbo].[tbl_Product_SubCategory] where id_MC in ( select id_MC from [dbo].[tbl_Product_MainCategory] where [id_PT]=[dbo].[tbl_Product_Type].[id_PT] )))  as 'count' from [dbo].[tbl_Product_Type]";
                using (DataTable dt = db.Select(query_type))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_cat = new MainCategory();

                        data_cat.id_MC = dt.Rows[i]["id_MC"].ToString();
                        data_cat.id_PT = dt.Rows[i]["name_PT"].ToString();
                        data_cat.MCName = dt.Rows[i]["MCName"].ToString();
                        data_cat.ISDelete = dt.Rows[i]["ISDelete"].ToString();
                        data_cat.ISDESABLED = dt.Rows[i]["ISDESABLED"].ToString();
                        data_cat.count = dt.Rows[i]["count"].ToString();
                        list_cat.Add(data_cat);
                    }
                    ViewBag.Cats = list_cat;
                }

                return View();

            }
            else
                return RedirectToAction("NotAccess");
        }
        /////////////////////////////////////////////////////////// list cat : post
        [HttpPost]
        public ActionResult Cat_Switch(string action, string id)
        {

            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string str = " ", query;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                parameters = new ExcParameters()
                {
                    _KEY = "@id_MC",
                    _VALUE = id
                };

                paramss.Add(parameters);

                if (action == "edit")
                {
                    using (DataTable dt = db.Select($"SELECT [id_MC],[MCName]FROM [tbl_Product_MainCategory] where id_MC= '{id}'"))
                    {
                        model = new TypeASPX()
                        {
                            ChangeID = dt.Rows[0]["id_MC"].ToString(),
                            HasChange = true,
                            ChangeValue = dt.Rows[0]["MCName"].ToString()
                        };

                        Session["edit_cat"] = model;
                        return RedirectToAction("New_Cat");

                    };
                }
                else if (action == "delete")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [tbl_Product_MainCategory] SET [ISDelete] = @value , [DateDeleted] = GETDATE()  WHERE id_MC = @id_MC";

                    str = db.Script(query, paramss);

                    db.Script("UPDATE [tbl_Product]SET[ISDELETE] = 1 WHERE [id_MainCategory]=" + id);
                    db.Script("UPDATE[tbl_Product_SubCategory] SET[ISDelete] = 1,[DateDeleted] = GETDATE() WHERE [id_MC]=" + id);
                    db.Script("UPDATE R SET R.ISDelete=1,R.DateDeleted= GETDATE() FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC where P.id_MC=" + id);

                }
                else if (action == "off")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [dbo].[tbl_Product_MainCategory] SET [ISDESABLED] = @value , [DateDesabled] = GETDATE() WHERE id_MC= @id_MC";

                    str = db.Script(query, paramss);
                    db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 0 WHERE [id_MainCategory]=" + id);
                    db.Script("UPDATE[tbl_Product_SubCategory] SET[ISDESABLED] = 1,[DateDesabled] = GETDATE() WHERE [id_MC]=" + id);
                    db.Script("UPDATE R SET R.ISDESABLED=1,R.DateDesabled= GETDATE() FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC where P.id_MC=" + id);
                }
                else if (action == "on")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "0"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [dbo].[tbl_Product_MainCategory] SET [ISDESABLED] = @value , [DateDesabled] = GETDATE() WHERE id_MC= @id_MC";

                    str = db.Script(query, paramss);
                    db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 1 WHERE [id_MainCategory]=" + id);
                    db.Script("UPDATE[tbl_Product_SubCategory] SET[ISDESABLED] = 0 WHERE [id_MC]=" + id);
                    db.Script("UPDATE R SET R.DateDesabled=0 FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC where P.id_MC=" + id);
                }
                return RedirectToAction("table_Cat");

            }
            else
                return RedirectToAction("NotAccess");

        }

        ///------///////////////////////{   End maincat   }//////////////////////////////




        //////////////////////////{   START SubCat    }//////////////////////////////
        public SubCategory data_Sub;
        List<SubCategory> list_Sub = new List<SubCategory>();
        /////////////////////////////////////////////////////////// SubCat : get
        [HttpGet]
        public ActionResult SubCat()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");

        }
        /////////////////////////////////////////////////////////// New_Sub : get
        [HttpGet]
        public ActionResult New_Sub()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                model = new TypeASPX();
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                using (DataTable dt = db.Select("SELECT [id_MC],[MCName]FROM [tbl_Product_MainCategory] WHERE ISDESABLED=0 AND ISDelete=0"))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_cat = new MainCategory();


                        data_cat.id_MC = dt.Rows[i]["id_MC"].ToString();
                        data_cat.MCName = dt.Rows[i]["MCName"].ToString();
                        list_cat.Add(data_cat);


                    }
                    ViewBag.Sub = list_cat;
                };


                if (Session["edit_Sub"] != null)
                {
                    model = (TypeASPX)Session["edit_Sub"];
                    ViewBag.model = model;
                }
                else
                {
                    ViewBag.model = model;
                }

                return View();

            }
            else
                return RedirectToAction("NotAccess");

        }
        /////////////////////////////////////////////////////////// SubPage : post
        [HttpPost]
        public ActionResult SubPage(string action, string value, string id, string data_Sub)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string query_new, query_edit;
                string res = " ";


                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                if (action == "new")
                {

                    query_new = "INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete])VALUES (@data_Sub,@value,0,0)";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = value
                    };
                    paramss.Add(parameters);

                    parameters = new ExcParameters()
                    {
                        _KEY = "@data_Sub",
                        _VALUE = data_Sub
                    };
                    paramss.Add(parameters);

                    res = db.Script(query_new, paramss);

                }

                else if (action == "edit")
                {

                    query_edit = "UPDATE [tbl_Product_SubCategory]SET [SCName] = @value WHERE id_SC = @id ";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@id",
                        _VALUE = id
                    };

                    paramss.Add(parameters);

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = value
                    };

                    paramss.Add(parameters);


                    res = db.Script(query_edit, paramss);

                }

                return Content(res);
            }
            else
                return RedirectToAction("NotAccess");


        }
        //////////////////////////////////////////////////// list sub : get
        public ActionResult table_Sub()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string query_type;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                //query_type = "SELECT [id_MC],[id_PT],[MCName],[ISDESABLED],[ISDelete],(select PTname from [dbo].[tbl_Product_Type]where [id_PT]=[tbl_Product_MainCategory].[id_PT] ) as 'name_PT',( select count (id_SC) from [dbo].[tbl_Product_SubCategoryOptionKey] where id_SC in( select id_SC from [dbo].[tbl_Product_SubCategory] where id_MC =[dbo].[tbl_Product_MainCategory].[id_MC] ))  as 'count' FROM [dbo].[tbl_Product_MainCategory]";
                query_type = "SELECT [id_SC],[id_MC],[SCName],[ISDESABLED],[ISDelete],(select MCName from [tbl_Product_MainCategory] where [id_MC]=[tbl_Product_SubCategory].[id_MC] ) as 'nameMC',( select count (id_SC) from [tbl_Product_SubCategoryOptionKey] where id_SC =[tbl_Product_SubCategory].[id_SC]) as 'count' FROM [tbl_Product_SubCategory]";
                using (DataTable dt = db.Select(query_type))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_Sub = new SubCategory();

                        data_Sub.id_SC = dt.Rows[i]["id_SC"].ToString();
                        data_Sub.id_MC = dt.Rows[i]["nameMC"].ToString();
                        data_Sub.SCName = dt.Rows[i]["SCName"].ToString();
                        data_Sub.ISDelete = dt.Rows[i]["ISDelete"].ToString();
                        data_Sub.ISDESABLED = dt.Rows[i]["ISDESABLED"].ToString();
                        data_Sub.count = dt.Rows[i]["count"].ToString();
                        list_Sub.Add(data_Sub);
                    }
                    ViewBag.Subs = list_Sub;
                }

                return View();
            }
            else
                return RedirectToAction("NotAccess");
        }
        /////////////////////////////////////////////////////////// list sub : post
        [HttpPost]
        public ActionResult Sub_Switch(string action, string id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string str = " ", query;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                parameters = new ExcParameters()
                {
                    _KEY = "@id_SC",
                    _VALUE = id
                };

                paramss.Add(parameters);

                if (action == "edit")
                {
                    using (DataTable dt = db.Select($"SELECT [id_SC],[SCName] FROM [tbl_Product_SubCategory] where [id_SC]= '{id}'"))
                    {
                        model = new TypeASPX()
                        {
                            ChangeID = dt.Rows[0]["id_SC"].ToString(),
                            HasChange = true,
                            ChangeValue = dt.Rows[0]["SCName"].ToString()
                        };

                        Session["edit_Sub"] = model;
                        return RedirectToAction("New_Sub");

                    };
                }
                else if (action == "delete")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [tbl_Product_SubCategory] SET [ISDelete] = @value , [DateDeleted] = GETDATE()  WHERE id_SC= @id_SC";

                    str = db.Script(query, paramss);
                    db.Script("UPDATE [tbl_Product]SET[ISDELETE] = 1 WHERE [id_SubCategory]=" + id);
                    db.Script("UPDATE[tbl_Product_SubCategoryOptionKey] SET [ISDelete] =1,[DateDeleted] = GETDATE() WHERE id_SC=" + id);

                }
                else if (action == "off")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [tbl_Product_SubCategory] SET [ISDESABLED] = @value , [DateDesabled] = GETDATE() WHERE id_SC= @id_SC";

                    str = db.Script(query, paramss);
                    db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 1 WHERE [id_SubCategory]=" + id);
                    db.Script("UPDATE[tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] =1,[DateDesabled] = GETDATE() WHERE id_SC=" + id);
                }
                else if (action == "on")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "0"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [tbl_Product_SubCategory] SET [ISDESABLED] = @value , [DateDesabled] = GETDATE() WHERE id_SC= @id_SC";

                    str = db.Script(query, paramss);
                    db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 1 WHERE [id_SubCategory]=" + id);
                    db.Script("UPDATE[tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] =0 WHERE id_SC=" + id);
                }
                return RedirectToAction("table_Sub");
            }
            else
                return RedirectToAction("NotAccess");


        }
        ///------///////////////////////{   End Subcat   }//////////////////////////////



        //////////////////////////{   START SubCatKey    }//////////////////////////////
        public SubCategoryOptionKey data_SCK;
        List<SubCategoryOptionKey> list_SCK = new List<SubCategoryOptionKey>();
        /////////////////////////////////////////////////////////// SubCatKey : get
        [HttpGet]
        public ActionResult SubCatKey()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");

        }
        /////////////////////////////////////////////////////////// New_SCK : get
        [HttpGet]
        public ActionResult New_SCK()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                model = new TypeASPX();
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                using (DataTable dt = db.Select("SELECT [id_SC],[SCName]FROM[tbl_Product_SubCategory] WHERE ISDESABLED=0 AND ISDelete=0"))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_Sub = new SubCategory();

                        data_Sub.id_SC = dt.Rows[i]["id_SC"].ToString();
                        data_Sub.SCName = dt.Rows[i]["SCName"].ToString();
                        list_Sub.Add(data_Sub);

                    }
                    ViewBag.SCK = list_Sub;
                };


                if (Session["edit_SCK"] != null)
                {
                    model = (TypeASPX)Session["edit_SCK"];
                    ViewBag.model = model;
                }
                else
                {
                    ViewBag.model = model;
                }

                return View();

            }
            else
                return RedirectToAction("NotAccess");


        }
        /////////////////////////////////////////////////////////// SCKPage : post
        [HttpPost]
        public ActionResult SCKPage(string action, string value, string id, string data_SCK)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                string query_new, query_edit;
                string res = " ";


                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                if (action == "new")
                {

                    query_new = "INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete])VALUES(@data_SCK,@value,0,0)";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = value
                    };
                    paramss.Add(parameters);

                    parameters = new ExcParameters()
                    {
                        _KEY = "@data_SCK",
                        _VALUE = data_SCK
                    };
                    paramss.Add(parameters);

                    res = db.Script(query_new, paramss);

                }

                else if (action == "edit")
                {

                    query_edit = "UPDATE [tbl_Product_SubCategoryOptionKey] SET [SCOKName] = @value WHERE id_SCOK =@id";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@id",
                        _VALUE = id
                    };

                    paramss.Add(parameters);

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = value
                    };

                    paramss.Add(parameters);


                    res = db.Script(query_edit, paramss);

                }

                return Content(res);


            }
            else
                return RedirectToAction("NotAccess");

        }
        //////////////////////////////////////////////////// list SCK : get
        public ActionResult table_SCK()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                string query_type;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                query_type = "SELECT [id_SCOK],[id_SC],[SCOKName],[ISDESABLED],[ISDelete],(SELECT [SCName]FROM [tbl_Product_SubCategory]where [id_SC]=[tbl_Product_SubCategoryOptionKey].[id_SC])as 'name_SC' FROM [tbl_Product_SubCategoryOptionKey]";
                // query_type = "SELECT [id_SC],[id_MC],[SCName],[ISDESABLED],[ISDelete],(select MCName from [dbo].[tbl_Product_MainCategory] where [id_MC]=[tbl_Product_SubCategory].[id_MC] ) as 'nameMC',( select count (id_SC) from [dbo].[tbl_Product_SubCategoryOptionKey] where id_SC =[dbo].[tbl_Product_SubCategory].[id_SC]) as 'count' FROM [dbo].[tbl_Product_SubCategory]";
                using (DataTable dt = db.Select(query_type))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_SCK = new SubCategoryOptionKey();

                        data_SCK.id_SCOK = dt.Rows[i]["id_SCOK"].ToString();
                        data_SCK.id_SC = dt.Rows[i]["name_SC"].ToString();
                        data_SCK.SCOKName = dt.Rows[i]["SCOKName"].ToString();
                        data_SCK.ISDelete = dt.Rows[i]["ISDelete"].ToString();
                        data_SCK.ISDESABLED = dt.Rows[i]["ISDESABLED"].ToString();
                        //data_SCK.count = dt.Rows[i]["count"].ToString();
                        list_SCK.Add(data_SCK);
                    }
                    ViewBag.SCKs = list_SCK;
                }

                return View();

            }
            else
                return RedirectToAction("NotAccess");
        }
        /////////////////////////////////////////////////////////// list SCK : post
        [HttpPost]
        public ActionResult SCK_Switch(string action, string id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                string str = " ", query;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                parameters = new ExcParameters()
                {
                    _KEY = "@id_SCOK",
                    _VALUE = id
                };

                paramss.Add(parameters);

                if (action == "edit")
                {
                    using (DataTable dt = db.Select($"SELECT [id_SCOK],[SCOKName] FROM [tbl_Product_SubCategoryOptionKey] where [id_SCOK]= '{id}'"))
                    {
                        model = new TypeASPX()
                        {
                            ChangeID = dt.Rows[0]["id_SCOK"].ToString(),
                            HasChange = true,
                            ChangeValue = dt.Rows[0]["SCOKName"].ToString()
                        };

                        Session["edit_SCK"] = model;
                        return RedirectToAction("New_SCK");

                    };
                }
                else if (action == "delete")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [tbl_Product_SubCategoryOptionKey] SET [ISDelete] = @value , [DateDeleted] = GETDATE()  WHERE id_SCOK= @id_SCOK";

                    str = db.Script(query, paramss);

                }
                else if (action == "off")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] = @value , [DateDesabled] = GETDATE() WHERE id_SCOK= @id_SCOK";

                    str = db.Script(query, paramss);
                }
                else if (action == "on")
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "0"
                    };
                    paramss.Add(parameters);

                    query = "UPDATE [tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] = @value , [DateDesabled] = GETDATE() WHERE id_SCOK= @id_SCOK";

                    str = db.Script(query, paramss);
                }
                return RedirectToAction("table_SCK");
            }
            else
                return RedirectToAction("NotAccess");
        }
        ///------///////////////////////{   End SubCatKey   }//////////////////////////////
        ///

        /////////////////////////////{   START Opinion   }//////////////////////////////
        public opinion data_op;
        List<opinion> list_op = new List<opinion>();
        [HttpGet]
        public ActionResult Opinion()
        {

            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");

        }

        public ActionResult Opinion_show()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                using (DataTable dt = db.Select("SELECT [id_MProduct],[id_Customer],[id_AccByAdmin],[CreateDate],[DateAccepted],[Is_Accepted],[OpinionDescription],[Rate],[ISDELETE],[id_Opinion] FROM [dbo].[tbl_Product_Opinion]"))
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_op = new opinion();
                        string str = dt.Rows[i]["ISDELETE"].ToString();
                        if (dt.Rows[i]["ISDELETE"].ToString() == "0")
                        {
                            data_op.id_Opinion = dt.Rows[i]["id_Opinion"].ToString();
                            data_op.id_MProduct = dt.Rows[i]["id_MProduct"].ToString();
                            data_op.id_Customer = dt.Rows[i]["id_Customer"].ToString();
                            data_op.CreateDate = dt.Rows[i]["CreateDate"].ToString();
                            data_op.Is_Accepted = dt.Rows[i]["Is_Accepted"].ToString();
                            data_op.OpinionDescription = dt.Rows[i]["OpinionDescription"].ToString();
                            data_op.Rate = dt.Rows[i]["Rate"].ToString();
                            list_op.Add(data_op);
                        }
                    }
                    ViewBag.opin = list_op;
                };


                return View();

            }
            else
                return RedirectToAction("NotAccess");
        }

        public ActionResult get_Opinion(string id, string value)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string res = " ", query_edit;


                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                parameters = new ExcParameters()
                {
                    _KEY = "@id",
                    _VALUE = id
                };

                paramss.Add(parameters);

                if (value == "delete")
                {
                    query_edit = "UPDATE [dbo].[tbl_Product_Opinion] SET [ISDELETE] = @value WHERE [id_Opinion] = @id";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };

                    paramss.Add(parameters);


                    res = db.Script(query_edit, paramss);
                }
                else if (value == "on")
                {
                    query_edit = "UPDATE [dbo].[tbl_Product_Opinion] SET [Is_Accepted] = @value ,[DateAccepted] = GETDATE() WHERE  [id_Opinion] = @id";

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = "1"
                    };

                    paramss.Add(parameters);


                    res = db.Script(query_edit, paramss);
                }
                return RedirectToAction("Opinion");
            }
            else
                return RedirectToAction("NotAccess");
        }
        ///------///////////////////////{   End Opinion   }//////////////////////////////
        ///


        /////////////////////////////{   START Product   }//////////////////////////////

        [HttpGet]
        public ActionResult Product()
        {

            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");


        }


        public ActionResult get_Product(string id, string value)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");

        }

        public ActionResult NEWSHOPS_Customers()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");

        }


        ///////////////////////////////////////////////////
        /////////////////////////////{   START About   }//////////////////////////////
        public OpinionAbout data_opAb;
        List<OpinionAbout> list_opAb = new List<OpinionAbout>();

        public companies data_comp;
        List<companies> list_comp = new List<companies>();
        [HttpGet]
        public ActionResult About()
        {

            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess");

        }

        [HttpGet]
        public ActionResult tab_About()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                using (DataTable dt = db.Select("SELECT [Id_OpinionAbout],[Name_OpinionAbout],[OpinionAbout],[Is_delete]FROM [dbo].[OpinionAbout]"))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_opAb = new OpinionAbout();

                        if (dt.Rows[i]["Is_delete"].ToString() == "0")
                        {
                            data_opAb.Id_OpinionAbout = dt.Rows[i]["Id_OpinionAbout"].ToString();
                            data_opAb.Name_OpinionAbout = dt.Rows[i]["Name_OpinionAbout"].ToString();
                            data_opAb.Opinionabout = dt.Rows[i]["OpinionAbout"].ToString();
                            list_opAb.Add(data_opAb);
                        }
                    }
                    ViewBag.opin_ab = list_opAb;
                };


                using (DataTable dt = db.Select("SELECT [id_companies],[Image],[Name_companies],[Url],[Is_delete]FROM [dbo].[companies]"))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data_comp = new companies();

                        if (dt.Rows[i]["Is_delete"].ToString() == "0")
                        {
                            data_comp.id_companies = dt.Rows[i]["id_companies"].ToString();
                            data_comp.Image = dt.Rows[i]["Image"].ToString();
                            data_comp.Name_companies = dt.Rows[i]["Name_companies"].ToString();
                            data_comp.Url = dt.Rows[i]["Url"].ToString();
                            list_comp.Add(data_comp);
                        }
                    }
                    ViewBag.comp = list_comp;
                };


                return View();
            }
            else
                return RedirectToAction("NotAccess");
        }
        [HttpPost]
        public ActionResult get_About(string image, string title_one, string one, string title_two, string two)
        {

            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                string res = " ", query;

                query = "INSERT INTO [dbo].[About]([Image],[Title_one],[Text_one],[Title_two],[Text_two])VALUES(@Image,@Title_one,@Text_one,@Title_two,@Text_two)";

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                parameters = new ExcParameters()
                {
                    _KEY = "@Image",
                    _VALUE = image
                };

                paramss.Add(parameters);

                parameters = new ExcParameters()
                {
                    _KEY = "@Title_one",
                    _VALUE = title_one
                };

                paramss.Add(parameters);

                parameters = new ExcParameters()
                {
                    _KEY = "@Text_one",
                    _VALUE = one
                };

                paramss.Add(parameters);

                parameters = new ExcParameters()
                {
                    _KEY = "@Title_two",
                    _VALUE = title_two
                };

                paramss.Add(parameters);

                parameters = new ExcParameters()
                {
                    _KEY = "@Text_two",
                    _VALUE = two
                };

                paramss.Add(parameters);


                res = db.Script(query, paramss);

                return Content(res);
            }
            else
                return RedirectToAction("NotAccess");
        }
        [HttpPost]
        public ActionResult up_loder()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                string str1 = " ";
                string Action = Request["action"];
                string data = Request["data"];
                if (Action != null || !string.IsNullOrEmpty(Action))
                {
                    if (Action == "New")
                    {
                        StringBuilder IMGS = new StringBuilder("");
                        for (int i = 0; i < Request.Files.Count; i++)
                        {

                            HttpPostedFileBase file = Request.Files[i];
                            if (file != null && file.ContentLength > 0)
                            {

                                string fname = Path.GetFileName(file.FileName);
                                string EX = Path.GetExtension(file.FileName);
                                string FileNAME = Guid.NewGuid().ToString() + "-" + fname;
                                string address = Server.MapPath("~/images/" + FileNAME);
                                string URLIMG = Statics.AppendServername("images/" + FileNAME);
                                if (Directory.Exists(Server.MapPath("~/images")))
                                {
                                    file.SaveAs(address);
                                }
                                else
                                {
                                    System.IO.Directory.CreateDirectory(Server.MapPath("~/images"));
                                    file.SaveAs(address);
                                }
                                StringBuilder str = new StringBuilder("");
                                string iiid = $"{DateTime.Now.Millisecond}{DateTime.Now.Minute}{DateTime.Now.Hour}{DateTime.Now.Second}";
                                str.Append("<div class=\"col-xl-3 col-lg-3 col-md-3\"><div class=\"kt-portlet\"><div class=\"kt-portlet__body\"><div class=\"kt-widget__files\"><div class=\"kt-widget__media\"><img class=\"kt-widget__img\" style=\"height:200px;width:200px;\" src=\"");
                                str.Append(URLIMG);
                                str.Append("\" alt=\"image\"></div><input style=\"width:50px;height:50px;background-color:transparent; border:none;\" type=\"text\" value=\"" + URLIMG + "\" id=\"");
                                str.Append($"img{iiid}");
                                str.Append($"\" readonly><button onclick=\"return copytoclipboard('{data}','");
                                str.Append($"{URLIMG}");
                                str.Append("')\" class=\"w-100 btn btn-success\">کپی کردن آدرس تصویر</button></div></div></div></div>");
                                IMGS.Append(str.ToString());


                            }

                        }
                        str1 = IMGS.ToString();
                        // Response.Write(IMGS.ToString());
                    }
                }
                return Content(str1);
            }
            else
                return RedirectToAction("NotAccess");
        }
        [HttpPost]
        public ActionResult data_switch(string _A, string _B, string _C, string data, string value, string id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                string str2 = " ", query;

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();


                if (data == "op_about")
                {
                    if (value == "new")
                    {
                        query = "INSERT INTO [dbo].[OpinionAbout]([Name_OpinionAbout],[OpinionAbout],[Is_delete]) VALUES (@Name_OpinionAbout,@OpinionAbout,0)";
                        parameters = new ExcParameters()
                        {
                            _KEY = "@Name_OpinionAbout",
                            _VALUE = _A
                        };

                        paramss.Add(parameters);
                        parameters = new ExcParameters()
                        {
                            _KEY = "@OpinionAbout",
                            _VALUE = _B
                        };

                        paramss.Add(parameters);

                        str2 = db.Script(query, paramss);

                    }
                    else if (value == "delete")
                    {

                        query = "UPDATE [dbo].[OpinionAbout]SET [Is_delete] = 1 WHERE [Id_OpinionAbout] = @id";


                        parameters = new ExcParameters()
                        {
                            _KEY = "@id",
                            _VALUE = id
                        };

                        paramss.Add(parameters);

                        str2 = db.Script(query, paramss);

                    }
                }
                else if (data == "comp")
                {
                    if (value == "new")
                    {
                        query = "INSERT INTO [dbo].[companies]([Image],[Name_companies],[Url],[Is_delete])VALUES(@Image,@Name_companies,@Url,0)";
                        parameters = new ExcParameters()
                        {
                            _KEY = "@Name_companies",
                            _VALUE = _A
                        };

                        paramss.Add(parameters);
                        parameters = new ExcParameters()
                        {
                            _KEY = "@Url",
                            _VALUE = _B
                        };

                        paramss.Add(parameters);
                        parameters = new ExcParameters()
                        {
                            _KEY = "@Image",
                            _VALUE = _C
                        };

                        paramss.Add(parameters);
                        str2 = db.Script(query, paramss);

                    }
                    else if (value == "delete")
                    {

                        query = "UPDATE [dbo].[companies] SET [Is_delete] = 1 WHERE [id_companies] = @id";


                        parameters = new ExcParameters()
                        {
                            _KEY = "@id",
                            _VALUE = id
                        };

                        paramss.Add(parameters);

                        str2 = db.Script(query, paramss);

                    }
                }
                return Content(str2);

            }
            else
                return RedirectToAction("NotAccess");

        }

    }
}