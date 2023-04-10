using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestApi.Domain.Interfaces.Repositories;
using TechnicalTestApi.Domain;
using TechnicalTestApi.Infrastructure.Contexts;

namespace TechnicalTestApi.Infrastructure.Data.Repositories
{
    public class ConfigurationRepository : IBaseConfigurationRepository<Configuration, string>
    {
        private SaleOrderContext _saleOrderContextDb;
        public ConfigurationRepository(SaleOrderContext saleOrderContextDb) {
            _saleOrderContextDb = saleOrderContextDb;
        }

        public Configuration GetBykey(string key)
        {
            var configurationSelected = _saleOrderContextDb.Configuration.Where(configuration => configuration.key == key).FirstOrDefault();

            return configurationSelected;
        }
    }
}
