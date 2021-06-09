using Microsoft.AspNetCore.Mvc;
using Ternium.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Ternium.Controllers
{
    public class HomeController : Controller
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public int Points { get; set; }

        public IActionResult Index(string UserName = null)
        {
            string user = HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index", "Login");
            }

            var tmp = new HomeController
            {
                UserName = UserName ?? user,
                Points = 0
            };


            return View(tmp);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
