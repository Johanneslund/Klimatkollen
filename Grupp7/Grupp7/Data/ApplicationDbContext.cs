using Grupp7.Classes;
using Grupp7.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(

            new User()
            {
                UserId = 1,
                Firstname = "Johannes",
                Lastname = "Lundkvist",
                Username = "Jossieri",
                Id = "21a529ea-f6fd-4f35-ae77-afc54aa83fe5",
                Latitude = "16.321",
                Longitude = "56.321",
                City = "Östersund"
            },

            new User()
            {
                UserId = 2,
                Firstname = "Björn",
                Lastname = "Bertilsson",
                Username = "BB",
                Id = "c85d4906-25ec-4e8d-9ebd-9f4b74b506f0",
                Latitude = "16.321",
                Longitude = "56.321",
                City = "Östersund"
            }

            );

            modelBuilder.Entity<Specie>().HasData(

            new Specie()
            {
                SpecieId = 1,
                Speciename = "Hare"
            },
            new Specie()
            {
                SpecieId = 2,
                Speciename = "Fjällräv"
            },
            new Specie()
            {
                SpecieId = 3,
                Speciename = "Ripa"
            },
            new Specie()
            {
                SpecieId = 4,
                Speciename = "Vildsvin"
            },
            new Specie()
            {
                SpecieId = 5,
                Speciename = "Groda"
            }

            );

            modelBuilder.Entity<Animal>().HasData(

            new Animal()
            {
                AnimalId = 1,
                Datetime = DateTime.Now,
                Longitude = "14.662298",
                Latitude = "63.247951",
                Coat = "Vinter",
                UserId = 1,
                SpecieId = 1
            },

            new Animal()
            {
                AnimalId = 2,
                Datetime = DateTime.Now,
                Longitude = "14.6298",
                Latitude = "63.247",
                Coat = "Vinter",
                UserId = 1,
                SpecieId = 2
            },

            new Animal()
            {
                AnimalId = 3,
                Datetime = DateTime.Now,
                Longitude = "14.6653",
                Latitude = "63.247222",
                Coat = "Vinter",
                UserId = 2,
                SpecieId = 3
            }

            );

            modelBuilder.Entity<Weather>().HasData(

                new Weather()
                {
                    WeatherId = 1,
                    Type = "Regn",
                    Datetime = DateTime.Now,
                    Longitude = "63.247231",
                    Latitude = "14.662298",
                    Humidity = "87,2",
                    UserId = 2,
                    Temperature = "22"
                },
                new Weather()
                {
                    WeatherId = 2,
                    Type = "Storsjön",
                    Datetime = DateTime.Now,
                    Longitude = "63.247231",
                    Latitude = "14.662298",
                    Humidity = "87,2",
                    Temperature = "16",
                    Carbon = "10 mg",
                    UserId = 2
                }
                );
                modelBuilder.Entity<Equipment>().HasData(

                new Equipment()
                {
                    Id = 1,
                    Type = "Vindmätare",
                    IsAvaliable = true
                },
                new Equipment()
                {
                    Id = 2,
                    Type = "Vindmätare",
                    IsAvaliable = true
                },
                new Equipment()
                {
                    Id = 3,
                    Type = "Vindmätare",
                    IsAvaliable = true
                }
                );
        }

    }
}
