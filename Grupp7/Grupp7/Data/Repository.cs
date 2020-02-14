using Grupp7.Data;
using Grupp7.Interfaces;
using Grupp7.Models;
using Grupp7.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return context.Animals.Where(x => x.AnimalId.Equals(id)).Include(x => x.Specie).FirstOrDefault();
        }
        public Weather GetWeather(int id)
        {
            return context.Weathers.Where(x => x.WeatherId.Equals(id)).FirstOrDefault();
        }

        public List<Animal> GetNearbyAnimals(string lat, string lng, double radius)
        {
            var userLat = double.Parse(lat.Replace('.', ','));
            var userLng = double.Parse(lng.Replace('.', ','));

            return context.Animals.Where(
                x => double.Parse(x.Latitude.Replace('.', ',')) < userLat + radius &&
                double.Parse(x.Latitude.Replace('.', ',')) > userLat - radius &&
                double.Parse(x.Longitude.Replace('.', ',')) < userLng + radius &&
                double.Parse(x.Longitude.Replace('.', ',')) > userLng - radius).Include(x => x.Specie).Include( x=> x.User)
                .ToList();
        }
        public List<Weather> GetNearbyWeathers(string lat, string lng, double radius)
        {
            var userLat = double.Parse(lat.Replace('.', ','));
            var userLng = double.Parse(lng.Replace('.', ','));

            return context.Weathers.Where(
                x => double.Parse(x.Latitude.Replace('.', ',')) < userLat + radius &&
                double.Parse(x.Latitude.Replace('.', ',')) > userLat - radius &&
                double.Parse(x.Longitude.Replace('.', ',')) < userLng + radius &&
                double.Parse(x.Longitude.Replace('.', ',')) > userLng - radius).Include(x => x.User)
                .ToList();
        }
        public List<Animal> GetNearbyUserAnimals(string lat, string lng, double radius, int userId)
        {
            var userLat = double.Parse(lat.Replace('.', ','));
            var userLng = double.Parse(lng.Replace('.', ','));

            return context.Animals.Where(
                x => double.Parse(x.Latitude.Replace('.', ',')) < userLat + radius &&
                double.Parse(x.Latitude.Replace('.', ',')) > userLat - radius &&
                double.Parse(x.Longitude.Replace('.', ',')) < userLng + radius &&
                double.Parse(x.Longitude.Replace('.', ',')) > userLng - radius && x.UserId == userId).Include(x => x.Specie).Include(x => x.User)
                .ToList();
        }
        public List<Weather> GetNearbyUserWeathers(string lat, string lng, double radius, int userId)
        {
            var userLat = double.Parse(lat.Replace('.', ','));
            var userLng = double.Parse(lng.Replace('.', ','));

            return context.Weathers.Where(
                x => double.Parse(x.Latitude.Replace('.', ',')) < userLat + radius &&
                double.Parse(x.Latitude.Replace('.', ',')) > userLat - radius &&
                double.Parse(x.Longitude.Replace('.', ',')) < userLng + radius &&
                double.Parse(x.Longitude.Replace('.', ',')) > userLng - radius && x.UserId == userId).Include(x => x.User)
                .ToList();
        }
        public void AddUser(UserModel user)
        {
            context.Add(new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Username = user.Username,
                Id = user.Id,
                Longitude = user.Longitude,
                Latitude = user.Latitude,
                City = user.City
            });
            context.SaveChanges();
        }
        public void AddOldUserToDb(User user)
        {
            context.Add(new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Username = user.Username,
                Id = user.Id,
                Longitude = user.Longitude,
                Latitude = user.Latitude,
                City = user.City
            });
            context.SaveChanges();
        }
        public void EditUser(User user)
        {
            User tempUser = GetUser(user.UserId);

            tempUser.Latitude = user.Latitude;
            tempUser.Longitude = user.Longitude;
            tempUser.Username = user.Username;
            tempUser.City = user.City;

            context.Update(tempUser);
            context.SaveChanges();
        }
        public List<Animal> GetAnimals()
        {
            List<Specie> species = GetSpecies();
            List<User> users = GetUsers();
            List<Animal> Animals = new List<Animal>();
            foreach (var animal in context.Animals)
            {
                foreach (var specie in species)
                {
                    if (animal.SpecieId == specie.SpecieId)
                    {
                        animal.Specie = specie;
                        foreach (var user in users)
                        {
                            if (animal.UserId == user.UserId)
                            {
                                animal.User = user;
                                Animals.Add(animal);
                            }
                        }

                    }
                }
            }
            return Animals;
        }
        public void updateAnimal(Animal animal)
        {
            context.Animals.Update(animal);
            context.Entry(animal).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void updateWeather(Weather weather)
        {
            context.Weathers.Update(weather);
            context.Entry(weather).State = EntityState.Modified;
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
            List<User> Users = GetUsers();

            foreach (var weather in context.Weathers)
            {
                foreach (var user in Users)
                {
                    if (weather.UserId == user.UserId)
                    {
                        weather.User = user;
                        Weathers.Add(weather);
                    }
                }

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
            List<Animal> animals = context.Animals.Where(i => i.User.UserId.Equals(id)).ToList();
            List<Specie> species = GetSpecies();
            foreach (var animal in animals)
            {
                foreach (var specie in species)
                {
                    if (animal.SpecieId == specie.SpecieId)
                    {
                        animal.Specie = specie;
                    }
                }
            }

            return animals;
        }
        public List<Weather> getUserWeathers(int id)
        {
            return context.Weathers.Where(i => i.User.UserId.Equals(id)).ToList();
        }

        public List<Specie> GetSpecies()
        {
            List<Specie> Species = new List<Specie>();

            foreach (var specie in context.Species)
            {
                Species.Add(specie);
            }

            return Species;
        }
        public Specie getAnimalSpecie(Animal animal)
        {
            Specie specie = new Specie();
            specie = context.Species.Where(c => c.SpecieId.Equals(animal.SpecieId)).FirstOrDefault();
            return specie;
        }
        public Animal setAnimalSpecie(Animal animal, Specie specie)
        {
            animal.Specie = specie;
            return animal;
        }
        public void getTopListAnimals()
        {
            // context.Animals.GroupBy(userId => userId).OrderByDescending(userId => userId.Count()).Select(g => new { Id = g.Key, Count = g.Count() });
        }

        public List<SelectListItem> getSpeciesItemList()
        {
            List<Specie> specieList = GetSpecies();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var specie in specieList)
            {

                selectList.Add(new SelectListItem { Value = specie.SpecieId.ToString(), Text = specie.Speciename });
            }
            return selectList;
        }
        public void AddAnimalToUser(AddAnimalViewModel model)
        {
            context.Animals.Add(new Animal()
            {
                Coat = model.Animal.Coat,
                SpecieId = model.Animal.SpecieId,
                Latitude = model.Animal.Latitude,
                Longitude = model.Animal.Longitude,
                Datetime = model.Animal.Datetime,
                User = model.User,
                City = model.Animal.City,
                Specie = getSpecieFromSpecieId(model.Animal.SpecieId)
            });
            context.SaveChanges();
        }
        public void AddWeatherToUser(AddWeatherViewModel model)
        {
            context.Weathers.Add(new Weather()
            {
                Carbon = model.Weather.Carbon,
                Datetime = model.Weather.Datetime,
                Humidity = model.Weather.Humidity,
                Latitude = model.Weather.Latitude,
                Longitude = model.Weather.Longitude,
                PH = model.Weather.PH,
                Temperature = model.Weather.Temperature,
                Type = model.Weather.Type,
                User = model.User,
                UserId = model.Weather.UserId
            });
            context.SaveChanges();
        }
        public Specie getSpecieFromSpecieId(int specieId)
        {
            return context.Species.Where(x => x.SpecieId.Equals(specieId)).FirstOrDefault();
        }
        public void ClearCache(User user)
            {
            context.Entry(user).Reload();
            }
        public void RemoveUser(User user)
        {
            context.Remove(user);
        }
    }
}
