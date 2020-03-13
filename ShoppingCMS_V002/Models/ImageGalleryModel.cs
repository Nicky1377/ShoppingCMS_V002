using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class ImageGalleryModels
    {
        public List<ImageGalleryModel> models { set; get; }
    }
    public class ImageGalleryModel
    {
        public string id { get; set; }
        public string ImageName { get; set; }
        public string label { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int check { set; get; }
        public void imageAddress(string url)
        {
            Address = "https://" + HttpContext.Current.Request.Url.Authority  + url;
        }
    }
}