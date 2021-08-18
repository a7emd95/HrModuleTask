using Core.Models.JobPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Candidate
{
    public class GetCandiateWithPositionsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<GetJobPositionModel> Positions { get; set; }
    }
}
