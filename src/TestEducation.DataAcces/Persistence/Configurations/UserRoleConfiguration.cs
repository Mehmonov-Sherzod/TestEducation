using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEducation.Models;

namespace TestEducation.DataAcces.Persistence.Configurations
{
    class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole { UserId = Guid.Parse("11111111-1111-1111-1111-111111111119"),
                               RoleId = Guid.Parse("00000011-0000-0000-0000-000000000001"),
                              }
                   );
        }
    }
}
