using Core.Models.Question;
using Core.Models.QuestuinType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.AppServices
{
    public interface IQuestionAppService : IDisposable
    {
        List<GetQuestionModel> GetAllQuestions();

        GetQuestionModel GetQuestion(int questionId);

        GetQuestionModel CreateNewQuestion(CreateQuestionModel questionModel);
        bool UpdateQuestion(UpdateQuestionModel questionModel);

        bool DeleteQuestion(int questionId);

        List<GetQuestionTypeModel> GetQuestionTypes();



    }
}
