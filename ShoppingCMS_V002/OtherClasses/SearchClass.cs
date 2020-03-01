using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ShoppingCMS_V002.OtherClasses
{
    public class SearchClass
    {
        public string QueryMaker(string text, int TypeId = 0, int MainCatId = 0, int SubCatId = 0)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT [tbl_Product].[id_MProduct],[tbl_Product].[IS_AVAILABEL],[tbl_Product].[id_CreatedByAdmin],[tbl_Product].[id_DraftLevel],[tbl_Product].[id_Type],[tbl_Product].[id_MainCategory],[tbl_Product].[id_SubCategory],[tbl_Product].[idMPC_WhichTomainPrice],[tbl_Product].[Description],[tbl_Product].[DateCreated],[tbl_Product].[Title],[tbl_Product].[Seo_Description],[tbl_Product].[Seo_KeyWords],[tbl_Product].[IS_AD],[tbl_Product].[Is_IntheDraft],[tbl_Product].[ISDELETE],(SELECT top 1 [BigPicAddress]FROM[tbl_Product_Pic]where[tbl_Product_Pic].[id_MProduct]=[tbl_Product].[id_MProduct]) as [pic],[PriceXquantity],[PricePerquantity],[PriceOff],[OffType]FROM [tbl_Product]INNER JOIN [tlb_Product_MainProductConnector] ON [tbl_Product].[id_MProduct]=[tlb_Product_MainProductConnector].[id_MProduct]");
            bool where = false;

            if (TypeId != 0)
            {
                if (!where)
                {
                    query.Append(" WHERE ");
                    where = true;
                }

                query.Append("[id_Type]=" + TypeId);
            }

            if (MainCatId != 0)
            {
                if (!where)
                {
                    query.Append(" WHERE ");
                    where = true;
                }
                else
                {
                    query.Append(" AND ");
                }

                query.Append("[id_MainCategory]=" + MainCatId);
            }

            if (SubCatId != 0)
            {
                if (!where)
                {
                    query.Append(" WHERE ");
                    where = true;
                }
                else
                {
                    query.Append(" AND ");
                }

                query.Append("[id_SubCategory]=" + SubCatId);
            }

            if (text != "")
            {
                if (!where)
                {
                    query.Append(" WHERE ");
                    where = true;
                }
                else
                {
                    query.Append(" AND ");
                }

                query.Append("([Title] LIKE N'%" + text + "%'OR[Description] LIKE N'%" + text + "%')");
            }

            query.Append("ORDER BY(Search_Gravity)DESC , DateCreated DESC");
            return query.ToString();
        }

    }
}