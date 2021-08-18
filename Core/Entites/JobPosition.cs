using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{

    public class JobPosition
    {
        public int ID { get; set; }
        public Guid PublicID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CandidatePosition> CandidatePositions { get; set; }
        public virtual ICollection<PositionQuestion> PositionQuestions { get; set; }
    }
}
