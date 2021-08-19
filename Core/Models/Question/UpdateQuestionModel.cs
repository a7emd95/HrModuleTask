using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Question
{
    public class UpdateQuestionModel
    {
        public string QuestionBodyText { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
