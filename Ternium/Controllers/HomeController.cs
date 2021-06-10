using Microsoft.AspNetCore.Mvc;
using Ternium.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;

namespace Ternium.Controllers
{
    public class HomeController : Controller
    {
        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int Points { get; set; }

        [BindProperty]
        public int TiempoJugado { get; set; }

        [BindProperty]
        public int Games { get; set; }


        public IActionResult Index(string UserName = null)
        {
            string user = HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index", "Login");
            }

            TiempoJugado = Games = Points = 0;

            string connectionString = "Server=127.0.0.1;Port=3306;Database=actualizada;Uid=root;password=rootroot;";

            MySqlConnection conexion = new MySqlConnection(connectionString);
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = $"SELECT usuario.Usuario_ID, usuario.Nombre, juego.Puntaje_Total, usuario.Username, juego.Tiempo_Jugado FROM juego JOIN usuario ON juego.Usuario = usuario.Usuario_ID WHERE usuario.Username = '{UserName ?? user}'";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Points += Convert.ToInt32(reader["Puntaje_Total"]);
                    TiempoJugado += Convert.ToInt32(reader["Tiempo_Jugado"]);
                    Name = reader["Username"].ToString() ?? "Unknown";
                    Games++;
                }
            }
            conexion.Dispose();

            var tmp = new HomeController
            {
                UserName = UserName ?? user,
                Points = Points,
                TiempoJugado = TiempoJugado,
                Games = Games
            };

            return View(tmp);
        }

        [HttpGet("user")]
        public ActionResult<string> GetLoggedUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user))
            {
                return NotFound();
            }

            return Ok(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
