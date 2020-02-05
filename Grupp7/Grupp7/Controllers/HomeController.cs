using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grupp7.Models;
using Grupp7.Interfaces;
using Grupp7.Classes;
using Grupp7.Data;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Grupp7.ViewModels;
using System.Security.Claims;
using Grupp7.Helpers;

namespace Grupp7.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly IRepository dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(IRepository repository, UserManager<IdentityUser> userManager)
        {
            this.dbContext = repository;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddUserFromRegister(string firstname, string lastname, string id, string username)
        {
            dbContext.AddUser(firstname, lastname, id, username);
            return RedirectToAction("Index");
        }

        public IActionResult Observation()
        {
            //gets all observations in 2 lists.
            ObservationViewModel model = new ObservationViewModel();
            List<Animal> animals = new List<Animal>();
            List<Weather> weathers = new List<Weather>();
            animals = dbContext.GetAnimals();
            weathers = dbContext.GetWeathers();
           // model.UserList = dbContext.GetUsers();
            //model.AnimalList = model.AnimalList.OrderByDescending(x => x.Datetime).ToList();
            //model.WeatherList = model.WeatherList.OrderByDescending(x => x.Datetime).ToList();          

            model.ObservationsList = new List<Observation>(); 
            foreach ( var item in animals)
            {
                model.ObservationsList.Add(new Observation {Animal = item , Datetime = item.Datetime});

            }
            foreach (var item in weathers)
            {
                model.ObservationsList.Add(new Observation { Weather = item , Datetime = item.Datetime });
            }
            model.ObservationsList = model.ObservationsList.OrderByDescending(x => x.Datetime).ToList(); 

            return View(model); 
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult AddAnimal()
        {
            AddAnimalViewModel model = new AddAnimalViewModel();
            model.Animal = new Animal();
            model.Species = dbContext.getSpeciesItemList();

            return View(model);
        }
        public IActionResult AddAnimalToUser(AddAnimalViewModel model)
        {
            AddAnimalViewModel Model = model;
            Model.User = dbContext.GetUserFromIdentity(userManager.GetUserId(HttpContext.User));
            dbContext.AddAnimalToUser(model);
            return RedirectToAction("UserHome");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
      
        public IActionResult AnimalObservation(int id)
        {
            Animal animal = dbContext.getAnimal(id);
            Specie specie = dbContext.getAnimalSpecie(animal);
            
            return View(dbContext.setAnimalSpecie(animal,specie));
        }
        public IActionResult EditAnimal(int id)
        {
            Animal animal = dbContext.getAnimal(id);
            Specie specie = dbContext.getAnimalSpecie(animal);

            return View(dbContext.setAnimalSpecie(animal, specie));
        }
        public IActionResult EditAnimalFromId(Animal animal)
        {

            dbContext.updateAimal(animal);
            return RedirectToAction("Map");
        }

        public IActionResult UserHome()
        {
            UserHomeViewModel model = new UserHomeViewModel();
            var userId = userManager.GetUserId(HttpContext.User);
            model.User = dbContext.GetUserFromIdentity(userId);
            model.Animals = dbContext.getUserAnimals(model.User.UserId);
            model.Weathers = dbContext.getUserWeathers(model.User.UserId);


            return View(model);
        }
        public IActionResult Map()
        {
            MapViewModel model = new MapViewModel();
            model.Animals = dbContext.GetAnimals();

            return View(Helper.getCentralPosition(model));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
