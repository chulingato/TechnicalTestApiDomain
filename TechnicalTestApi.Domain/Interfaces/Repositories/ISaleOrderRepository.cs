using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestApi.Domain.Interfaces;

namespace TechnicalTestApi.Domain.Interfaces.Repositories
{
    public interface ISaleOrderRepository<TEntity, TEntityId>
        : IAdd<TEntity>, IList<TEntity, TEntityId>, ITransacction
    {
        void Annull(TEntityId entity);

    }
}
