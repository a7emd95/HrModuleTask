using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public class PositionQuestion
    {
        public int ID { get; set; }

        public int OuestionId { get; set; }

        public int JobPositionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual JobPosition JobPosition { get; set; }

    }
}
