using Core.Models.QuestionAnswer;
using Core.Models.QuestuinType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Question
{
    public class GetQuestionWithAnswersModel
    {
        public int ID { get; set; }
        
        public string QuestionBodyText { get; set; }
        public int QuestionTypeId { get; set; }
        public List<GetQuestionAnswerModel> QuestionAnswers { get; set; }
     
        //public GetQuestionTypeModel QuestionType { get; set; }

        public int CandidateSelectedAnswer { get; set; } 



    }
}
