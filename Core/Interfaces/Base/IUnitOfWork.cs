﻿using Core.Interfaces.Repositroies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        IJobPositionRepositroy JobPositionRepositroy { get; }
    }
}