using Core.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUi.Models
{
    public class CandidateExamAnswersViewModel
    {
        public int InterViewExamId { get; set; }
        public List<GetQuestionWithAnswersModel> ExamQuestions { get; set; }
    }
}
