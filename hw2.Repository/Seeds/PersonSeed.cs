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
    internal class PersonSeed : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.HasData(
                new Person() { Id = 1, AccountId = 1, FirstName = "Yunus Emre", LastName = "Savan", Email = "emre@gmail.com", Description = "Admin Accouunt'a bağlı person 1 ", CreatedDate = DateTime.Now, Phone = "1234567", DateOfBirth = DateTime.Now, UpdatedDate = DateTime.Now },
                new Person() { Id = 2, AccountId = 1, FirstName = "Hasan", LastName = "Savan", Email = "hasan@gmail.com", Description = "Admin Accouunt'a bağlı person 2 ", CreatedDate = DateTime.Now, Phone = "213123", DateOfBirth = DateTime.Now, UpdatedDate = DateTime.Now },
                new Person() { Id = 3, AccountId = 2, FirstName = "Kerem", LastName = "Savan", Email = "kerem@gmail.com", Description = "Viewer Accouunt'a bağlı person 1 ", CreatedDate = DateTime.Now, Phone = "64745", DateOfBirth = DateTime.Now, UpdatedDate = DateTime.Now },
                new Person() { Id = 4, AccountId = 2, FirstName = "Cihangir", LastName = "Savan", Email = "cihangir@gmail.com", Description = "Viewer Accouunt'a bağlı person 2 ", CreatedDate = DateTime.Now, Phone = "12345435436467", DateOfBirth = DateTime.Now, UpdatedDate = DateTime.Now }
                );


        }
    }
}
