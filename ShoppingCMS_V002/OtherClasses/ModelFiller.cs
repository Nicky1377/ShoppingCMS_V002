using MD.PersianDateTime;
using ShoppingCMS_V002.DBConnect;
using ShoppingCMS_V002.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Web;

namespace ShoppingCMS_V002.OtherClasses
{
    public class ModelFiller
    {


        //public static string resizeImage(Image image, int new_height, int new_width,string imageAddress,)
        //{
        //    Bitmap new_image = new Bitmap(new_width, new_height);
        //    Graphics g = Graphics.FromImage((Image)new_image);
        //    g.InterpolationMode = InterpolationMode.High;
        //    g.DrawImage(image, 0, 0, new_width, new_height);
        //    //return new_image;
        //    return "";
        //}




        public static string AppendServername(string url)
        {
            return "https://" + HttpContext.Current.Request.Url.Authority + "/" + url;
        }

        public List<ProductModel> productModels_List(string Query)
        {
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();

            DataTable dt = db.Select(Query);
            
            List<ProductModel> list = new List<ProductModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime date = Convert.ToDateTime(dt.Rows[i]["DateCreated"]);
                PersianDateTime persianDateTime = new PersianDateTime(date);
                var model = new ProductModel()
                {
                    Num = i + 1,
                    Id = Convert.ToInt32(dt.Rows[i]["id_MProduct"]),
                    Title = dt.Rows[i]["Title"].ToString(),
                    Description = dt.Rows[i]["Description"].ToString(),
                    AddBy = dt.Rows[i]["AddBy"].ToString(),
                    MainPrice = dt.Rows[i]["price"].ToString(),
                    Category = dt.Rows[i]["SubCat"].ToString() + "_" + dt.Rows[i]["MainCat"].ToString() + "_" + dt.Rows[i]["type"].ToString(),
                    Date = persianDateTime.ToString(),
                    PicPath = AppendServername(dt.Rows[i]["pic"].ToString())
                };
                if (dt.Rows[i]["IS_AVAILABEL"].ToString() == "1")
                {
                    model.disabled = false;
                }
                else
                {
                    model.disabled = true;
                }

                if (dt.Rows[i]["ISDELETE"].ToString() == "1")
                {
                    model.deleted = true;
                }
                else
                {
                    model.deleted = false;
                }
                list.Add(model);
            }

            return list;
        }


        public string QueryMaker(bool SearchBox, string text = "")
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append(
                " SELECT[id_MProduct],[IS_AVAILABEL],[Description],[DateCreated],[Title],[ISDELETE],(SELECT top 1 [ThumbnailPicAddress]FROM[tbl_Product_Pic]where[tbl_Product_Pic].[id_MProduct]=[tbl_Product].[id_MProduct]) as [pic],(SELECT[PricePerquantity] FROM[tlb_Product_MainProductConnector]WHERE id_MPC=idMPC_WhichTomainPrice) AS price,(SELECT[AdminName]FROM[AdminTbl]where [AdminId]=[id_CreatedByAdmin])as AddBy,(SELECT [PTname]FROM [tbl_Product_Type]where[id_PT]=[id_Type])as [type],(SELECT[SCName]FROM [tbl_Product_SubCategory]where[id_SC]=[id_SubCategory])as SubCat,(SELECT[MCName]FROM [tbl_Product_MainCategory]where[id_MC]=[id_MainCategory])as MainCat FROM [tbl_Product]");

            if (SearchBox)
            {
                queryBuilder.Append("Where Title LIKE N'%");
                queryBuilder.Append(text);
                queryBuilder.Append("%' OR Description LIKE N'%");
                queryBuilder.Append(text);
                queryBuilder.Append("%'");
            }

            queryBuilder.Append(" ORDER BY(DateCreated)DESC");
            return queryBuilder.ToString();
        }



        public List<Id_ValueModel> DropFiller(string drop , int id=0)
        {
            string query = "";
            if (drop == "Type")
            {
                query = "SELECT [id_PT] as id ,[PTname] as [name] FROM [tbl_Product_Type] WHERE ISDelete=0 AND ISDESABLED=0";

            }
            else if (drop == "MainCat")
            {
                if (id != 0)
                {
                    query = "SELECT [id_MC] as id,[MCName] as [name] FROM[tbl_Product_MainCategory] WHERE ISDelete=0 AND ISDESABLED=0 AND id_PT=" + id;
                }
            }
            else if (drop == "SubCat")
            {
                if (id != 0)
                {
                    query = "SELECT [id_SC] as id,[SCName] as [name] FROM [tbl_Product_SubCategory]WHERE ISDelete=0 AND ISDESABLED =0 AND id_MC=" + id;
                }
            }
            else if (drop == "SubCat_Key")
            {
                if (id != 0)
                {
                    query = "SELECT [id_SCOK] as id,[SCOKName] as [name] FROM[tbl_Product_SubCategoryOptionKey]WHERE ISDelete=0 AND [ISDESABLED]=0 AND [id_SC]=" + id;
                }
            }
            else if (drop == "SubCat_Value")
            {
                if (id != 0)
                {
                    query = "SELECT [id_SCOV] as id,[SCOVValueName] as [name] FROM[tbl_Product_SubCategoryOptionValue]WHERE[id_SCOK] = " + id;
                }
            }
            List<Id_ValueModel> result = new List<Id_ValueModel>();
            if (!query.Equals(""))
            {
                PDBC db = new PDBC("PandaMarketCMS", true);
                db.Connect();

                DataTable dt = db.Select(query);



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var maodel = new Id_ValueModel()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["id"]),
                        Value = dt.Rows[i]["name"].ToString()
                    };
                    result.Add(maodel);
                }
            }
            else
            {
                result.Add(new Id_ValueModel { Id = 0, Value = "انتخاب کنید" });
            }

            return result;
        }

        public List<AddPro_Options> OptionsFiller(int id)
        {
            var result = new List<AddPro_Options>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            DataTable dt = db.Select("SELECT [id_Op],[KeyName],[Value]FROM[tbl_Product_tblOptions] WHERE id_MProduct="+id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new AddPro_Options() 
                {
                    Id=Convert.ToInt32(dt.Rows[i]["id_Op"]),
                    Num=i+1,
                    Key=dt.Rows[i]["KeyName"].ToString(),
                    Value= dt.Rows[i]["Value"].ToString()

                };

                result.Add(model);
            }
            return result;
        }

        public string MainProduct_Actions(string action,int id_MProduct,int Quantity,int QuantityModule, int PriceXquantity, int PricePerquantity, int PriceOff, int offTypeValue, int OffType, int id_MainStarTag, int PriceModule, int PriceShow,string describtion=" ")
        {

            List<ExcParameters> paramss = new List<ExcParameters>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            var parameters = new ExcParameters()
            {
                _KEY = "@id_MProduct",
                _VALUE = id_MProduct
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@Quantity",
                _VALUE = Quantity
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@QuantityModule",
                _VALUE = QuantityModule
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PriceXquantity",
                _VALUE = PriceXquantity
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PricePerquantity",
                _VALUE = PricePerquantity
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PriceOff",
                _VALUE = PriceOff
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@offTypeValue",
                _VALUE = offTypeValue
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@OffType",
                _VALUE = OffType
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@id_MainStarTag",
                _VALUE = id_MainStarTag
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PriceModule",
                _VALUE = PriceModule
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PriceShow",
                _VALUE = PriceShow
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@describtion",
                _VALUE = describtion
            };
            paramss.Add(parameters);

            string query = "";

            if(action=="insert")
            {
                query = "INSERT INTO[tlb_Product_MainProductConnector] Output Inserted.id_MPC VALUES(@id_MProduct, @Quantity, @PriceXquantity, @PricePerquantity, @PriceOff, @offTypeValue, @OffType, @id_MainStarTag , 0 , 0 ,  @QuantityModule ,GetDate(), @PriceModule, @PriceShow,@describtion)";
            }
            else if (action == "update")
            {
                query = "UPDATE [tlb_Product_MainProductConnector]SET [Quantity] =  @Quantity ,[PriceXquantity] = @PriceXquantity,[PricePerquantity] =@PricePerquantity ,[PriceOff] =@PriceOff ,[offTypeValue] = @offTypeValue ,[OffType] = @PriceOff,[id_MainStarTag] = @id_MainStarTag ,[id_PQT] = @QuantityModule,[PriceModule] = @PriceModule ,[PriceShow] = @PriceShow  WHERE id_MPC=@id_MProduct";

            }
            else if(action=="delete")
            {

            }

            if (query != "")
            {
                return db.Script(query, paramss);
            }
            else
                return "0";

        }

       public string Product_Action_Step1(string Action,int id_CreatedByAdmin, string Title, string Description, string SEO_keyword, string SEO_description, string SearchGravity, int IsAd)
        {
            List<ExcParameters> paramss = new List<ExcParameters>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            var parameters = new ExcParameters()
            {
                _KEY = "@id_CreatedByAdmin",
                _VALUE = id_CreatedByAdmin
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@Title",
                _VALUE = Title
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@Description",
                _VALUE = Description
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@SEO_keyword",
                _VALUE = SEO_keyword
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@SEO_description",
                _VALUE = SEO_description
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@SearchGravity",
                _VALUE = SearchGravity
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@IsAd",
                _VALUE = IsAd
            };
            paramss.Add(parameters);

            string query = "";

            //id_CreatedByAdmin, string Title, string Description, string SEO_keyword, string SEO_description, string SearchGravity, int IsAd

            if (Action.Equals("insert"))
            {
                query = "INSERT INTO[tbl_Product] Output Inserted.id_MProduct VALUES(1, @id_CreatedByAdmin , 0 , 0 , 0 , 0 , 0 ,@Description,GETDATE(), @Title , @SEO_description , @SEO_keyword , @IsAd , @SearchGravity , 0 , 0)";
            }
            else if (Action == "update")
            {

            }
            else if (Action == "delete")
            {

            }

            if (query != "")
            {
                return db.Script(query, paramss);
            }
            else
                return "0";
        }

        public string Product_Action_Step2(string Type, string Main, string Sub, string SubKey, int id)
        {
            List<ExcParameters> paramss = new List<ExcParameters>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            var parameters = new ExcParameters()
            {
                _KEY = "@id_Type",
                _VALUE = Type
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@id_MainCategory",
                _VALUE = Main
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@id_SubCategory",
                _VALUE = Sub
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@id_MProduct",
                _VALUE = id
            };
            paramss.Add(parameters);

            string query = "UPDATE [tbl_Product]SET [id_Type] =@id_Type ,[id_MainCategory] =@id_MainCategory ,[id_SubCategory] =@id_SubCategory WHERE [id_MProduct]=@id_MProduct";

            return db.Script(query, paramss);
        }

        public List<Id_ValueModel> TagsModel_Filler(int id)
        {
            var result = new List<Id_ValueModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            
            DataTable dt = db.Select("SELECT [id_TE],[TE_name]FROM [tbl_Product_TagEnums] WHERE SubCatId="+id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id=Convert.ToInt32(dt.Rows[i]["id_TE"]),
                    Value=dt.Rows[i]["TE_name"].ToString()
                };

                result.Add(model);
            }

            return result;
        }

        public List<Id_ValueModel> MainTagsModel_Filler()
        {
            var result = new List<Id_ValueModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();

            DataTable dt = db.Select("SELECT [id_MainStarTag],[MST_Name] FROM [tbl_Product_MainStarTags]");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["id_MainStarTag"]),
                    Value = dt.Rows[i]["MST_Name"].ToString()
                };

                result.Add(model);
            }

            return result;
        }

        public List<Id_ValueModel> OffTypeModel_Filler()
        {
            var result = new List<Id_ValueModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();

            DataTable dt = db.Select("SELECT [OffType],[OffType_Symbol]FROM .[tbl_Product_OffType]");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["OffType"]),
                    Value = dt.Rows[i]["OffType_Symbol"].ToString()
                };

                result.Add(model);
            }

            return result;
        }

        public List<Id_ValueModel> PQTModel_Filler()
        {
            var result = new List<Id_ValueModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();

            DataTable dt = db.Select("SELECT[id_PQT],[PQT_Demansion] FROM[tbl_Product_ProductQuantityType] order by([PQT_Demansion])");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["id_PQT"]),
                    Value = dt.Rows[i]["PQT_Demansion"].ToString()
                };

                result.Add(model);
            }

            return result;
        }

        public List<Id_ValueModel> MoneyTypeModel_Filler()
        {
            var result = new List<Id_ValueModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();

            DataTable dt = db.Select("SELECT [MoneyId],[MoneyTypeName] FROM [tbl_Product_MoneyType]" );

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["MoneyId"]),
                    Value = dt.Rows[i]["MoneyTypeName"].ToString()
                };

                result.Add(model);
            }

            return result;
        }

        public List<Id_ValueModel> PriceShowModel_Filler()
        {
            var result = new List<Id_ValueModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();

            DataTable dt = db.Select("SELECT [PriceShowId],[PriceShowformat] FROM [tbl_Product_PriceShow]");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["PriceShowId"]),
                    Value = dt.Rows[i]["PriceShowformat"].ToString()
                };

                result.Add(model);
            }

            return result;
        }

        public List<PricingModel> pricingModelfiller(int id)
        {
            var result = new List<PricingModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();

            DataTable dt = db.Select("SELECT [id_MPC],[Quantity],[PriceXquantity],[PricePerquantity],[PriceOff],[offTypeValue],[OffType],[id_MainStarTag],[ISDELETE],[id_PQT],[PriceModule],[PriceShow],[describtion]FROM[tlb_Product_MainProductConnector] Where [id_MProduct]=" + id);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new PricingModel()
                {
                    Id=Convert.ToInt32(dt.Rows[i]["id_MPC"]),
                    MainTagId= Convert.ToInt32(dt.Rows[i]["id_MainStarTag"]),
                    OffType= Convert.ToInt32(dt.Rows[i]["OffType"]),
                    OffVal=long.Parse(dt.Rows[i]["offTypeValue"].ToString()),
                    PerQuantity = long.Parse(dt.Rows[i]["PricePerquantity"].ToString()),
                    PriceOff = long.Parse(dt.Rows[i]["PriceOff"].ToString()),
                    PriceModule = Convert.ToInt32(dt.Rows[i]["PriceModule"]),
                    PriceShow = Convert.ToInt32(dt.Rows[i]["PriceShow"]),
                    Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]),
                    QuantityType = Convert.ToInt32(dt.Rows[i]["id_PQT"])
                    
                };

                if(dt.Rows[i]["ISDELETE"].ToString()=="1")
                {
                    model.IsDeleted = true;
                }
                else
                {
                    model.IsDeleted = false;
                }

                List<string> attr = new List<string>();
                string s = "";
                DataTable dt1 = db.Select("SELECT B.SCOVValueName FROM [tbl_Product_connectorToMPC_SCOV] as A inner join [tbl_Product_SubCategoryOptionValue] as B On A.id_SCOV=B.id_SCOV WHERE A.id_MPC="+model.Id+" Group By(B.SCOVValueName)");
                if(dt1.Rows.Count>0)
                {
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        attr.Add(dt1.Rows[j]["SCOVValueName"].ToString());
                        s += dt1.Rows[j]["SCOVValueName"].ToString() + " , ";
                    }
                }
                else
                {
                    attr.Add("ندارد");
                }
                
                model.Attributes = attr;
                model.Description = s;
                
                List<int> tags = new List<int>();

                DataTable dt2 = db.Select("SELECT [id_TE] FROM [tbl_Product_tagConnector] WHERE id_MPC=" + model.Id);

                if (dt1.Rows.Count > 0)
                {
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {

                        tags.Add(Convert.ToInt32(dt2.Rows[j]["id_TE"]));

                    }
                
                }
                else
                {
                    tags.Add(0);
                }
                model.Tags = tags;

                result.Add(model);
            }

            return result;

        }

        public List<TableModel> SCVModel(int id)
        {
            var result = new List<TableModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            DataTable dt;
            if (id==0)
            {
                 dt = db.Select("SELECT A.id_SCOV, A.SCOVValueName , B.SCOKName FROM [tbl_Product_SubCategoryOptionValue]as A inner join [tbl_Product_SubCategoryOptionKey] as B On A.id_SCOK=B.id_SCOK Where B.ISDelete=0 AND B.ISDESABLED=0");

            }
            else
            {
                dt = db.Select("SELECT A.id_SCOV, A.SCOVValueName , B.SCOKName FROM [tbl_Product_SubCategoryOptionValue]as A inner join [tbl_Product_SubCategoryOptionKey] as B On A.id_SCOK=B.id_SCOK Where B.ISDelete=0 AND B.ISDESABLED=0 AND A.id_SCOK=" + id);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new TableModel()
                {
                    Num=i+1,
                    Id=Convert.ToInt32( dt.Rows[i]["id_SCOV"]),
                    Group1=dt.Rows[i]["SCOVValueName"].ToString(),
                    Group2 = dt.Rows[i]["SCOKName"].ToString()
                };

                result.Add(model);
            }
            return result;
        }

        public List<TableModel> Tags(int SubId)
        {
            var result = new List<TableModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
            DataTable dt;
            if (SubId == 0)
            {
                dt = db.Select("SELECT [id_TE],[TE_name],B.SCName FROM [tbl_Product_TagEnums] as A inner join [tbl_Product_SubCategory] as B On A.SubCatId=B.id_SC WHERE B.ISDelete=0 AND B.ISDESABLED=0 ");

            }
            else
            {
                dt = db.Select("SELECT [id_TE],[TE_name],B.SCName FROM [tbl_Product_TagEnums] as A inner join [tbl_Product_SubCategory] as B On A.SubCatId=B.id_SC WHERE B.ISDelete=0 AND B.ISDESABLED=0 AND A.SubCatId=" + SubId);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new TableModel()
                {
                    Num = i + 1,
                    Id = Convert.ToInt32(dt.Rows[i]["id_TE"]),
                    Group1 = dt.Rows[i]["TE_name"].ToString(),
                    Group2 = dt.Rows[i]["SCName"].ToString()
                };

                result.Add(model);
            }
            return result;
        }

        public List<TableModel> MainTags()
        {
            var result = new List<TableModel>();
            PDBC db = new PDBC("PandaMarketCMS", true);
            db.Connect();
           
              DataTable  dt = db.Select("SELECT [id_MainStarTag],[MST_Description],[MST_Name] FROM [tbl_Product_MainStarTags]");


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new TableModel()
                {
                    Num = i + 1,
                    Id = Convert.ToInt32(dt.Rows[i]["id_MainStarTag"]),
                    Group1 = dt.Rows[i]["MST_Name"].ToString(),
                    Group2 = dt.Rows[i]["MST_Description"].ToString()
                };

                result.Add(model);
            }
            return result;
        }


    }
}