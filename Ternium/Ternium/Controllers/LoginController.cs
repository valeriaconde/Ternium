using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ternium.Controllers
{
    public class LoginController : Controller
    {
        [BindProperty]
        public string UserLogin { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string MessageX { get; set; }

        public IActionResult Index()
        {
            var tmp = new LoginController
            {
                MessageX = ""
            };
            return View(tmp);
        }

        public IActionResult Err()
        {
            var tmp = new LoginController
            {
                MessageX = "Usuario o contraseña incorrectas"
            };
            return View(tmp);
        }

        public async Task<IActionResult> Form1()
        {

            //Buscamos el recurso
            Uri baseURL = new Uri("https://chatarrap-api.herokuapp.com/users/login");

            //Creamos el cliente para que haga nuestra peticion
            HttpClient client = new HttpClient();

            // Armamos nuestra peticion
            JObject joPeticion = new JObject();
            joPeticion.Add("username", UserLogin);
            joPeticion.Add("password", Password);

            var stringContent = new StringContent(joPeticion.ToString(), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(baseURL.ToString(), stringContent);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                JObject responseJO = JObject.Parse(responseContent);
                string token = responseJO.GetValue("token").ToString();

                HttpContext.Session.SetString("user", UserLogin);
                HttpContext.Session.SetString("token", token);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
