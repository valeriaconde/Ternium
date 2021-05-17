﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ternium.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
