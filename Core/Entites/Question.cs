using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class Question
    {
        public int ID {get;set;} 
        public Guid PublicId { get; set; }
        public string QuestionBodyText { get; set; }

        public int QuestionTypeId { get; set; }

        public virtual ICollection<PositionQuestion> PositionQuestions { get; set; }
        public virtual QuestionType QuestionType { get; set; }
    }
}
