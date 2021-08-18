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
    class CandidatePositionConfiguration : IEntityTypeConfiguration<CandidatePosition>
    {
        public void Configure(EntityTypeBuilder<CandidatePosition> builder)
        {
            builder.ToTable("CandidatePosition");

            builder.HasOne(cp => cp.Candidate)
                .WithMany(c => c.CandidatePositions)
                .HasForeignKey(cp => cp.CandidateId);

            builder.HasOne(cp => cp.JobPosition)
                .WithMany(jp => jp.CandidatePositions)
                .HasForeignKey(cp => cp.JobPositionId);
        }
    }
}
