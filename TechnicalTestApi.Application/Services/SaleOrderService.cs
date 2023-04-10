using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechnicalTestApi.Domain;
using TechnicalTestApi.Domain.Interfaces.Repositories;
using TechnicalTestApi.Application.Interfaces;
using System.ComponentModel;

namespace TechnicalTestApi.Application.Services
{
    public class SaleOrderService : ISaleOrderService<SaleOrder, Guid>
    {
        ISaleOrderRepository<SaleOrder, Guid> _saleOrderRepository;
        IBaseRepository<Product, Guid> _productRepository;
        ISaleOrderDetailRepository<SaleOrderDetail, Guid> _saleOrderDetailRepository;
        IBaseConfigurationRepository<Configuration, string> _configurationRepository;

        public SaleOrderService(
        ISaleOrderRepository<SaleOrder, Guid> saleOrderRepository,
        IBaseRepository<Product, Guid> productRepository,
        ISaleOrderDetailRepository<SaleOrderDetail,Guid> saleOrderDetailRepository,
        IBaseConfigurationRepository<Configuration,string> configurationRepository)
        { 
            _saleOrderDetailRepository = saleOrderDetailRepository;
            _productRepository = productRepository;
            _saleOrderRepository = saleOrderRepository;
            _configurationRepository = configurationRepository;
        }

        public SaleOrder Add(SaleOrder entity)
        {
            if (entity == null) throw new ArgumentNullException("La venta es requerida");

            Configuration ivaConfig = _configurationRepository.GetBykey("IVA");

            if (ivaConfig == null) throw new ArgumentNullException("La configuracion del IVA es requerida");

            var saleOrderAdded = _saleOrderRepository.Add(entity);
            
            decimal iva;
            decimal.TryParse(ivaConfig.value, out iva);

            entity.saleOrderDetail.ForEach(orderDetail =>
            {
                var productSelected = _productRepository.GetById(orderDetail.productId);
                if (productSelected == null)
                    throw new NullReferenceException("para esta venta, el producto no existe");
                if (productSelected.stock < orderDetail.quantity)
                    throw new NullReferenceException("no existe stock para el producto");

                orderDetail.unitaryCost = productSelected.cost;
                orderDetail.unitaryPrice = productSelected.price;
                orderDetail.subtotal = orderDetail.unitaryPrice * orderDetail.quantity;
                orderDetail.tax = orderDetail.subtotal * iva  / 100;
                orderDetail.total = orderDetail.subtotal + orderDetail.tax;
                _saleOrderDetailRepository.Add(orderDetail);

                //actualizamos stock
                productSelected.stock -= orderDetail.quantity;
                _productRepository.Edit(productSelected);

                entity.subtotal += orderDetail.subtotal;
                entity.tax += orderDetail.tax;
                entity.total += orderDetail.total;
            });
            _saleOrderRepository.SaveAllChanges();
            return entity;
        }

        public void Annull(Guid entityId)
        {
            _saleOrderRepository.Annull(entityId);
            _saleOrderRepository.SaveAllChanges();
        }

        public List<SaleOrder> GetAll()
        {
            return _saleOrderRepository.GetAll();
        }

        public SaleOrder GetById(Guid entityId)
        {
            return _saleOrderRepository.GetById(entityId); 
        }
    }
}
