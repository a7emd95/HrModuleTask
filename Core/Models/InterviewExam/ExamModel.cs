using Core.Models.Candidate;
using Core.Models.JobPosition;
using Core.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.InterviewExam
{
    public class ExamModel
    {
      
        public int InterViewExamId { get; set; }
        public GetCandiateWithPositionsModel Candidate { get; set; }
        public List<GetQuestionWithAnswersModel> ExamQuestions { get; set; }

       
        public int NumberOfOuestion
        {
            get => ExamQuestions.Count;
        }

        public ExamModel()
        {
            ExamQuestions = new List<GetQuestionWithAnswersModel>();
        }
    }
}
