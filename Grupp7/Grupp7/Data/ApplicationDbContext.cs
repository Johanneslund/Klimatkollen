using Grupp7.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(

            new User()
            {
                UserId = 1,
                Firstname = "Martin",
                Lastname = "Timell",
                Username = "MT",
                Email = "Marreparre@live.se",
                Password = "llll",
                Phone = "0724445522"
            },

            new User()
            {
                UserId = 2,
                Firstname = "Björn",
                Lastname = "Bertilsson",
                Username = "BB",
                Email = "Björne@live.se",
                Password = "2222",
                Phone = "07212312344"
            }

            );

            modelBuilder.Entity<Species>().HasData(

            new Species()
            {
                SpeciesId = 1,
                Speciesname = "Hare"
            },
            new Species()
            {
                SpeciesId = 2,
                Speciesname = "Fjällräv"
            },
            new Species()
            {
                SpeciesId = 3,
                Speciesname = "Ripa"
            },
            new Species()
            {
                SpeciesId = 4,
                Speciesname = "Vildsvin"
            },
            new Species()
            {
                SpeciesId = 5,
                Speciesname = "Groda"
            }

            );

            modelBuilder.Entity<Animal>().HasData(

            new Animal()
            {
                AnimalId = 1,
                Datetime = DateTime.Now,
                Longitude = "63.247951",
                Latitude = "14.662298",
                UserId = 1,
                SpeciesId = 1
            },

            new Animal()
            {
                AnimalId = 2,
                Datetime = DateTime.Now,
                Longitude = "63.247231",
                Latitude = "14.662298",
                UserId = 1,
                SpeciesId = 2
            },

            new Animal()
            {
                AnimalId = 3,
                Datetime = DateTime.Now,
                Longitude = "63.119802",
                Latitude = "14.445399",
                Coat = "Vinter",
                UserId = 2,
                SpeciesId = 3
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
                    UserId = 2
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
        }

    }
}
