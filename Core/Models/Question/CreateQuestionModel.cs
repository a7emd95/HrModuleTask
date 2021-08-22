using Core.Models.QuestionAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Question
{
    public class CreateQuestionModel
    {
        public string QuestionBodyText { get; set; }
        public int QuestionTypeId { get; set; }
        public List<CreateQuestionAnswerModel> Answers { get; set; }
        public List<int> PositionsId { get; set; }

        public int NumberOfAnswer
        {
            get => Answers.Count;
        }

        public int NumberOfPosition
        {
            get => PositionsId.Count;
        }

        public CreateQuestionModel()
        {
            Answers = new List<CreateQuestionAnswerModel>();
            PositionsId = new List<int>();
        }
    }
}
