using Api_Task_22.AuthPersonApp;
using Api_Task_22.Model.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api_Task_22.Model.DBC
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
