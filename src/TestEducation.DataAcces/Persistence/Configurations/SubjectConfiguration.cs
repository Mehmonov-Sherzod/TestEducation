using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEducation.Data;
using TestEducation.Models;

namespace TestEducation.DataAcces.Persistence.Configurations
{
    
    class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {

            // Subject modelida Name Uniq Boladi
            builder.HasIndex(x=>x.Name)
                .IsUnique();
        }
    }
}
