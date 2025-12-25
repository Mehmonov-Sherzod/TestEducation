using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Models;

namespace TestEducation.DataAcces.Persistence.Configurations
{
    public class UserQuestionConfiguration : IEntityTypeConfiguration<UserQuestion>
    {
        public void Configure(EntityTypeBuilder<UserQuestion> builder)
        {
            
                          builder.HasOne(uq => uq.TestProcess)
                                 .WithMany(tp => tp.UserQuestions)
                                 .HasForeignKey(uq => uq.TestProcessId);
        }
    }
}
