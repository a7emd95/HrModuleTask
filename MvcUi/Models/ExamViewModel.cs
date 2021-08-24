using Core.Models.Candidate;
using Core.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUi.Models
{
    public class ExamViewModel
    {

        public int InterViewExamId { get; set; }
        public string CandidateName { get; set; }

        public string CandidatePosition { get; set; }
        public List<GetQuestionWithAnswersModel> ExamQuestions { get; set; }

        public int NumberOfOuestion { get; set; }



    }
}
