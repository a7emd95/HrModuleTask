using Core.Entites;
using Core.Interfaces.Repositroies;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositroies
{
    class CandidateAnswerRepositroy : BaseRepositroy<CandidateAnswer>, ICandidateAnswerRepository
    {
        public CandidateAnswerRepositroy(DbContext context) : base(context){ }
    }
}
