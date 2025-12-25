using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Domain.Entities;

namespace TestEducation.DataAcces.Persistence.Configurations
{
    public class TestProcessConfiguration : IEntityTypeConfiguration<TestEducation.Domain.Entities.TestProcess>
    {
        public void Configure(EntityTypeBuilder<TestEducation.Domain.Entities.TestProcess> builder)
        {
            builder.ToTable("TestProcesses");
            builder.HasKey(tp => tp.Id);

            builder.Property(tp => tp.StartedAt)
                        .IsRequired();
            builder.Property(tp => tp.EndsAt)
                        .IsRequired();
            builder.Property(tp => tp.TotalQuestions)
                        .HasDefaultValue(0);
            builder.Property(tp => tp.TotalScore)
                        .HasDefaultValue(0);


            builder.HasMany(tp => tp.UserQuestions)
                    .WithOne(uq => uq.TestProcess)
                        .HasForeignKey(uq => uq.TestProcessId)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
