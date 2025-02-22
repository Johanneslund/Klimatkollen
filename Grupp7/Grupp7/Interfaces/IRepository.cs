﻿using Grupp7.Classes;
using Grupp7.Models;
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
        void AddUser(UserModel user);
        List<Animal> GetAnimals();
        Animal getAnimal(int id);
        void updateAnimal(Animal animal);
        void updateWeather(Weather weather);
        List<Animal> getUserAnimals(int id);
        List<Weather> getUserWeathers(int id);
        Weather GetWeather(int id);

        List<Weather> GetWeathers();
        List<Specie> GetSpecies();
        List<SelectListItem> getSpeciesItemList();
        Specie getAnimalSpecie(Animal animal);
        Animal setAnimalSpecie(Animal animal, Specie specie);
        void AddAnimalToUser(AddAnimalViewModel model);
        List<Animal> GetNearbyAnimals(string lat, string lng, double radius);
        List<Weather> GetNearbyWeathers(string lat, string lng, double radius);
        List<Animal> GetNearbyUserAnimals(string lat, string lng, double radius, int userId);
        List<Weather> GetNearbyUserWeathers(string lat, string lng, double radius, int userId);

        void AddWeatherToUser(AddWeatherViewModel model);
        void AddOldUserToDb(User user);
        void ClearCache(User user);
        void RemoveUser(User user);
        void EditUser(User user);
    }
}
