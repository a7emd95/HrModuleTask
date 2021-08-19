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
    class InterviewExamConfiguration : IEntityTypeConfiguration<InterviewExam>
    {
        public void Configure(EntityTypeBuilder<InterviewExam> builder)
        {
            builder.ToTable("InterviewExam");

            builder.HasOne(ie => ie.Candidate)
                .WithMany(c => c.InterviewExams)
                .HasForeignKey(ie => ie.CandidateId);

            builder.Property(ie => ie.PublicId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");
        }
    }
}
