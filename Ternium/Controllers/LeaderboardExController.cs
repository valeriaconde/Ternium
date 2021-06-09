using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ternium.Controllers
{
    public class LeaderboardExController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
