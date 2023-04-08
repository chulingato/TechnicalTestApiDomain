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
    public class ProductRepository : IBaseRepository<Product, Guid>
    {
        private SaleOrderContext _saleOrderContextDb;

        public ProductRepository(SaleOrderContext saleOrderContextDb)
        {
            _saleOrderContextDb = saleOrderContextDb;
        }

        public Product Add(Product entity)
        {
            entity.productId = Guid.NewGuid();
            _saleOrderContextDb.Add(entity);
            return entity;
        }

        public void Delete(Guid entityId)
        {
            var productSelected = _saleOrderContextDb.Products.Where(product => product.productId == entityId).FirstOrDefault();
            if (productSelected != null)
            {
                _saleOrderContextDb.Products.Remove(productSelected);
            }
        }

        public void Edit(Product entity)
        {
            var productSelected = _saleOrderContextDb.Products.Where(product => product.productId == entity.productId).FirstOrDefault();
            if (productSelected != null)
            {
                productSelected.name = entity.name;
                productSelected.description = entity.description;
                productSelected.price = entity.price;   
                productSelected.cost = entity.cost; 
                productSelected.stock = entity.stock;

                _saleOrderContextDb.Entry(productSelected).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public List<Product> GetAll()
        {
            return _saleOrderContextDb.Products.ToList();
        }

        public Product GetById(Guid entityId)
        {
            var productSelected = _saleOrderContextDb.Products.Where(product => product.productId == entityId).FirstOrDefault();

            return productSelected;
            
        }

        public void SaveAllChanges()
        {
           _saleOrderContextDb.SaveChanges();
        }
    }
}
