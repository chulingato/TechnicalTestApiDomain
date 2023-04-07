using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<SaleOrderDetail> saleOrderDetail { get; set; }

    }
}
