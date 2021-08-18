﻿using Core.Entites;
using Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositroies
{
    public interface ICandidateRepositroy : IRepositroy<Candidate>
    {
        IQueryable<Candidate> GetAllCandidateWithPosition();
        Candidate GetCandidatWithPosition(int candidateId);
    }
}
