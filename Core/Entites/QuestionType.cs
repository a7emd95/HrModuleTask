using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class QuestionType
    {
        public int ID { get; set; }
        public Guid publicId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

    }

}
