using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.MSSQL.Context
{
   public class SqlContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = Chiron; Trusted_Connection = true");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonInformation> PersonInformations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<PersonGender> PersonGenders { get; set; }
        public DbSet<EducationStatus> EducationStatus { get; set; }
        public DbSet<Children> Childrens { get; set; }
        public DbSet<FamilyStatus> FamilyStatus { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ChildrenPerson> ChildrenPersons { get; set; }




    }
}
