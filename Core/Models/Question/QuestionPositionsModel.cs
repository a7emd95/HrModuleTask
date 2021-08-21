using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Question
{
    public class QuestionPositionsModel
    {
        public int QuestionId { get; set; }
        public List<int> PositionsId { get; set; }
    }
}
