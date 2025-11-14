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

            //builder.HasData(
            //    new User
            //    {
            //        Id = 1,
            //        FullName = "Sherzod",
            //        Email = "mehmovovsherzod@gmail.com",
            //        PhoneNumber = "+998901537776",
            //        Password = "",
            //        Salt = "",
            //        IsActive = true,
            //        CreatedAt = DateTime.UtcNow,
            //        IsVerified = false,
            //        Count = 0,
            //        ExpiredAt = default,
            //    }
            //);

        }

    }
}
