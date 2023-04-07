using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechnicalTestApi.Domain.Interfaces;

namespace TechnicalTestApi.Application.Interfaces
{
    public interface ISaleOrderService<TEntity, TEntityId>
        : IAdd<TEntity>, IList<TEntity,TEntityId>
    {
        void Annull(TEntityId entityId);
    }
}
