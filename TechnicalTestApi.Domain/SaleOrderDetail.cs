using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestApi.Domain
{
    public class SaleOrderDetail
    {
        public Guid productId { get; set; }
        public Guid saleOrderId { get; set; }
        public decimal unitaryCost { get; set; }
        public decimal unitaryPrice { get; set; }
        public decimal quantity { get; set; }
        public decimal subtotal { get; set; }
        public decimal tax { get; set; }
        public decimal total { get; set; }
        public Product product { get; set; }
        public SaleOrder saleOrder { get; set; }


    }
}
