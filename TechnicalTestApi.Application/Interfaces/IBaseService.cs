using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTestApi.Domain.Interfaces;

namespace TechnicalTestApi.Application.Interfaces
{
    internal interface IBaseService<TEntity, TEntityId>
        :IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IList<TEntity,TEntityId>
    {
    }
}
