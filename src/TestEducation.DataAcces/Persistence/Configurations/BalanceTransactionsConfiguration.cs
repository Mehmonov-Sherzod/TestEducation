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
    public class BalanceTransactionsConfiguration : IEntityTypeConfiguration<BalanceTransaction>
    {
        public void Configure(EntityTypeBuilder<BalanceTransaction> builder)
        {
            builder.HasData(
                new BalanceTransaction
                {
                    Id = Guid.Parse("11111118-1111-1111-1111-111111111119"),
                    CardNumber = "9860 3401 0311 6182",
                    UserAdmin = "@Sherzod_3466",
                    FullName = "Mehmonov Sherzod"
                }
                );
        }
    }
}
