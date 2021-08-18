using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.JobPosition
{
    public class GetJobPositionModel
    {
        public int ID { get; set; }
        public Guid PublicID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
