using Core.Interfaces.Base;
using Core.Interfaces.Repositroies;
using Infrastructure.Persistence;
using Infrastructure.Repositroies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Base
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext context)
        {
            _dbContext = context;
        }

        public void Dispose(){
            _dbContext.Dispose();
        }

        public int SaveChanges(){
           return _dbContext.SaveChanges();
        }


        private JobPositionRepositroy jobPositionRepo;
        public  IJobPositionRepositroy JobPositionRepositroy
        {
            get
            {
                if (jobPositionRepo == null)
                {
                    jobPositionRepo = new JobPositionRepositroy(_dbContext);
                }
                return jobPositionRepo;
            }
     }
    
    }
}

