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
using System.Net.Mail;
using System.Net;

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
        public IActionResult Diagram()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Diagram()
        {
            DateTime FirstStartDate = new DateTime(2010, 11, 1);
            DateTime FirstEndDate = new DateTime(2010, 12, 31);
            DateTime SecondStartDate = new DateTime(2019, 11, 1);
            DateTime SecondEndDate = new DateTime(2019, 12, 31);

            int specieID = 3;// ripa

            Helper.getCoatColors(model, Helper.filterByDate(model, FirstStartDate, FirstEndDate, specieID), 1);
            Helper.getCoatColors(model, Helper.filterByDate(model, SecondStartDate, SecondEndDate, specieID), 2);

            return View(Helper.getCentralPosition(model));
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
            Statistics statistics = new Statistics();
            model.Statistics = statistics;
            model.AnimalList = dbContext.GetAnimals();
            model.WeatherList = dbContext.GetWeathers();
            model.UserList = dbContext.GetUsers();
            model.ObservationsList = new List<object>();
            //sorts the 2 lists
            model.AnimalList = model.AnimalList.OrderByDescending(x => x.Datetime).ToList();
            model.WeatherList = model.WeatherList.OrderByDescending(x => x.Datetime).ToList();
            
            foreach (var item in model.WeatherList)
            {
                model.ObservationsList.Add(item);
            }
            //ObservationsList.OrderBy(x => x.DateTime).ToList();

            return View();
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

        [HttpGet]
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
                    SendEmailContactPage(firstname,lastname,sender,subject,message);
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

        public IActionResult UserHome()
        {
            UserHomeViewModel model = new UserHomeViewModel();
            var userId = userManager.GetUserId(HttpContext.User);
            model.User = dbContext.GetUserFromIdentity(userId);
            model.Animals = dbContext.getUserAnimals(model.User.UserId);
            model.Weathers = dbContext.getUserWeathers(model.User.UserId);


            return View(model);
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
