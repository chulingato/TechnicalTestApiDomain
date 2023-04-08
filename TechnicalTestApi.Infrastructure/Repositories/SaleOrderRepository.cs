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
    public class SaleOrderRepository : ISaleOrderRepository<SaleOrder, Guid>
    {
        private SaleOrderContext _saleOrderContextDb;

        public SaleOrderRepository(SaleOrderContext saleOrderContext)
        {
            _saleOrderContextDb = saleOrderContext;
        }
        public SaleOrder Add(SaleOrder entity)
        {
            entity.saleOrderId = Guid.NewGuid();
            _saleOrderContextDb.Add(entity);
            return entity;
        }

        public void Annull(Guid entityId)
        {
            var saleOrderSelected = _saleOrderContextDb.SaleOrders.Where(order => order.saleOrderId == entityId).FirstOrDefault();
            if (saleOrderSelected == null)
                throw new NullReferenceException("la venta no existe!");

            saleOrderSelected.annulled = true;
            _saleOrderContextDb.Entry(saleOrderSelected).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<SaleOrder> GetAll()
        {
            return _saleOrderContextDb.SaleOrders.ToList();
        }

        public SaleOrder GetById(Guid entityId)
        {
            var saleOrderSelected = _saleOrderContextDb.SaleOrders.Where(order => order.saleOrderId == entityId).FirstOrDefault();
            return saleOrderSelected;
        }

        public void SaveAllChanges()
        {
            _saleOrderContextDb.SaveChanges();
        }
    }
}
