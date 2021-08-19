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
    public class QuestionAnswerRepository : BaseRepositroy<QuestionAnswer>, IQuestionAnswerRepository
    {
        public QuestionAnswerRepository(DbContext context) : base(context){ }
    }
}
