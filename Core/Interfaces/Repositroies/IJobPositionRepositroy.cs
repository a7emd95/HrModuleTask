﻿using Core.Entites;
using Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositroies
{
    public interface IJobPositionRepositroy : IRepositroy<JobPosition>
    {
        void DeletePosition(Guid publicId);
        IQueryable<JobPosition> GetAllActivePositions();
        JobPosition GetJobPositionWithPositionsQuestions(int id);

    }
}
