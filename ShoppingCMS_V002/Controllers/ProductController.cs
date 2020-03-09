using MD.PersianDateTime;
using Newtonsoft.Json;
using ShoppingCMS_V002.DBConnect;
using ShoppingCMS_V002.Models;
using ShoppingCMS_V002.ModelViews;
using ShoppingCMS_V002.OtherClasses;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShoppingCMS_V002.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Product_List()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess","MS");
        }

        public ActionResult Product_table(bool SearchBox, string text = "")
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                ModelFiller MF = new ModelFiller();
                string query = "";
                if (SearchBox)
                {
                    query = MF.QueryMaker(true, text);
                }
                else
                {
                    query = MF.QueryMaker(false);
                }


                var Model = new ProductListModelView()
                {
                    ProductModels = MF.productModels_List(query)
                };


                //var list=new List<ProductModel>();
                //list.Add(itemList);
                //list.Add(itemList);
                //list.Add(itemList);
                //var Model = new ProductListModelView()
                //{
                //    ProductModels = list
                //};


                return View(Model);

            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult Add_Product()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult Add_Page1()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        public ActionResult Add_Page2(int Id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();

                AddProductModelV_2 model = new AddProductModelV_2()
                {
                    Id=Id,
                    Types = MF.DropFiller("Type")
                };

                return View(model);
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        [HttpPost]
        public ActionResult DropListFiller(string drop, int id = 0)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();
                var model = MF.DropFiller(drop, id);
                return Json(model);
                //return Content("hello");
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        public ActionResult Add_Page3(string Ids,int id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                var ids = Ids.Split(',');

                var Subval = new List<AddPro_SubValues>();
                for (int i = 0; i < ids.Length; i++)
                {
                    var model = new AddPro_SubValues()
                    {
                        Id = Convert.ToInt32(ids[i]),
                        Title = db.Select("SELECT[SCOKName]FROM [tbl_Product_SubCategoryOptionKey]where [id_SCOK]=" + ids[i]).Rows[0][0].ToString(),
                        Item_List = MF.DropFiller("SubCat_Value", Convert.ToInt32(ids[i]))
                    };

                    Subval.Add(model);
                }

                var result = new AddProductModelV_3()
                {
                    Id = id,
                    Item_List = Subval
                };


                return View(result);
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult Options_Table(int id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();
                var res = MF.OptionsFiller(id);


                return View(res);
            }
            else
                return RedirectToAction("NotAccess", "MS");

           
        }

        public ActionResult Op_delete_edit(string action, int id,string Key="",string value="")
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                if (action == "edit")
                {
                    if (Key != "" && value != "")
                    {
                        db.Script("UPDATE[tbl_Product_tblOptions] SET [KeyName] = N'" + Key + "',[Value] = N'" + value + "' WHERE id_Op=" + id);
                    }

                }
                else if (action == "delete")
                {
                    db.Script("DELETE FROM[tbl_Product_tblOptions] WHERE id_Op=" + id);
                }
                else if (action == "new")
                {
                    if (Key != "" && value != "")
                    {
                        db.Script("INSERT INTO[tbl_Product_tblOptions]VALUES(" + id + ",N'" + Key + "',N'" + value + "')");
                    }
                }


                return Content("done");

            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult Add_Page4()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        public ActionResult Add_Page5()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        [HttpPost]
        public ActionResult Save_Step1(string Act_ToDo, int id_CreatedByAdmin, string Title, string Description, string SEO_keyword, string SEO_description, string SearchGravity ,int IsAd)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();


                return Content(MF.Product_Action_Step1(Act_ToDo, id_CreatedByAdmin, Title, Description, SEO_keyword, SEO_description, SearchGravity, IsAd));
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        [HttpPost]
        public ActionResult Save_Step2(string Type,string Main,string Sub,string SubKey,int id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();
                return Content(MF.Product_Action_Step2(Type, Main, Sub, SubKey, id));
            }
            else
                return RedirectToAction("NotAccess", "MS");
            
        }
        public ActionResult Save_Step3(string Json)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                var JsonList = JsonConvert.DeserializeObject<List<OptionsJsonModel>>(Json);

                return Content(JsonList.Count.ToString());
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        public ActionResult Save_Step4(string json, string action, int id_MProduct, int Quantity, int QuantityModule, int PriceXquantity, int PricePerquantity, int PriceOff, int offTypeValue, int OffType, int id_MainStarTag, int PriceModule, int PriceShow)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();
                JaygashtClass jaygashtClass = new JaygashtClass();
                var jaygashts = jaygashtClass.Result(json);
                string itemid = "0";
                foreach (var item in jaygashts)
                {
                    itemid = MF.MainProduct_Actions(action, id_MProduct, Quantity, QuantityModule, PriceXquantity, PricePerquantity, PriceOff, offTypeValue, OffType, id_MainStarTag, PriceModule, PriceShow);

                    PDBC db = new PDBC("PandaMarketCMS", true);
                    db.Connect();

                    foreach (var itm in item)
                    {
                        db.Script("INSERT INTO[tbl_Product_connectorToMPC_SCOV] VALUES(" + itemid + "," + itm.ValId + ")");
                    }
                }
                return Content("Success");
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        public ActionResult Save_Step5()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult MainDropDown(string drop,int id=0)
        {

            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        
        [HttpPost]
        public ActionResult test(int id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                List<ExcParameters> paramss = new List<ExcParameters>();
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();
                var parameters = new ExcParameters()
                {
                    _KEY = "@value",
                    _VALUE = "pink"
                };
                paramss.Add(parameters);
                string s = db.Script("INSERT INTO [dbo].[tbl_Product_SubCategoryOptionValue]([id_SCOK],[SCOVValueName]) Output Inserted.id_SCOV VALUES(1, @value )",paramss);
                return Content(s);
            }
            else
                return RedirectToAction("NotAccess", "MS");
            
        }


    }
}