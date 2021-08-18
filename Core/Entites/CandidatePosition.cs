using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class CandidatePosition
    {
        public int ID { get; set; }
        public int JobPositionId { get; set; }
        public int CandidateId { get; set; }
        public bool IsActive { get; set; }

        public virtual JobPosition JobPosition { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
