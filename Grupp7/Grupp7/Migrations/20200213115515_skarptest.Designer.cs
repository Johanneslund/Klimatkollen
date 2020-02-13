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
    [Migration("20200213115515_skarptest")]
    partial class skarptest
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

                    b.Property<string>("City")
                        .HasMaxLength(128);

                    b.Property<string>("Coat")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<DateTime>("Datetime");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("SpecieId");

                    b.Property<int>("UserId");

                    b.HasKey("AnimalId");

                    b.HasIndex("SpecieId");

                    b.HasIndex("UserId");

                    b.ToTable("Animals");

                    b.HasData(
                        new { AnimalId = 1, Coat = "Vinter", Datetime = new DateTime(2020, 2, 13, 12, 55, 14, 766, DateTimeKind.Local), Latitude = "14.662298", Longitude = "63.247951", SpecieId = 1, UserId = 1 },
                        new { AnimalId = 2, Coat = "Vinter", Datetime = new DateTime(2020, 2, 13, 12, 55, 14, 768, DateTimeKind.Local), Latitude = "14.662298", Longitude = "63.247231", SpecieId = 2, UserId = 1 },
                        new { AnimalId = 3, Coat = "Vinter", Datetime = new DateTime(2020, 2, 13, 12, 55, 14, 768, DateTimeKind.Local), Latitude = "14.445399", Longitude = "63.119802", SpecieId = 3, UserId = 2 }
                    );
                });

            modelBuilder.Entity("Grupp7.Classes.Specie", b =>
                {
                    b.Property<int>("SpecieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Speciename");

                    b.HasKey("SpecieId");

                    b.ToTable("Species");

                    b.HasData(
                        new { SpecieId = 1, Speciename = "Hare" },
                        new { SpecieId = 2, Speciename = "Fjällräv" },
                        new { SpecieId = 3, Speciename = "Ripa" },
                        new { SpecieId = 4, Speciename = "Vildsvin" },
                        new { SpecieId = 5, Speciename = "Groda" }
                    );
                });

            modelBuilder.Entity("Grupp7.Classes.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Id");

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Latitude")
                        .IsRequired();

                    b.Property<string>("Longitude")
                        .IsRequired();

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserId = 1, City = "Östersund", Firstname = "Johannes", Id = "21a529ea-f6fd-4f35-ae77-afc54aa83fe5", Lastname = "Lundkvist", Latitude = "16.321", Longitude = "56.321", Username = "Jossieri" },
                        new { UserId = 2, City = "Östersund", Firstname = "Björn", Id = "c85d4906-25ec-4e8d-9ebd-9f4b74b506f0", Lastname = "Bertilsson", Latitude = "16.321", Longitude = "56.321", Username = "BB" }
                    );
                });

            modelBuilder.Entity("Grupp7.Classes.Weather", b =>
                {
                    b.Property<int>("WeatherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Carbon");

                    b.Property<string>("City");

                    b.Property<DateTime>("Datetime");

                    b.Property<string>("Humidity");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("PH");

                    b.Property<string>("Temperature")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("UserId");

                    b.HasKey("WeatherId");

                    b.HasIndex("UserId");

                    b.ToTable("Weathers");

                    b.HasData(
                        new { WeatherId = 1, Datetime = new DateTime(2020, 2, 13, 12, 55, 14, 768, DateTimeKind.Local), Humidity = "87,2", Latitude = "14.662298", Longitude = "63.247231", Temperature = "22", Type = "Regn", UserId = 2 },
                        new { WeatherId = 2, Carbon = "10 mg", Datetime = new DateTime(2020, 2, 13, 12, 55, 14, 768, DateTimeKind.Local), Humidity = "87,2", Latitude = "14.662298", Longitude = "63.247231", Temperature = "16", Type = "Storsjön", UserId = 2 }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Grupp7.Classes.Animal", b =>
                {
                    b.HasOne("Grupp7.Classes.Specie", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieId")
                        .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
