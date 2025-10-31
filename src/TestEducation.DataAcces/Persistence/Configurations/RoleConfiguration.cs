using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEducation.Models;

namespace TestEducation.DataAcces.Persistence.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
               new Role { Id = 1, Name = "SuperAdmin", Description = "Barcha tizimni boshqaradigan SuperAdmin rol" },
               new Role { Id = 2, Name = "Admin", Description = "faqat student va creatordi boshqaradigan admin rol" },
               new Role { Id = 3, Name = "Student", Description = "Test yechish va natija ko‘rish" },
               new Role { Id = 4, Name = "Creator", Description = "Test yaratish va tahrirlash" }
               );
        }
    }
}
