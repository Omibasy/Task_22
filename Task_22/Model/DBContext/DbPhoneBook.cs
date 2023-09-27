using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using Task_22.AuthPersonApp;
using Task_22.Model.Data;

namespace Task_22.Model.DBContext
{
    public class DbPhoneBook : IdentityDbContext<User>
    {
        public DbPhoneBook(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonalData> PersonalDatas { get; set; }


    }
}
