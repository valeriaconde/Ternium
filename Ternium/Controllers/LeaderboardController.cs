using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ternium.Controllers
{
    public class UserLeaderboard
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
    }

    public class LeaderboardController : Controller
    {
        [BindProperty]
        public string TableHTML { get; set; }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                return RedirectToAction("Index", "Login");
            }

            List<UserLeaderboard> users = new List<UserLeaderboard>();

            users.Add(new UserLeaderboard { Name = "Valeria", Points = 15017, Rank = 1 });
            users.Add(new UserLeaderboard { Name = "Cristina", Points = 15017, Rank = 2 });
            users.Add(new UserLeaderboard { Name = "Lorena", Points = 15017, Rank = 3 });
            users.Add(new UserLeaderboard { Name = "Cruella", Points = 15017, Rank = 4 });
            users.Add(new UserLeaderboard { Name = "Tere", Points = 15017, Rank = 5 });

            TableHTML = @"<table class=""table table-hover""><thead class=""head""><tr><th scope = ""col""> Lugar </ th><th scope=""col"">Inspector</th><th scope = ""col""> Puntos </th ></ tr></ thead><tbody>";

            // Tabla a manita
            foreach(UserLeaderboard usr in users){
                TableHTML += $"<tr><td scope=\"row\">{usr.Rank}</td><td> <a href=\"Home?UserName={usr.Name}\">{usr.Name}</a> </td ><td> {usr.Points} </td ></tr> ";
            }

            TableHTML += @"</tbody></table>";

            var tmp = new LeaderboardController
            {
                TableHTML = TableHTML
            };
            return View(tmp);
        }
    }
}
