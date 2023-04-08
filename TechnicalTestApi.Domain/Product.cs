using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TechnicalTestApi.Domain
{
    public class Product
    {
        public Guid productId {  get; set; }
        public string name { get; set; }    
        public string description { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public decimal stock { get; set; }
        [JsonIgnore]
        public List<SaleOrderDetail>? saleOrderDetail { get; set; }
        //public virtual ICollection<SaleOrderDetail> saleOrderDetail { get; set; }

    }
}
