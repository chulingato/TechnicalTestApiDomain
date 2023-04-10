using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestApi.Domain.Interfaces;

namespace TechnicalTestApi.Domain.Interfaces.Repositories
{
    public interface IBaseConfigurationRepository<TEntity, TEntitykey> : IListKey<TEntity, TEntitykey>
    {
        Configuration GetBykey(string key);
    }
}
