using MD.PersianDateTime;
using ShoppingCMS_V002.DBConnect;
using ShoppingCMS_V002.Models;
using ShoppingCMS_V002.ModelViews;
using ShoppingCMS_V002.OtherClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCMS_V002.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult Product_List()
        {
            return View();
        }

        public ActionResult Product_table(bool SearchBox, string text = "")
        {
            //var itemList = new ProductModel()
            //{
            //    deleted = false,
            //    disabled = true,
            //    Category = "محصولات دیجیتال-موبایل-سامسونگ گلکسی s8",
            //    MainPrice = "12000000",
            //    Description = "گوشی خوبیه",
            //    AddBy = "niky",
            //    PicPath = "https://localhost:44395/assets/download.jpg",
            //    Date = "1398/12/4",
            //    Title = "galaxy s8",
            //    Id = 1,
            //    Num = 1
            //};

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

        public ActionResult Add_Product()
        {
            return View();
        }

        public ActionResult Add_Page1()
        {
            return View();
        }
        public ActionResult Add_Page2()
        {
            ModelFiller MF = new ModelFiller();

            AddProductModelV_2 model = new AddProductModelV_2()
            {
                Types = MF.DropFiller("Type")
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult DropListFiller(string drop, int id = 0)
        {
            ModelFiller MF = new ModelFiller();
            var model = MF.DropFiller(drop, id);
            return Json(model);
            //return Content("hello");
        }
        public ActionResult Add_Page3(string Ids="0")
        {
            ModelFiller MF = new ModelFiller();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            var ids = Ids.Split(',');
            
            var result = new List<AddProductModelV_3>();
            for (int i = 0; i < ids.Length; i++)
            {
                var model = new AddProductModelV_3()
                {
                    Id = Convert.ToInt32(ids[i]),
                    Title = db.Select("SELECT[SCOKName]FROM [tbl_Product_SubCategoryOptionKey]where [id_SCOK]=" + ids[i]).Rows[0][0].ToString(),
                    Item_List = MF.DropFiller("SubCat_Value", Convert.ToInt32(ids[i]))
                };

                result.Add(model);
            }

            return View(result);
        }
        public ActionResult Add_Page4()
        {
            return View();
        }
        public ActionResult Add_Page5()
        {
            return View();
        }

        public ActionResult Save_Step1(AddProduct_P1 addProduct_P1)
        {

            return View();
        }
        [HttpPost]
        public ActionResult Save_Step2(string Type,string Main,string Sub,string SubKey,int id)
        {
            return Content(Type);
        }
        public ActionResult Save_Step3()
        {
            return View();
        }
        public ActionResult Save_Step4()
        {
            return View();
        }
        public ActionResult Save_Step5()
        {
            return View();
        }

        public ActionResult MainDropDown(string drop,int id=0)
        {
            

            return View();
        }
        public ActionResult test(string Ids = "0")
        {
            ModelFiller MF = new ModelFiller();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            var ids = Ids.Split(',');

            var result = new List<AddProductModelV_3>();
            for (int i = 0; i < ids.Length; i++)
            {
                var model = new AddProductModelV_3()
                {
                    Id = Convert.ToInt32(ids[i]),
                    Title = db.Select("SELECT[SCOKName]FROM [tbl_Product_SubCategoryOptionKey]where [id_SCOK]=" + ids[i]).Rows[0][0].ToString(),
                    Item_List = MF.DropFiller("SubCat_Value", Convert.ToInt32(ids[i]))
                };

                result.Add(model);
            }

            return Content(ids[0]);
        }


    }
}