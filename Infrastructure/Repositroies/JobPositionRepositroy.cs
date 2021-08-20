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
    public class JobPositionRepositroy : BaseRepositroy<JobPosition>, IJobPositionRepositroy
    {
        public JobPositionRepositroy(DbContext context) : base(context) { }

        public void DeletePosition(Guid publicId)
        {
            var jopPosition = GetFristOrDefult(jp => jp.PublicID == publicId);
            Delete(jopPosition.ID);
        }
    }
}
