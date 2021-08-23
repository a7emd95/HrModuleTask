using Core.Entites;
using Core.Interfaces.Repositroies;
using Core.Models.Question;
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

        public IQueryable<Question> GetAllQuestionWithType()
        {
            return _dbSet.Include(q => q.QuestionType);
        }

        public Question GetQuestionWithAnswer(int id)
        {
            return _dbSet.Include(q => q.QuestionAnswers).Include(q => q.QuestionType).FirstOrDefault(q => q.ID == id);
        }
    }
}
