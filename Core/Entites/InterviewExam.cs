using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class InterviewExam
    { 
  
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime SubmissionDateTime { get; set; }
        public double Score { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual ICollection<CandidateAnswer> CandidateAnswers { get; set; }
    }
}
