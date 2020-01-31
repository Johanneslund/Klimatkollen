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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(

            new User()
            {
                UserId = 1,
                Firstname = "Martin",
                Lastname = "Timell",
                Username = "Bajsmannen",
                Email = "Marreparre@live.se",
                Password = "lllll",
                Phone = "07228321"
            },

            new User()
            {
                UserId = 2,
                Firstname = "Björn",
                Lastname = "Bajs",
                Username = "Bajsmannen12",
                Email = "Marreparre12@live.se",
                Password = "2222",
                Phone = "07228333"
            }

            );
            
            modelBuilder.Entity<Animal>().HasData(

            new Animal()
            {
                AnimalId = 1,
                Name = "Hare",
                Datetime = DateTime.Now,
                Longitude = "63.247951",
                Latitude = "14.662298",
                UserId = 1
            },

            new Animal()
            {
                AnimalId = 2,
                Name = "Fjällräv",
                Datetime = DateTime.Now,
                Longitude = "63.247231",
                Latitude = "14.662298",
                UserId = 1
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
                    Type = "Storsjön, badhusparken",
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
