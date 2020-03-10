using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCMS_V002.Models
{
    public class PricingModel
    {
        public int Id { get; set; }
        public List<string> Attributes { get; set; }
        public int Quantity { get; set; }
        public long PerQuantity { get; set; }
        public long PriceOff { get; set; }
        public int OffType { get; set; }
        public long OffVal { get; set; }
        public int QuantityType { get; set; }
        public int PriceModule { get; set; }
        public int PriceShow { get; set; } 
        public string Description { get; set; }
        public List<int> Tags { get; set; }
        public int MainTagId { get; set; }
        public bool IsDeleted { get; set; }

    }
}