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
    public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> builder)
        {
            builder.ToTable("JobPostion");

            builder.Property(jp => jp.PublicID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");


            builder.Property(jp => jp.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(new JobPosition()
            {
                ID = 1,
                Title = "softwear developer",
                IsActive = true
            }
       );
        }
    }
}
