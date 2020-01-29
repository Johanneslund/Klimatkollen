﻿// <auto-generated />
using System;
using Grupp7.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Grupp7.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("AnimalId");

                    b.HasIndex("UserId");

                    b.ToTable("Animals");

                    b.HasData(
                        new { AnimalId = 1, Datetime = new DateTime(2020, 1, 29, 10, 56, 4, 637, DateTimeKind.Local), Latitude = "14.662298", Longitude = "63.247951", Name = "Hare", UserId = 1 },
                        new { AnimalId = 2, Datetime = new DateTime(2020, 1, 29, 10, 56, 4, 638, DateTimeKind.Local), Latitude = "14.662298", Longitude = "63.247231", Name = "Fjällräv", UserId = 1 }
                    );
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

                    b.Property<string>("Carbon");

                    b.Property<DateTime>("Datetime");

                    b.Property<string>("Humidity");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("PH");

                    b.Property<string>("Temperature");

                    b.Property<string>("Type");

                    b.Property<int>("UserId");

                    b.HasKey("WeatherId");

                    b.HasIndex("UserId");

                    b.ToTable("Weathers");

                    b.HasData(
                        new { WeatherId = 1, Datetime = new DateTime(2020, 1, 29, 10, 56, 4, 639, DateTimeKind.Local), Humidity = "87,2", Latitude = "14.662298", Longitude = "63.247231", Type = "Regn", UserId = 2 },
                        new { WeatherId = 2, Carbon = "10 mg", Datetime = new DateTime(2020, 1, 29, 10, 56, 4, 639, DateTimeKind.Local), Humidity = "87,2", Latitude = "14.662298", Longitude = "63.247231", Temperature = "16", Type = "Storsjön, badhusparken", UserId = 2 }
                    );
                });

            modelBuilder.Entity("Grupp7.Classes.Animal", b =>
                {
                    b.HasOne("Grupp7.Classes.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grupp7.Classes.Weather", b =>
                {
                    b.HasOne("Grupp7.Classes.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
