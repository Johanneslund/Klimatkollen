﻿using System;
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

        public IActionResult Observation(string sortBy, string searchTerm)
        {

            ObservationViewModel model = new ObservationViewModel();
            Animal animal = new Animal();
            Weather weather = new Weather();
            Observation obs = new Observation();
            List<Animal> animals = new List<Animal>();
            List<Weather> weathers = new List<Weather>();
            animals = dbContext.GetAnimals();
            weathers = dbContext.GetWeathers();
            model.ObservationsList = new List<Observation>();

            // Populate the lists
            foreach (var item in animals)
            {
                model.ObservationsList.Add(new Observation { Animal = item, Datetime = item.Datetime, ObservationTypes = item.Specie.Speciename, Cities = item.City,
                                                            Names = item.User.Lastname, FirstNames = item.User.Firstname });
            }
            foreach (var item in weathers)
            {
                model.ObservationsList.Add(new Observation { Weather = item, Datetime = item.Datetime, ObservationTypes = item.Type, Cities = item.City,
                                                            Names = item.User.Lastname, FirstNames = item.User.Firstname});
            }

            #region // SortBy
            ViewData["ObservationSortParameter"] = String.IsNullOrEmpty(sortBy) ? "observationDesc" : "";
            ViewData["DatetimeSortParameter"] = sortBy == "datetime" ? "datetimeDesc" : "datetime";
            ViewData["CitySortParameter"] = sortBy == "city" ? "cityDesc" : "city";
            ViewData["NameSortParameter"] = sortBy == "name" ? "nameDesc" : "name";
            ViewData["CurrentFilter"] = searchTerm;
            #endregion

            #region Sortering
            switch (sortBy)
            {
                case "observationDesc":
                    model.ObservationsList = model.ObservationsList.OrderByDescending(x => x.ObservationTypes).ToList();
                    break;
                case "datetime":
                    model.ObservationsList = model.ObservationsList.OrderBy(x => x.Datetime).ToList();
                    break;
                case "datetimeDesc":
                    model.ObservationsList = model.ObservationsList.OrderByDescending(x => x.Datetime).ToList();
                    break;
                case "city":
                    model.ObservationsList = model.ObservationsList.OrderBy(x => x.Cities).ToList();
                    break;
                case "cityDesc":
                    model.ObservationsList = model.ObservationsList.OrderByDescending(x => x.Cities).ToList();
                    break;
                case "name":
                    model.ObservationsList = model.ObservationsList.OrderBy(x => x.Names).ToList();
                    break;
                case "nameDesc":
                    model.ObservationsList = model.ObservationsList.OrderByDescending(x => x.Names).ToList();
                    break;
                default:
                    model.ObservationsList = model.ObservationsList.OrderBy(x => x.ObservationTypes).ToList();
                    break;
            }
            #endregion

            #region Search and SearchBox
            if (!String.IsNullOrEmpty(searchTerm))
            {
                model.ObservationsList = model.ObservationsList.Where(x => x.Names.Contains(searchTerm) || x.ObservationTypes.Contains(searchTerm) || x.FirstNames.Contains(searchTerm)).ToList();
            }
            else
            {
                model.ObservationsList = model.ObservationsList.OrderBy(x => x.ObservationTypes).ToList();
            }
            #endregion

            Helper.getCentralPosition(model);

            var t = TempData["success"];
            if (t != null)
            {
                ViewData["success"] = t;
            }

            return View(model);
        }

        public HomeController(IRepository repository, UserManager<IdentityUser> userManager)
        {
            this.dbContext = repository;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            UserRankViewModel urvm = new UserRankViewModel();
            IndexViewModel model = new IndexViewModel();
            List<Animal> animals = new List<Animal>();
            List<Weather> weathers = new List<Weather>();
            List<User> users = new List<User>();

            animals = dbContext.GetAnimals();
            weathers = dbContext.GetWeathers();
            users = dbContext.GetUsers();

            // räknar antalet observationer till varje användare
            int observationCounter = 0;
            DateTime mostRecentObservation = new DateTime(1900,1,1);
            foreach (var user in users)
            {
                foreach (var item in animals)
                {
                    if (item.UserId == user.UserId)
                    {
                        observationCounter++;
                        if (item.Datetime > mostRecentObservation)
                        {
                            mostRecentObservation = item.Datetime;
                        }
                    }
                }
                foreach (var item in weathers)
                {
                    if (item.UserId == user.UserId)
                    {
                        observationCounter++;
                        if (item.Datetime > mostRecentObservation)
                        {
                            mostRecentObservation = item.Datetime;
                        }
                    }

                }
                if(observationCounter > 0)
                {
                    model.UserRankList.Add(new UserRankViewModel()
                    {
                        User = user,
                        observationNum = observationCounter,
                        lastObservation = mostRecentObservation
                    });
                }
                observationCounter = 0;
                mostRecentObservation = new DateTime(1900,1,1);
            } 

            //sorterar listan i descending order
            model.UserRankList = model.UserRankList.OrderByDescending(x => x.observationNum).ThenBy(x => x.lastObservation).Take(20).ToList();

            //sätter position property
            int position = 1;
            foreach (var user in model.UserRankList) 
            {
                user.position = position;
                position++;
            } 
            return View(model);
        }
        public IActionResult AddUserFromRegister(UserModel user)
        {
            dbContext.AddUser(user);
            return RedirectToAction("Index");
        }
        public IActionResult AddNotCompleteUserInfo(User model)
        {
            model.Id = userManager.GetUserId(HttpContext.User);
            if (ModelState.IsValid)
            { 
            dbContext.AddOldUserToDb(model);
            return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Var god fyll i formuläret, använde du kartan?";
            return RedirectToAction("AddUserInfo");
        }

        public IActionResult Diagram()
        {
            ObservationViewModel model = new ObservationViewModel();
            model.Statistics = new Statistics();
            model.AnimalList = dbContext.GetAnimals();

            DateTime FirstStartDate = new DateTime(2010, 11, 1);
            DateTime FirstEndDate = new DateTime(2010, 12, 31);
            DateTime SecondStartDate = new DateTime(2019, 11, 1);
            DateTime SecondEndDate = new DateTime(2019, 12, 31);
            int specieID = 3;// ripa
            Helper.getCoatColors(model, Helper.filterByDate(model, FirstStartDate, FirstEndDate, specieID), 1);
            Helper.getCoatColors(model, Helper.filterByDate(model, SecondStartDate, SecondEndDate, specieID), 2);

            model.Statistics.GrouseByYear = Helper.GetAnimalsByYear(model,3); // hårdkodat species. 
            model.Statistics.FoxByYear = Helper.GetAnimalsByYear(model,2);
            model.Statistics.SwineByYear = Helper.GetAnimalsByYear(model,4);
            model.Statistics.FrogByYear = Helper.GetAnimalsByYear(model, 5);
            model.Statistics.HareByYear = Helper.GetAnimalsByYear(model, 1);

            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpGet]
        public IActionResult AddAnimal()
        { 
            AddAnimalViewModel model = new AddAnimalViewModel();
            model.Animal = new Animal();
            model.Species = dbContext.getSpeciesItemList();
            Helper.setCurrentTimeAnimal(model.Animal);
            model.Coat = Helper.getCoats();
            var t = TempData["errorMessage"];
            if (t != null)
            {
                ViewData["errorMessage"] = t;
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddWeather()
        {
            AddWeatherViewModel model = new AddWeatherViewModel();
            model.Weather = new Weather();
            model.WeatherTypes = Helper.getWeatherTypes();
            var t = TempData["errorMessage"];
            if (t != null)
            {
                ViewData["errorMessage"] = t;
            }
            Helper.setCurrentTimeWeather(model.Weather);
            return View(model);
        }
        [HttpPost]
        public IActionResult AddAnimal(AddAnimalViewModel model)
        {
            AddAnimalViewModel Model = model;
            if (ModelState.IsValid)
            {
                Model.User = dbContext.GetUserFromIdentity(userManager.GetUserId(HttpContext.User));
                dbContext.AddAnimalToUser(Model);
                TempData["Success"] = "Din Djurobservation har registrerats";
                return RedirectToAction("UserHome");
            }
            TempData["errorMessage"] = "Något gick fel, använde du kartan?";
            return RedirectToAction("AddAnimal");
        }
        [HttpPost]
        public IActionResult AddWeather(AddWeatherViewModel model)
        {
            AddWeatherViewModel Model = model;
            if(ModelState.IsValid)
            { 
                Model.User = dbContext.GetUserFromIdentity(userManager.GetUserId(HttpContext.User));
                dbContext.AddWeatherToUser(model);
                TempData["Success"] = "Din Väderobservation har registrerats";
                return RedirectToAction("UserHome");
            }
            TempData["errorMessage"] = "Något gick fel, använde du kartan?";
            return RedirectToAction("AddAnimal");


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
            catch (Exception)
            {
                ModelState.Clear();
                ViewBag.Message = $" Något gick fel.";
            }
            return View();
        }
        private void SendEmailContactPage(string firstname, string lastname, string sender, string subject, string message)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(sender, "Klimatkollens kontaktformulär"); 
            mm.To.Add("sabrinthao@gmail.com");//Jörgens mail 
            mm.Subject = subject;
            string customerSender = "From: " + sender + " " + firstname + " " + lastname + "\n";
            mm.Body = customerSender + "\n" + message;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("klimatkollen1@gmail.com", "Klimatkollen123"); 
            smtp.EnableSsl = true;
            smtp.Send(mm);
            ModelState.Clear();
            ViewBag.Message = "Thank you for Contacting us!";
        }
        public IActionResult AnimalObservation(int id)
        {
            AnimalObservationViewModel model = new AnimalObservationViewModel();
            model.Animal = dbContext.getAnimal(id);
            model.User = dbContext.GetUser(model.Animal.UserId);
            model.Animal.Specie = dbContext.getAnimalSpecie(model.Animal);
            var tempUser = userManager.Users.Where(x => x.Id == model.User.Id).FirstOrDefault();
            if (tempUser != null)
                model.Email = tempUser.Email;
            return View(model);

        }
        public IActionResult WeatherObservation(int id)
        {
            WeatherObservationViewModel model = new WeatherObservationViewModel();
            model.Weather = dbContext.GetWeather(id);
            model.User = dbContext.GetUser(model.Weather.UserId);           
            var tempUser = userManager.Users.Where(x => x.Id == model.User.Id).FirstOrDefault();
            if (tempUser != null)
                model.Email = tempUser.Email;
            return View(model);
        }
        [HttpGet]
        public IActionResult EditAnimal(int id)
        {
            Animal animal = dbContext.getAnimal(id);
            List <SelectListItem> speciesList = dbContext.getSpeciesItemList();
            List<SelectListItem> coatList = Helper.getCoats();
            EditAnimalViewModel model = new EditAnimalViewModel();
            model.Animal = animal;
            model.Coats = coatList;
            model.Species = speciesList;

            var t = TempData["error"];
            if (t != null)
            {
                ViewData["error"] = t;
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult EditWeather(int id)
        {
            EditWeatherViewModel model = new EditWeatherViewModel();
            model.Weather = dbContext.GetWeather(id);
            model.WeatherTypes = Helper.getWeatherTypes();

            var t = TempData["error"];
            if (t != null)
            {
                ViewData["error"] = t;
            }

            return View(model);
        }
        [HttpPost]
        public IActionResult EditAnimal(Animal animal)
        {
            if(ModelState.IsValid)
            { 
            dbContext.updateAnimal(animal);
                TempData["success"] = "Djurobservation uppdaterad";
                return RedirectToAction("Observation");
            }
            else
            {
                TempData["error"] = "Något gick fel";
                return RedirectToAction("EditAnimal",new { id = animal.AnimalId });
            }
        }
        [HttpPost]
        public IActionResult EditWeather(Weather weather)
        {
            if (ModelState.IsValid)
            {
                dbContext.updateWeather(weather);
                TempData["success"] = "Väderobservation uppdaterad";
                return RedirectToAction("Observation");
            }
            else
            {
                TempData["error"] = "Något gick fel";
                return RedirectToAction("EditWeather", new { id=weather.WeatherId });
            }
        }

        public IActionResult UserHome(double radius = 50, int daysBeforeToday = 3, bool IsUserObservation = true)
        {
            UserHomeViewModel model = new UserHomeViewModel();
            List<Animal> nearbyAnimals = new List<Animal>();
            List<Weather> nearbyWeathers = new List<Weather>();
            List<Observation> nearbyObservations = new List<Observation>();
            model.radius = (radius / 111111) * 1000;
            model.daysBeforeToday = daysBeforeToday;
            DateTime today = DateTime.Now;
            DateTime before = today.AddDays(daysBeforeToday *-1);
            model.NearbyObservation = nearbyObservations;
            var userId = userManager.GetUserId(HttpContext.User);
            dbContext.ClearCache(dbContext.GetUserFromIdentity(userId));
            model.User = dbContext.GetUserFromIdentity(userId);
            model.IsUserObservation = IsUserObservation;
            if (model.User.Latitude == null || model.User.Longitude == null ||
                model.User.Latitude== "" || model.User.Longitude=="")
            {
                TempData["noUser"] = "För att ta del av profilsidan behöver du fylla i formuläret";
                return RedirectToAction("AddUserInfo");
            }

            var t = TempData["Success"];
            if (t != null)
            {
                ViewData["Success"] = t;
            }
            if (IsUserObservation)
            {
                ViewData["observationList"] = "Här syns dina närliggande observationer";
                nearbyAnimals = dbContext.GetNearbyUserAnimals(model.User.Latitude, model.User.Longitude, model.radius, model.User.UserId);
                nearbyWeathers = dbContext.GetNearbyUserWeathers(model.User.Latitude, model.User.Longitude, model.radius, model.User.UserId);
            }
            else
            {
                ViewData["observationList"] = "Här syns observationer i närheten";
                nearbyAnimals = dbContext.GetNearbyAnimals(model.User.Latitude, model.User.Longitude, model.radius);
                nearbyWeathers = dbContext.GetNearbyWeathers(model.User.Latitude, model.User.Longitude, model.radius);
            }
            nearbyObservations = (Helper.PopulateObservationList(nearbyAnimals, nearbyWeathers));
            model.NearbyObservation = Helper.filterByDateUserHome(nearbyObservations, before, today);

            return View(model);
            }
        public IActionResult AddUserInfo()
        {
            User model = new User();
            var userId = userManager.GetUserId(HttpContext.User);
            model.Id = userId;
            var t = TempData["noUser"];
            if(t != null)
            {
                ViewData["noUser"] = t;
                ViewData["ErrorMessage"] = null;
            }
            var d = TempData["ErrorMessage"];
            if(d != null)
            {
                ViewData["ErrorMessage"] = d;
                ViewData["NoUser"] = null;
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            User tempUser = new User();
            tempUser = dbContext.GetUser(id);
            var t = TempData["noUser"];
            if (t != null)
            {
                ViewData["noUser"] = t;
                ViewData["ErrorMessage"] = null;
            }
            var d = TempData["ErrorMessage"];
            if (d != null)
            {
                ViewData["ErrorMessage"] = d;
                ViewData["NoUser"] = null;
            }
            return View(tempUser);
        }

        [HttpPost]
        public IActionResult EditUser(User model)
        {
            var aspuser = userManager.Users.Where(x => x.Id == userManager.GetUserId(HttpContext.User)).FirstOrDefault();
            if (model?.UserId != null && model.Latitude != null && model.Longitude != null)
            {
                dbContext.EditUser(model);
                aspuser.UserName = model.Username;
                var result = userManager.UpdateAsync(aspuser);

                TempData["Success"] = "Användarinformation uppdaterad";
                return RedirectToAction("UserHome",model.UserId);
            }
            TempData["ErrorMessage"] = "Var god fyll i formuläret, använde du kartan?";
            return RedirectToAction("EditUser", new { id = model.UserId});
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
