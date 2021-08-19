using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class CandidateAnswer
    {
        public int ID { get; set; }
        public Guid PublicId { get; set; }
        public string AnswerBodyText { get; set; }
        public bool? IsCorrect { get; set; }

        public int InterviewExamId { get; set; }
        public int QuestionId { get; set; }

        public virtual InterviewExam InterviewExam { get; set; }
        public virtual Question Question { get; set; }



    }
}
