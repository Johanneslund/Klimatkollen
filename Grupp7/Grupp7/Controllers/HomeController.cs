using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grupp7.Models;

namespace Grupp7.Controllers
{ //sabrinas test 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Observation()
        {
            ViewData["Message"] = "Här visas alla observationer.";

            return View();
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
            // Skicka en en person modell här, alternativt en vymodel.

            return View();
        }
        /*
        public async Task<ActionResult> RegisterFreelancer(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var freelancer = new Freelancer();
                Person = model.Person;
                freelancer.aspnetusers_id = user.Id;
                
                Ändra kod ovan till att vara en användare, om identity inte används ta bort.
                

                var dbContext = new dbContext();

                Db context hamnar här

                var result = await UserManager.CreateAsync(user, model.Password);

                
                if (result.Succeeded) - om model state är valid
                {
                    UserManager.AddToRole(user.Id, "Freelancer");
                    dbContext.Person.Add(Person);
                    dbContext.SaveChanges();

                    Lägg till person till databas.

                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, model.Person.Firstname));

                    Cachea användarens namn
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("Index", "Home");
                    Retunera ny vy.
                }
                AddErrors(result);
            }
            return View(model);
        }


            Mycket möjligt att allt detta ska göras utanför controlern. 
    */

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
