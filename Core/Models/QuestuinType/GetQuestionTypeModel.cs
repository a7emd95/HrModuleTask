using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.QuestuinType
{
    public class GetQuestionTypeModel
    {
        public int ID { get; set; }
        public Guid publicId { get; set; }
        public string Type { get; set; }
    }
}
