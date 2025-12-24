using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEducation.Domain.Entities;
using TestEducation.Models;

namespace TestEducation.DataAcces.Persistence.Configurations
{
    internal class UserBalanceConfiguration : IEntityTypeConfiguration<UserBalance>
    {
        public void Configure(EntityTypeBuilder<UserBalance> builder)
        {
            builder.HasData(
                new UserBalance
                {
                    Id = Guid.Parse("11111112-1111-1111-1111-111111111119"),
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111119"),
                    Amout = 9999999999,
                    BalanceCode = "675983410",
                }
                );
        }
    }
}
