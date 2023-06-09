﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework.MSSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonInformationId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Entities.Concrete.AdultAdultChildren", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdultChildrenId")
                        .HasColumnType("int");

                    b.Property<int>("AdultId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AdultAdultChildrens");
                });

            modelBuilder.Entity("Entities.Concrete.EducationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationStatus");
                });

            modelBuilder.Entity("Entities.Concrete.FamilyStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FamilyStatus");
                });

            modelBuilder.Entity("Entities.Concrete.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Entities.Concrete.MarriedStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MarriedStatus");
                });

            modelBuilder.Entity("Entities.Concrete.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Entities.Concrete.PersonGender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PersonGenders");
                });

            modelBuilder.Entity("Entities.Concrete.PersonInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IsAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonGenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PersonInformations");
                });

            modelBuilder.Entity("Entities.Concrete.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionTitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Entities.Concrete.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonInformationId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("Entities.Concrete.QuestionTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionTitleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuestionTitles");
                });

            modelBuilder.Entity("Entities.Concrete.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReligionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Religions");
                });

            modelBuilder.Entity("Entities.Concrete.Telephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonInformationId")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Telephones");
                });

            modelBuilder.Entity("Entities.Concrete.AdultChildren", b =>
                {
                    b.HasBaseType("Entities.Concrete.PersonInformation");

                    b.Property<int>("HowManyChildrens")
                        .HasColumnType("int");

                    b.ToTable("AdultChildrens");
                });

            modelBuilder.Entity("Entities.Concrete.AdultWife", b =>
                {
                    b.HasBaseType("Entities.Concrete.PersonInformation");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WifeId")
                        .HasColumnType("int");

                    b.ToTable("AdultWifes");
                });

            modelBuilder.Entity("Entities.Concrete.ChildrenPerson", b =>
                {
                    b.HasBaseType("Entities.Concrete.PersonInformation");

                    b.Property<int>("ChildrenId")
                        .HasColumnType("int");

                    b.Property<int>("EducationStatusId")
                        .HasColumnType("int");

                    b.Property<int>("FamilyStatusId")
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ChildrenPersons");
                });

            modelBuilder.Entity("Entities.Concrete.ChildrenSiblings", b =>
                {
                    b.HasBaseType("Entities.Concrete.PersonInformation");

                    b.Property<int>("ChildrenId")
                        .HasColumnType("int");

                    b.Property<int>("EducationStatusId")
                        .HasColumnType("int");

                    b.Property<string>("WhichChild")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ChildrenSiblings");
                });

            modelBuilder.Entity("Entities.Concrete.ContactInformation", b =>
                {
                    b.HasBaseType("Entities.Concrete.PersonInformation");

                    b.Property<string>("NationalId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("Entities.Concrete.Adult", b =>
                {
                    b.HasBaseType("Entities.Concrete.ContactInformation");

                    b.Property<int>("EducationStatusId")
                        .HasColumnType("int");

                    b.Property<string>("EthnicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HerHasJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarriedStatusId")
                        .HasColumnType("int");

                    b.Property<string>("ReasonOfApplication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReligionId")
                        .HasColumnType("int");

                    b.Property<string>("WhereIsLiveCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhereIsLiveHerHasDoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoDidSheHeComeWith")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Adults");
                });

            modelBuilder.Entity("Entities.Concrete.Children", b =>
                {
                    b.HasBaseType("Entities.Concrete.ContactInformation");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Childrens");
                });

            modelBuilder.Entity("Entities.Concrete.AdultChildren", b =>
                {
                    b.HasOne("Entities.Concrete.PersonInformation", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.AdultChildren", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.AdultWife", b =>
                {
                    b.HasOne("Entities.Concrete.PersonInformation", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.AdultWife", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.ChildrenPerson", b =>
                {
                    b.HasOne("Entities.Concrete.PersonInformation", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.ChildrenPerson", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.ChildrenSiblings", b =>
                {
                    b.HasOne("Entities.Concrete.PersonInformation", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.ChildrenSiblings", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.ContactInformation", b =>
                {
                    b.HasOne("Entities.Concrete.PersonInformation", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.ContactInformation", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.Adult", b =>
                {
                    b.HasOne("Entities.Concrete.ContactInformation", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Adult", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.Children", b =>
                {
                    b.HasOne("Entities.Concrete.ContactInformation", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Children", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
