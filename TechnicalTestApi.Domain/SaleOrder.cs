using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestApi.Domain
{
    public class SaleOrder
    {
        public Guid saleOrderId { get; set; }
        public long saleOrderNumber { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public decimal subtotal { get; set; }
        public decimal tax { get; set; }
        public decimal total { get; set; }
        public Boolean annulled { get; set; } = false;
        public List<SaleOrderDetail> saleOrderDetail { get; set; }
    }
}
