using Core.Models.Question;
using Core.Models.QuestionAnswer;
using Core.Models.QuestuinType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.AppServices
{
    public interface IQuestionService : IDisposable
    {
        List<GetQuestionModel> GetAllQuestions();

        GetQuestionModel GetQuestion(int questionId);

        GetQuestionModel CreateNewQuestion(CreateQuestionModel questionModel);
        bool UpdateQuestion(UpdateQuestionModel questionModel);

        bool DeleteQuestion(int questionId);

        List<GetQuestionTypeModel> GetQuestionTypes();

        GetQuestionAnswerModel AddAnswerToQuestion(CreateQuestionAnswerModel answerModel);

        public GetQuestionTypeModel GetQuestionTypeByID(int id);

        public List<GetQuestionWithTypeModel> GetAllQuestionWithType();



    }
}
