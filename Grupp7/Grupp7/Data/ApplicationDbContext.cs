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


        }

    }
}
