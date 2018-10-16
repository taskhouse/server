﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaskHouseApi.DatabaseContext;

namespace TaskHouseApi.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20181016142956_budgets")]
    partial class budgets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TaskHouseApi.Model.Budget", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency");

                    b.Property<decimal>("From");

                    b.Property<decimal>("To");

                    b.HasKey("ID");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("TaskHouseApi.Model.Task", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Start");

                    b.Property<string>("Urgency");

                    b.HasKey("ID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskHouseApi.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}