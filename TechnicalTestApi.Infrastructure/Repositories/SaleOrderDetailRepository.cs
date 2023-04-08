using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechnicalTestApi.Domain;
using TechnicalTestApi.Domain.Interfaces.Repositories;
using TechnicalTestApi.Infrastructure.Contexts;

namespace TechnicalTestApi.Infrastructure.Repositories
{
    public class SaleOrderDetailRepository : ISaleOrderDetailRepository<SaleOrderDetail, Guid>
    {
        private SaleOrderContext _saleOrderContextDb;

        public SaleOrderDetailRepository(SaleOrderContext saleOrderContextDb)
        {
            _saleOrderContextDb = saleOrderContextDb;
        }
        public SaleOrderDetail Add(SaleOrderDetail entity)
        {
            _saleOrderContextDb.SaleOrdersDetail.Add(entity);
            return entity;
        }

        public void SaveAllChanges()
        {
            _saleOrderContextDb.SaveChanges();
        }
    }
}
