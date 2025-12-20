using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestEducation.Models;

namespace TestEducation.DataAcces.Persistence.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasData(
                new User
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111119"),
                    FullName = "Sherzod",
                    Email = "mehmovovsherzod@gmail.com",
                    PhoneNumber = "+901537776",
                    Password = "XeASJOgK7h7Lk0XkPOlOq0LfqTu9bA93NrmMHnm3/mY=",
                    Salt = "8a68becd-d900-4835-b809-d728ac097656",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 11, 14, 14, 31, 0, DateTimeKind.Utc),
                    IsVerified = false,
                    Count = 0,
                    ExpiredAt = null,
                }
            );

        }

    }
}
