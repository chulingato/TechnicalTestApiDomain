using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestApi.Application.Interfaces;
using TechnicalTestApi.Domain;
using TechnicalTestApi.Domain.Interfaces.Repositories;

namespace TechnicalTestApi.Application.Services
{
    public class ConfigurationService : IBaseConfigurationService<Configuration, string>
    {
        private readonly IBaseConfigurationRepository<Configuration, Guid> _baseRepository;
        public ConfigurationService(IBaseConfigurationRepository<Configuration,Guid> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Configuration GetBykey(string key)
        {
            return _baseRepository.GetBykey(key);
        }
    }
}
