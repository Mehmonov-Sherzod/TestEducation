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
               new Role { Id = Guid.Parse("00000011-0000-0000-0000-000000000001"), Name = "SuperAdmin", Description = "Barcha tizimni boshqaradigan SuperAdmin rol" },
               new Role { Id = Guid.Parse("00000012-0000-0000-0000-000000000001"), Name = "Admin", Description = "faqat student ustidan barcha ishlat test , subject , question yaratishlar" },
               new Role { Id = Guid.Parse("00000013-0000-0000-0000-000000000001"), Name = "Student", Description = "Test yechish va natija ko‘rish" }
               );
        }
    }
}
