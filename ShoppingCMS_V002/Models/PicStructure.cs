using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class PicStructure
    {
        public string PicID { get; set; }
        public Piccategorytype PicCategoryType { get; set; }
        public string ISDELETE { get; set; }
        public string alt { get; set; }
        public string UploadPicName { get; set; }
        public string Type { get; set; }
    }
    public class Piccategorytype
    {
        public string PicCategoryType { get; set; }
        public string PicCategoryTypeName { get; set; }
    }

    public class picsizetype
    {
        public string picSizeType  { get; set; }
        public string picSizeTypeWidth { get; set; }
        public string picSizeTypeHeight { get; set; }
    }

    public class PicStructureImageAddress
    {
        public string PicID { get; set; }
        public Piccategorytype PicCategoryType { get; set; }
        public string ISDELETE { get; set; }
        public string alt { get; set; }
        public string UploadPicName { get; set; }
        public string Type { get; set; }
    }

}