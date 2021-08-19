using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Candidate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<CandidatePosition> CandidatePositions { get; set; }
        public virtual ICollection<InterviewExam> InterviewExams { get; set; }
    }
}
