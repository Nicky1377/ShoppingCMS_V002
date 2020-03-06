using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.OtherClasses
{
    public class itemclas
    {
        [JsonProperty("Mainid")]
        public int MainId { get; set; }
        [JsonProperty("Ids")]
        public string Ids { get; set; }
    }
}