﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestApi.Domain.Interfaces
{
    public interface IAdd<TEntity>
    {
        TEntity Add(TEntity entity);
    }
}
