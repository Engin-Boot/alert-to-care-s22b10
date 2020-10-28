﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Diagnostics.CodeAnalysis;
using DbContext = AlertToCare.Repository.DbContext;

namespace AlertToCare.Migrations
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(DbContext))]
    partial class PatientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AlertToCare.Models.PatientDataModel", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("PatientName")
                        .HasColumnType("text");

                    b.HasKey("PatientId");

                    b.ToTable("TodoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
