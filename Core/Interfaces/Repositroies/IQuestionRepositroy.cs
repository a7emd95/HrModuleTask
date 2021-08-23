using Core.Entites;
using Core.Interfaces.Base;
using Core.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositroies
{
    public interface IQuestionRepositroy : IRepositroy<Question>
    {
        IQueryable<Question> GetAllQuestionWithType();
        Question GetQuestionWithAnswer(int id);
    }
}
