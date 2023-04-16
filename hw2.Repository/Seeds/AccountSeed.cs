using hw2.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2.Repository.Seeds
{
    internal class AccountSeed : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.HasData(
                new Account() { Id = 1, Role = "admin", Email = "admin@gmail.com", UserName = "admin", Name = "Yunus", Password = "1234", CreatedDate = DateTime.Now },
                new Account() { Id = 2, Role = "viewer", Email = "viewer@gmail.com", UserName = "viwer", Name = "Emre", Password = "1234", CreatedDate = DateTime.Now }
                );

        }
    }
}
