using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    class PositionQuestionConfiguration : IEntityTypeConfiguration<PositionQuestion>
    {
        public void Configure(EntityTypeBuilder<PositionQuestion> builder)
        {
            builder.ToTable("PositionQuestion");

            builder.HasOne(pq => pq.JobPosition)
                .WithMany(jp => jp.PositionQuestions)
                .HasForeignKey(pq => pq.JobPositionId);

            builder.HasOne(pq => pq.Question)
                .WithMany(q => q.PositionQuestions)
                .HasForeignKey(pq => pq.OuestionId);

            builder.HasData(new PositionQuestion()
            {
                ID = 1,
                JobPositionId = 1,
                OuestionId = 1
            }
       );
        }
    }
}
