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
    public class CandidateRepositroy : BaseRepositroy<Candidate>, ICandidateRepositroy
    {
        public CandidateRepositroy(DbContext context) : base(context) { }

        public IQueryable<Candidate> GetAllCandidateWithPosition()
        {
            return _dbSet.Include(c => c.CandidatePositions);
        }

        public Candidate GetCandidatWithPosition(int candidateId)
        {
            return _dbSet.Include(c => c.CandidatePositions).FirstOrDefault(c => c.ID == candidateId);
        }
    }
}
