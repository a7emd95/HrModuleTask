using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Question
{
   public class GetQuestionWithTypeModel
    {
        public int ID { get; set; }
        public Guid PublicId { get; set; }
        public string QuestionBodyText { get; set; }
        public int QuestionTypeId { get; set; }

        public string QuestionType { get; set; }
    }
}
