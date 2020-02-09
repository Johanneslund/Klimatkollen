using Grupp7.Classes;
using Grupp7.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Interfaces
{
    public interface IRepository
    {
        User GetUser(int id);
        User GetUserFromIdentity(string id);
        void Save(User user);
        List<User> GetUsers();
        void AddUser(string firstname, string lastname, string id, string username);

        List<Animal> GetAnimals();
        Animal getAnimal(int id);
        void updateAimal(Animal animal);
        List<Animal> getUserAnimals(int id);
        List<Weather> getUserWeathers(int id);
        Weather GetWeather(int id);

        List<Weather> GetWeathers();

        List<Specie> GetSpecies();
        List<SelectListItem> getSpeciesItemList();
        Specie getAnimalSpecie(Animal animal);
        Animal setAnimalSpecie(Animal animal, Specie specie);
        void AddAnimalToUser(AddAnimalViewModel model);
    }
}
