using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grupp7.Models;
using Grupp7.Classes;
using Grupp7.Data;
using Grupp7.ViewModels;
using Grupp7.Interfaces;

namespace Grupp7.Controllers
{ //sabrinas test 
    public class HomeController : Controller
    {
        private readonly IRepository dbContext;

        public HomeController(IRepository repository)
        {
            dbContext = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Observation()
        {
            ObservationViewModel model = new ObservationViewModel();
            model.AnimalList = dbContext.GetAnimals();
            model.WeatherList = dbContext.GetWeathers();
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

        public IActionResult Register ()
        {
            RegisterUserViewModel model = new RegisterUserViewModel();
            return View(model);
        }

        public IActionResult Map()
        {
            MapViewModel model = new MapViewModel();
            model.Animals = dbContext.GetAnimals();
            return View(model);
        }
        
        public async Task<ActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var user = new User();
                user = model.User;
                dbContext.AddUser(user);

                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("Register", "Home");
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

        [HttpPost]
        public IActionResult Validate(/*User userModel*/) // Logga in
        {
            //using (FreelanceMeDBEntities db = new FreelanceMeDBEntities())
            //{
            //    var userDetails = db.userDetails.Where(x => x.email == userModel.email && x.password == userModel.password).FirstOrDefault();
            //    if (userDetails == null)
            //    {
            //        userModel.UserLoginErrorMessage = "Wrong Username or Password";
            //        return View("Home", userModel);
            //    }
            //    else
            //    {
            //        Session["user_id"] = userDetails.user_id;
            //        // Session["UserName"] = userDetails.UserName; (Keeps track of Username while logged in)
            //        return RedirectToAction("Home", "Index");
            //    }
            //}
            return null;
        }
        public IActionResult LogOut() // Logga ut
        {
            // int userId = (int)Session["UserID"]; (Keeps track of the UserID, saves it if needed).
            //Session.Abandon();
            // Redirect to Home/Index instead, when that exists. Home page no Login Index page.
            //return RedirectToAction("Index", "Home");
            return null;
        }
    }
}
