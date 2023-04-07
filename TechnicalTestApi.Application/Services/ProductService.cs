using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechnicalTestApi.Domain;
using TechnicalTestApi.Domain.Interfaces;
using TechnicalTestApi.Application.Interfaces;
using TechnicalTestApi.Domain.Interfaces.Repositories;

namespace TechnicalTestApi.Application.Services
{
    public class ProductService : IBaseService<Product, Guid>
    {
        private readonly IBaseRepository<Product, Guid> _baseRepository;

        public ProductService(IBaseRepository<Product, Guid> baseRepository)
        {
            _baseRepository = baseRepository;   
        }
        public Product Add(Product entity)
        {
            if (entity == null) throw new ArgumentNullException("El producto es requerido");

            var productObtained = _baseRepository.Add(entity);
            _baseRepository.SaveAllChanges();
            return productObtained;
        }

        public void Delete(Guid entityId)
        {
            _baseRepository.Delete(entityId);
            _baseRepository.SaveAllChanges();
        }

        public void Edit(Product entity)
        {
            if (entity == null) throw new ArgumentNullException("El producto es requerido");

            _baseRepository.Edit(entity);
            _baseRepository.SaveAllChanges();

        }

        public List<Product> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public Product GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }
    }
}
