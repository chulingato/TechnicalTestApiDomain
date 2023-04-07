﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestApi.Domain.Interfaces
{
    public interface IEdit<TEntity>
    {
        void Edit(TEntity entity);
    }
}
