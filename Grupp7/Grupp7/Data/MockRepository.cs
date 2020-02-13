using Grupp7.Interfaces;
using Grupp7.Models;
using Grupp7.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    //Detta är hårdkodad testdata
    public class MockRepository : IRepository
    {

        private List<User> users = new List<User>();

        public MockRepository()
        {
            User user = new User()
            {
                UserId = 1,
                Firstname = "Martin",
                Lastname = "Timell",
                Username = "Bajsmannen",

            };
            users.Add(user);
        }

        public User GetUser(int id)
        {
            return users.Where(x => x.UserId.Equals(id)).FirstOrDefault();

        }


        public List<User> GetUsers() //  => users
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetAnimals()
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }

        public Animal getAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public void updateAimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public List<Weather> GetWeathers()
        {
            throw new NotImplementedException();
        }

        public User GetUserFromIdentity(string id)
        {
            throw new NotImplementedException();
        }
        public List<Animal> getUserAnimals(int id)
        {
            throw new NotImplementedException();
        }
        public List<Weather> getUserWeathers(int id)
        {
            throw new NotImplementedException();
        }

        public List<Specie> GetSpecies()
        {
            throw new NotImplementedException();
        }

        public Specie getAnimalSpecie(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Animal setAnimalSpecie(Animal animal, Specie specie)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> getSpeciesItemList()
        {
            throw new NotImplementedException();
        }

        public void AddAnimalToUser(AddAnimalViewModel model)
        {
            throw new NotImplementedException();
        }

        public Weather GetWeather(int id)
        {
            throw new NotImplementedException();
        }

        public void AddUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetNearbyAnimals(string lat, string lng, double radius)
        {
            throw new NotImplementedException();
        }

        public List<Weather> GetNearbyWeathers(string lat, string lng, double radius)
        {
            throw new NotImplementedException();
        }

        public void AddWeatherToUser(AddWeatherViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
