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
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidate");

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired();

            builder.HasData(new Candidate()
            {
                ID = 1,
                Name = "ahmed",
                Email = "ahmed@gmail.com"
            }
            );

        }
    }
}
