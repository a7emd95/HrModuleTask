using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Candidate
{
    public class UpdateCandidateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }
    }
}
