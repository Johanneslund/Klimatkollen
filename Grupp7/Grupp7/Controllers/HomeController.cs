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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;

namespace Grupp7.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository dbContext;
        private readonly UserManager<IdentityUser> userManager;

        // The observations page with search functionality. 
        public object Observations(string searchTerm, string observationType)
        {
            ObservationViewModel model = new ObservationViewModel();
            Animal animal = new Animal();
            Weather weather = new Weather();
            List<Animal> animals = new List<Animal>();
            List<Weather> weathers = new List<Weather>();
            //var users = userManager.Users;
            animals = dbContext.GetAnimals();
            weathers = dbContext.GetWeathers();
            model.ObservationsList = new List<Observation>();

            // Selected List dropdown
            model.ObservationTypes = new List<SelectListItem>
            {
                new SelectListItem {Text = "Animal", Value = "1"},
                new SelectListItem {Text = "Weather", Value = "2"}
            };

            // Populate ObservationsList with Animals and Weathers based on conditions
            if (!string.IsNullOrEmpty(searchTerm) && observationType == "1")
            {
                foreach (var item in animals)
                {
                    model.ObservationsList.Add(new Observation { Animal = item, Datetime = item.Datetime });
                }
                model.ObservationsList = model.ObservationsList.Where(x => x.Animal.Specie.Speciename.Contains(searchTerm)).ToList();
            }
            else if (string.IsNullOrEmpty(searchTerm) && observationType == "1")
            {
                foreach (var item in animals)
                {
                    model.ObservationsList.Add(new Observation { Animal = item, Datetime = item.Datetime });
                }
                model.ObservationsList = model.ObservationsList.OrderBy(o => o.Datetime).ToList();
            }
            else if (!string.IsNullOrEmpty(searchTerm) && observationType == "2")
            {
                foreach (var item in weathers)
                {
                    model.ObservationsList.Add(new Observation { Weather = item, Datetime = item.Datetime });
                }
                model.ObservationsList = model.ObservationsList.Where(x => x.Weather.Type.Contains(searchTerm)).ToList();
            }
            else if (string.IsNullOrEmpty(searchTerm) && observationType == "2")
            {
                foreach (var item in weathers)
                {
                    model.ObservationsList.Add(new Observation { Weather = item, Datetime = item.Datetime });
                }
                model.ObservationsList = model.ObservationsList.OrderBy(o => o.Datetime).ToList();
            }
            else
            {
                foreach (var item in animals)
                {
                    model.ObservationsList.Add(new Observation { Animal = item, Datetime = item.Datetime });
                }
                foreach (var item in weathers)
                {
                    model.ObservationsList.Add(new Observation { Weather = item, Datetime = item.Datetime });
                }
            }
            Helper.getCentralPosition(model);
            return model;
        }


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
        public IActionResult AddUserFromRegister(UserModel user)
        {
            dbContext.AddUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Observation(string searchTerm, string observationType)
        {
            var observation = Observations(searchTerm, observationType);

            return View(observation);
        }
        public IActionResult Diagram()
        {
            ObservationViewModel model = new ObservationViewModel();
            model.AnimalList = dbContext.GetAnimals();
            DateTime FirstStartDate = new DateTime(2010, 11, 1);
            DateTime FirstEndDate = new DateTime(2010, 12, 31);
            DateTime SecondStartDate = new DateTime(2019, 11, 1);
            DateTime SecondEndDate = new DateTime(2019, 12, 31);
            model.Statistics = new Statistics();

            int specieID = 3;// ripa

            Helper.getCoatColors(model, Helper.filterByDate(model, FirstStartDate, FirstEndDate, specieID), 1);
            Helper.getCoatColors(model, Helper.filterByDate(model, SecondStartDate, SecondEndDate, specieID), 2);

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
            Helper.setCurrentTime(model.Animal);
            model.Coat = Helper.getCoats();

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
            //ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public IActionResult Contact(string firstname, string lastname, string sender, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SendEmailContactPage(firstname, lastname, sender, subject, message);
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.Clear();
                ViewBag.Message = $" Något gick fel. {ex.Message}";
            }
            return View();
        }
        private void SendEmailContactPage(string firstname, string lastname, string sender, string subject, string message)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(sender, "Klimatkollens kontaktformulär"); // eller mejlen i formuläret 
            mm.To.Add("sabrinthao@gmail.com");//Jörgens mail 
            mm.Subject = subject;
            string customerSender = "From: " + sender + " " + firstname + " " + lastname + "\n";
            mm.Body = customerSender + message;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("ADMINMAIL", "ADMINPASSWORD"); //admin //try model.Email, model.Password
            smtp.EnableSsl = true;
            smtp.Send(mm);
            ModelState.Clear();
            ViewBag.Message = "Thank you for Contacting us ";
        }
        public IActionResult AnimalObservation(int id)
        {
            AnimalObservationViewModel model = new AnimalObservationViewModel();
            model.Animal = dbContext.getAnimal(id);
            model.User = dbContext.GetUser(model.Animal.UserId);
            model.Animal.Specie = dbContext.getAnimalSpecie(model.Animal);
            return View(model);
        }
        public IActionResult WeatherObservation(int id)
        {
            WeatherObservationViewModel model = new WeatherObservationViewModel();
            model.Weather = dbContext.GetWeather(id);
            model.User = dbContext.GetUser(model.Weather.UserId);
            return View(model);
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

        public IActionResult UserHome(double radius=50, int daysBeforeToday=3)
        {
            UserHomeViewModel model = new UserHomeViewModel();
            model.radius = (radius / 111111) * 1000;
            model.daysBeforeToday = daysBeforeToday;
            DateTime today = DateTime.Now;
            DateTime before = today.AddDays(daysBeforeToday * -1);

                var userId = userManager.GetUserId(HttpContext.User);
                model.User = dbContext.GetUserFromIdentity(userId);
                List<Animal> NearbyAnimals = dbContext.GetNearbyAnimals(model.User.Latitude, model.User.Longitude, model.radius);
                List<Observation> NearbyObservation = new List<Observation>();
                model.NearbyObservation = NearbyObservation;
                foreach (var item in NearbyAnimals)
                {
                model.NearbyObservation.Add(new Observation() { Animal = item, Datetime = item.Datetime });
                }
                model.NearbyObservation = Helper.filterByDateUserHome(model.NearbyObservation, before, today);

            return View(model);
            }
        public IActionResult UpdateUserHome(UserHomeViewModel model)
        {
           return RedirectToAction("UserHome",new { model.radius, model.daysBeforeToday });
        }
        //public IActionResult Map()
       // {
          //  MapViewModel model = new MapViewModel();
           // model.Animals = dbContext.GetAnimals();

           // return View(Helper.getCentralPosition(model));
       // }

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
