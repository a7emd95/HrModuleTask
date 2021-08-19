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
    public class QuestionRepositroy : BaseRepositroy<Question>, IQuestionRepositroy
    {
        public QuestionRepositroy(DbContext context) : base(context)
        {
        }
    }
}
