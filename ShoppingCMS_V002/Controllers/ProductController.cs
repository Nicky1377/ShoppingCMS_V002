using MD.PersianDateTime;
using Newtonsoft.Json;
using ShoppingCMS_V002.DBConnect;
using ShoppingCMS_V002.Models;
using ShoppingCMS_V002.ModelViews;
using ShoppingCMS_V002.OtherClasses;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Add_Product(string Act="insert",int id=0)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                var model = new Id_ValueModel()
                {
                    Id=id,
                    Value=Act
                };

                return View(model);
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

        public ActionResult Add_Page4(int SubId)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();

                AddProductModelV_4 model = new AddProductModelV_4()
                {
                    MainTags=MF.MainTagsModel_Filler(),
                    OffTypes=MF.OffTypeModel_Filler(),
                    PriceShow=MF.PriceShowModel_Filler(),
                    PriceType=MF.MoneyTypeModel_Filler(),
                    QuantityTypes=MF.PQTModel_Filler(),
                    Tags=MF.TagsModel_Filler(SubId)
                };

                return View(model);
                
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }


        public ActionResult Add_Page5(int id, int SubId)

        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();
                List<AddProductModelV_5> result = new List<AddProductModelV_5>();

                var pricingItm = MF.pricingModelfiller(id);
                var MainTags = MF.MainTagsModel_Filler();
                var OffTypes = MF.OffTypeModel_Filler();
                var PriceShow = MF.PriceShowModel_Filler();
                var PriceType = MF.MoneyTypeModel_Filler();
                var QuantityTypes = MF.PQTModel_Filler();
                var Tags = MF.TagsModel_Filler(SubId);
                foreach (var item in pricingItm)
                {
                    var model = new AddProductModelV_5()
                    {
                        MainTags = MainTags,
                        OffTypes = OffTypes,
                        PriceShow= PriceShow,
                        PriceType=PriceType,
                        QuantityTypes=QuantityTypes,
                        Tags=Tags,
                        pricingModel=item
                    };
                    result.Add(model);
                }


                return View(result);
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        //============================================================BEGIN::UploadController
        public ActionResult UploadPage()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult UploaderIFRAME()
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
        public ActionResult UploadImageResult(string Whattodo)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["uploaderInput"];
                    Whattodo = "";

                }
                return Content("salam");
            }
            else
                return Content("");
        }
        [HttpPost]
        public ActionResult GetImageInformation(string IDReqPic)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                return Content("salam2");
            }
            else
                return Content("");
        }
        //============================================================END::UploadController

        [HttpPost]
        public ActionResult Save_Step1(string Act_ToDo, int id_CreatedByAdmin, string Title, string Description, string SEO_keyword, string SEO_description, string SearchGravity ,int IsAd,string pics, int id = 0)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();
                string itmId = MF.Product_Action_Step1(Act_ToDo, id_CreatedByAdmin, Title, Description, SEO_keyword, SEO_description, SearchGravity, IsAd);

                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                foreach (var item in pics.Split(','))
                {
                    db.Script("INSERT INTO [tbl_Product_PicConnector] VALUES (" + itmId + "," + item + ")");

                }

                return Content(itmId);
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
        public ActionResult Save_Step4(string json, string ActTodo, int id_MProduct, int Quantity, int QuantityModule, int PricePerquantity, int PriceOff, int offTypeValue, int OffType, int id_MainStarTag, int PriceModule, int PriceShow,string tgs)
        {
            
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                int PriceXquantity = Quantity * PricePerquantity;
                ModelFiller MF = new ModelFiller();
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                if (ActTodo == "insert")
                {

                    JaygashtClass jaygashtClass = new JaygashtClass();
                    var jaygashts = jaygashtClass.Result(json);
                    string itemid = "0";
                    foreach (var item in jaygashts)
                    {
                        itemid = MF.MainProduct_Actions(ActTodo, id_MProduct, Quantity, QuantityModule, PriceXquantity, PricePerquantity, PriceOff, offTypeValue, OffType, id_MainStarTag, PriceModule, PriceShow);

                       

                        foreach (var itm in item)
                        {
                            db.Script("INSERT INTO[tbl_Product_connectorToMPC_SCOV] VALUES(" + itemid + "," + itm.ValId + ")");
                        }





                        //string[] str = tgs.Split(',');

                        //for (int i = 0; i < str.Length; i++)
                        //{
                        //    
                        //        db.Script("INSERT INTO [tbl_Product_tagConnector] VALUES(" + itemid + "," + str[i] + ")");
                        //    
                        //}
                    }
                }else if(ActTodo == "update")
                {
                    MF.MainProduct_Actions(ActTodo, id_MProduct, Quantity, QuantityModule, PriceXquantity, PricePerquantity, PriceOff, offTypeValue, OffType, id_MainStarTag, PriceModule, PriceShow);

                    //string[] str = tgs.Split(',');

                    //for (int i = 0; i < str.Length; i++)
                    //{
                    //    
                    //        db.Script("DELETE FROM [tbl_Product_tagConnector] WHERE id_MPC=" + id_MProduct);
                    //        db.Script("INSERT INTO [tbl_Product_tagConnector] VALUES(" + id_MProduct + "," + str[i] + ")");
                    //    
                    //}
                }

                return Content("Success");
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }
        public ActionResult Save_Step5(string ActTodo,int id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                if (ActTodo=="delete")
                {
                    db.Script("UPDATE [tlb_Product_MainProductConnector] SET [ISDELETE] = 1 WHERE id_MPC="+id);

                }
                else if(ActTodo == "restore")
                {
                    db.Script("UPDATE [tlb_Product_MainProductConnector] SET [ISDELETE] = 0 WHERE id_MPC="+id);
                }


                return Content("success");
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

        public ActionResult AddTag()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {

                ModelFiller MF = new ModelFiller();

                AddProductModelV_2 model = new AddProductModelV_2()
                {
                    Types = MF.DropFiller("Type")
                };

                return View(model);
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }


        public ActionResult Add_MainTag()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                return View();
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult MainTag_Add_Update(string ActTodo,string Name,string Description,int id=0)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                if (ActTodo == "insert")
                {
                    db.Script("INSERT INTO [tbl_Product_MainStarTags]VALUES(N'" + Description + "',N'" + Name + "')");
                }
                else if (ActTodo == "update")
                {
                    db.Script("UPDATE [tbl_Product_MainStarTags] SET [MST_Description] =N'" + Description + "' ,[MST_Name] =N'" + Name + "' WHERE id_MainStarTag=" + id);
                }
                else if (ActTodo == "delete")
                {
                 
                    db.Script("DELETE FROM [tbl_Product_MainStarTags]WHERE id_MainStarTag=" + id);
                }

                return Content("Success");
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult Tag_Add_Update(string ActTodo,int SubId,string Name,int id =0)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                if (ActTodo == "insert")
                {
                    db.Script("INSERT INTO [tbl_Product_TagEnums]VALUES (N'"+Name+"',"+SubId+")");
                }
                else if (ActTodo == "update")
                {
                    db.Script("UPDATE [tbl_Product_TagEnums] SET [TE_name] = N'' WHERE id_TE=" + id);
                }
                else if (ActTodo == "delete")
                {
                    db.Script("DELETE FROM [tbl_Product_tagConnector] WHERE id_TE=" + id);
                    db.Script("DELETE FROM [tbl_Product_TagEnums] WHERE id_TE=" + id);
                }

                return Content("Success");
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult MainTag_table()
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();

                return View(MF.MainTags());
            }
            else
                return RedirectToAction("NotAccess", "MS");
        }

        public ActionResult TagsTable(int id)
        {
            CheckAccess check = new CheckAccess();
            if (check.HasAccess)
            {
                ModelFiller MF = new ModelFiller();

                return View(MF.Tags(id));
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