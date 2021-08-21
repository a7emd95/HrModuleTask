using AutoMapper;
using Core.Entites;
using Core.Interfaces.AppServices;
using Core.Interfaces.Base;
using Core.Models.Question;
using Core.Models.QuestuinType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class QuestionAppService : IQuestionAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public List<GetQuestionModel> GetAllQuestions()
        {
            return _mapper.Map<List<GetQuestionModel>>(_unitOfWork.QuestionRepositroy.GetAll());
        }

        public GetQuestionModel GetQuestion(int questionId)
        {
            return _mapper.Map<GetQuestionModel>(_unitOfWork.QuestionRepositroy.GetById(questionId));
        }
        public GetQuestionModel CreateNewQuestion(CreateQuestionModel questionModel)
        {
            var newQuestion = _mapper.Map<Question>(questionModel);
            var insertedQuestion = _unitOfWork.QuestionRepositroy.Insert(newQuestion);

            if (_unitOfWork.SaveChanges() > new int())
                return _mapper.Map<GetQuestionModel>(insertedQuestion);
            return null;
        }

        public bool UpdateQuestion(UpdateQuestionModel questionModel)
        {
            var question = _mapper.Map<Question>(questionModel);
            _unitOfWork.QuestionRepositroy.Update(question);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        public bool DeleteQuestion(int questionId)
        {
            _unitOfWork.QuestionRepositroy.Delete(questionId);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        public List<GetQuestionTypeModel> GetQuestionTypes()
        {
            return _mapper.Map<List<GetQuestionTypeModel>>(_unitOfWork.QuestionTypeRepositroy.GetAll());
        }
    }
}
