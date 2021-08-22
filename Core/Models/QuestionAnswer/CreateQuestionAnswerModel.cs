using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.QuestionAnswer
{
    public class CreateQuestionAnswerModel
    {

        public string AnswerBodyText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
