﻿// <auto-generated />
using System;
using Grupp7.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Grupp7.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200128131225_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Grupp7.Classes.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datetime");

                    b.Property<int>("Latitude");

                    b.Property<int>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("AnimalId");

                    b.HasIndex("UserId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Grupp7.Classes.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserId = 1, Email = "Marreparre@live.se", Firstname = "Martin", Lastname = "Timell", Password = "lllll", Phone = "07228321", Username = "Bajsmannen" },
                        new { UserId = 2, Email = "Marreparre12@live.se", Firstname = "Björn", Lastname = "Bajs", Password = "2222", Phone = "07228333", Username = "Bajsmannen12" }
                    );
                });

            modelBuilder.Entity("Grupp7.Classes.Weather", b =>
                {
                    b.Property<int>("WeatherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Carbon");

                    b.Property<DateTime>("Datetime");

                    b.Property<int>("Humidity");

                    b.Property<int>("Latitude");

                    b.Property<int>("Longitude");

                    b.Property<int>("PH");

                    b.Property<int>("Temperature");

                    b.Property<string>("Type");

                    b.Property<int?>("UserId");

                    b.HasKey("WeatherId");

                    b.HasIndex("UserId");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("Grupp7.Classes.Animal", b =>
                {
                    b.HasOne("Grupp7.Classes.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Grupp7.Classes.Weather", b =>
                {
                    b.HasOne("Grupp7.Classes.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
