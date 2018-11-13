﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaskHouseApi.DatabaseContext;

namespace TaskHouseApi.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TaskHouseApi.Model.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency");

                    b.Property<decimal>("From");

                    b.Property<decimal>("To");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("TaskHouseApi.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TaskHouseApi.Model.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<DateTime>("Start");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("TaskHouseApi.Model.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("PrimaryLine");

                    b.Property<string>("SecondaryLine");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new { Id = -1, City = "City1", Country = "Country1", PrimaryLine = "PrimaryLine1", SecondaryLine = "SecondaryLine1", ZipCode = "ZipCode1" },
                        new { Id = -2, City = "City2", Country = "Country2", PrimaryLine = "PrimaryLine2", SecondaryLine = "SecondaryLine2", ZipCode = "ZipCode2" },
                        new { Id = -3, City = "City3", Country = "Country3", PrimaryLine = "PrimaryLine3", SecondaryLine = "SecondaryLine3", ZipCode = "ZipCode3" }
                    );
                });

            modelBuilder.Entity("TaskHouseApi.Model.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("SendAt");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TaskHouseApi.Model.ServiceModel.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Token");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("TaskHouseApi.Model.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new { Id = -1, Title = "Skill1" },
                        new { Id = -2, Title = "Skill2" },
                        new { Id = -3, Title = "Skill3" }
                    );
                });

            modelBuilder.Entity("TaskHouseApi.Model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.Property<int>("EmployerId");

                    b.Property<DateTime>("Start");

                    b.Property<string>("Urgency");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new { Id = -1, Deadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Task1", EmployerId = -4, Start = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = -2, Deadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Task2", EmployerId = -4, Start = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = -3, Deadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Task3", EmployerId = -5, Start = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = -4, Deadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Task4", EmployerId = -4, Start = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("TaskHouseApi.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("TaskHouseApi.Model.Employer", b =>
                {
                    b.HasBaseType("TaskHouseApi.Model.User");


                    b.ToTable("Employer");

                    b.HasDiscriminator().HasValue("Employer");

                    b.HasData(
                        new { Id = -4, Email = "root@root.com", FirstName = "em1", LastName = "emsen1", Password = "mxurWhuDuXFA6EMY11qsixSbftITzPbpOtBU+Kbdr6Q=", Salt = "HplteyrRxcNz6bOoiZi4Qw==", Username = "em1" },
                        new { Id = -5, Email = "test@test.com", FirstName = "em2", LastName = "emsen2", Password = "+z490sXHo5u0qsSaxbBqEk9KsJtGqNhD8I8mVBdDJls=", Salt = "upYKQSsrlub5JAID61/6pA==", Username = "em2" },
                        new { Id = -6, Email = "test@test.com", FirstName = "em3", LastName = "emsen3", Password = "dpvq1pIWkY9SudflCKrW6tqCItErcBljM1GhNPWlUmg=", Salt = "U+cUJhQU56X+OCiGF9hb1g==", Username = "em3" }
                    );
                });

            modelBuilder.Entity("TaskHouseApi.Model.Worker", b =>
                {
                    b.HasBaseType("TaskHouseApi.Model.User");


                    b.ToTable("Worker");

                    b.HasDiscriminator().HasValue("Worker");

                    b.HasData(
                        new { Id = -1, Email = "root@root.com", FirstName = "Bob", LastName = "Bobsen", Password = "mxurWhuDuXFA6EMY11qsixSbftITzPbpOtBU+Kbdr6Q=", Salt = "HplteyrRxcNz6bOoiZi4Qw==", Username = "root" },
                        new { Id = -2, Email = "test@test.com", FirstName = "Bob1", LastName = "Bobsen1", Password = "+z490sXHo5u0qsSaxbBqEk9KsJtGqNhD8I8mVBdDJls=", Salt = "upYKQSsrlub5JAID61/6pA==", Username = "1234" },
                        new { Id = -3, Email = "test@test.com", FirstName = "Bob3", LastName = "Bobsen3", Password = "dpvq1pIWkY9SudflCKrW6tqCItErcBljM1GhNPWlUmg=", Salt = "U+cUJhQU56X+OCiGF9hb1g==", Username = "hej" }
                    );
                });

            modelBuilder.Entity("TaskHouseApi.Model.ServiceModel.RefreshToken", b =>
                {
                    b.HasOne("TaskHouseApi.Model.User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TaskHouseApi.Model.Task", b =>
                {
                    b.HasOne("TaskHouseApi.Model.Employer")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
