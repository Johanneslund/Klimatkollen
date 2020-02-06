using Grupp7.Data;
using Grupp7.Interfaces;
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
            return context.Animals.Where(x => x.AnimalId.Equals(id)).FirstOrDefault();
        }

        public void AddUser(string firstname, string lastname, string id, string username)
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
                    if(animal.SpecieId == specie.SpecieId)
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
            Animal animal = new Animal()
            {
                Coat = model.Animal.Coat,
                SpecieId = model.Animal.SpecieId,
                Latitude = model.Animal.Latitude,
                Longitude = model.Animal.Longitude,
                Datetime = model.Animal.Datetime,
                User = model.User
            };
            setAnimalSpecie(animal, getAnimalSpecie(animal));
            context.Add(animal);
            context.SaveChanges();
        }

        public IEnumerable<Specie> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Species;
            }
            return context.Species.Where(a => a.Speciename.Contains(searchTerm));
        }
    }
}
