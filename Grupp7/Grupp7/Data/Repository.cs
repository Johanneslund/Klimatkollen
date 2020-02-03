using Grupp7.Data;
using Grupp7.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    //Detta är den skarpa databasen
    public class Repository : IRepository
    {
        private ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User GetUser(int id) 
        {
            return context.Users.Where(x => x.UserId == id).FirstOrDefault();
        }
        public Animal getAnimal(int id)
        {
            return context.Animals.Where(x => x.AnimalId.Equals(id)).FirstOrDefault();
        }

        public void  AddUser(string firstname, string lastname, string id, string username)
        {
            context.Add(new User()
            {
                Firstname = firstname,
                Lastname = lastname,
                Username = username,
                Id = id
            });
            context.SaveChanges();
        }
        public List<Animal> GetAnimals()
        {
            List<Animal> Animals = new List<Animal>();

            foreach (var animal in context.Animals)
            {
                Animals.Add(animal);
                
            }
            return Animals;
        }
        public void updateAimal(Animal animal)
        {
            context.Animals.Update(animal);
            context.Entry(animal).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<User> GetUsers() 
        {
            List<User> Users = new List<User>();
            foreach (var user in context.Users)
            {
                Users.Add(user);
            }
            return Users;
        }

        public List<Weather> GetWeathers()
        {
            List<Weather> Weathers = new List<Weather>();

            foreach (var Weather in context.Weathers)
            {
                Weathers.Add(Weather);

            }
            return Weathers;
        }

        public void Save(User user)
        {

        }

        public User GetUserFromIdentity(string id)
        {
            return context.Users.Where(u => u.Id.Equals(id)).FirstOrDefault();
        }
        public List<Animal> getUserAnimals(int id)
        {
            return context.Animals.Where(i => i.User.UserId.Equals(id)).ToList();
        }
        public List<Weather> getUserWeathers(int id)
        {
            return context.Weathers.Where(i => i.User.UserId.Equals(id)).ToList();
        }
    }
}
