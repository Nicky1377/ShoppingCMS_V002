using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.OtherClasses
{
    public class OptionsJsonModel
    {
        [JsonProperty("item")]
        public List<itemclas> item { get; set; }
    }

}