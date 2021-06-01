using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;

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
        public string Alerta { get; set; }

        public IActionResult Index(string Alerta = "")
        {
            var tmp = new LoginController
            {
                Alerta = Alerta
            };
            return View(tmp);
        }

        public IActionResult Err()
        {
            var tmp = new LoginController
            {
                Alerta = "Usuario o contraseña incorrectas"
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
            } else
            {
                return RedirectToAction("Index", "Login", new { Alerta = "Usuario o contraseña incorrecta"});
            }

            return View();
        }

        public void OnPost()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=bitacora;Uid=root;password=2105Itok/5012;";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            conexion.Open();

            var sql = "INSERT INTO `bitacora`.`bitacora` (`Username`, `Hora_Entrada`) VALUES ('@usuario', '@entrada')";
            using var cmd = new MySqlCommand(sql, conexion);
            DateTime HoraRegistro = DateTime.Now.Date;

            cmd.Parameters.AddWithValue("@usuario", UserLogin);
            cmd.Parameters.AddWithValue("@entrada", HoraRegistro);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}
