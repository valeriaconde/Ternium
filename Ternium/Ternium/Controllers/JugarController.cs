using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ternium.Controllers
{
    [Route("api/[controller]")]
    public class JugarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
