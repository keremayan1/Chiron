using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PersonInformation>().ToTable("PersonInformations");
            modelBuilder.Entity<Children>().ToTable("Childrens");
            modelBuilder.Entity<ChildrenPerson>().ToTable("ChildrenPersons");
            modelBuilder.Entity<Adult>().ToTable("Adults");
            modelBuilder.Entity<AdultWife>().ToTable("AdultWifes");
            modelBuilder.Entity<AdultChildren>().ToTable("AdultChildrens");
            modelBuilder.Entity<ContactInformation>().ToTable("ContactInformations");
            modelBuilder.Entity<ChildrenSiblings>().ToTable("ChildrenSiblings");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonInformation> PersonInformations { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<PersonGender> PersonGenders { get; set; }
        public DbSet<EducationStatus> EducationStatus { get; set; }
        public DbSet<Children> Childrens { get; set; }
        public DbSet<FamilyStatus> FamilyStatus { get; set; }
      
        public DbSet<ChildrenPerson> ChildrenPersons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTitle> QuestionTitles { get; set; }
        public DbSet<QuestionAnswer>     QuestionAnswers { get; set; }
        public DbSet<MarriedStatus> MarriedStatus { get; set; }
        public DbSet<Adult> Adults { get; set; }
       public DbSet<Religion> Religions { get; set; }
       public DbSet<AdultWife> AdultWifes { get; set; }
       public DbSet<AdultChildren> AdultChildrens { get; set; }
       public DbSet<ContactInformation> ContactInformations { get; set; }
       public DbSet<ChildrenSiblings> ChildrenSiblings { get; set; }
       public DbSet<AdultAdultChildren> AdultAdultChildrens { get; set; }







    }
}
