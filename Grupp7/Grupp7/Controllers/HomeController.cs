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

namespace Grupp7.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly IRepository dbContext;

        public HomeController(IRepository repository)
        {
            this.dbContext = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
                model.ObservationsList.Add(item);
            }
            foreach (var item in weathers)
            {
                model.ObservationsList.Add(item);
            }
            model.ObservationsList = model.ObservationsList.OrderByDescending(x => x.Datetime).ToList(); 

            return View(model); 
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
      
        public IActionResult AnimalObservation(int id)
        {
            List<Animal> animals = dbContext.GetAnimals();
            
            return View(animals.Where(a => a.AnimalId.Equals(id)).FirstOrDefault());
        }
        public IActionResult EditAnimal(int id)
        {
            List<Animal> animals = dbContext.GetAnimals();
            return View(animals.Where(a => a.AnimalId.Equals(id)).FirstOrDefault());
        }
        public IActionResult EditAnimalFromId(Animal animal)
        {

            dbContext.updateAimal(animal);
            return RedirectToAction("Map");
        }

        public IActionResult Map()
        {
            MapViewModel model = new MapViewModel();
            model.Animals = dbContext.GetAnimals();
            double latSum = 0;
            double longSum = 0;
            foreach (var item in model.Animals)
            { 
                latSum += Convert.ToDouble(item.Latitude.Replace('.', ','));
                longSum += Convert.ToDouble(item.Longitude.Replace('.', ','));
            }
            model.CenterLatitude = (latSum / model.Animals.Count).ToString().Replace(',','.');
            model.CenterLongitude = (longSum / model.Animals.Count).ToString().Replace(',','.');

            return View(model);
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
