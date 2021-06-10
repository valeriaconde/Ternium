using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ternium.Models;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ternium.Controllers
{
    public class UserLeaderboard
    {
        public int ID { get; set; }
        public string nombreUsuario { get; set; }
        public int puntaje { get; set; }
    }

    public class LeaderboardController : Controller
    {
        public IList<UserLeaderboard> ListaLeader { get; set; }

        [BindProperty]
        public bool ShowJuego { get; set; }

        [BindProperty]
        public string TableHTML { get; set; }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                return RedirectToAction("Index", "Login");
            }

            ListaLeader = new List<UserLeaderboard>();

            string connectionString = "Server=127.0.0.1;Port=3306;Database=actualizada;Uid=root;password=rootroot;";

            MySqlConnection conexion = new MySqlConnection(connectionString);
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "SELECT usuario.Usuario_ID, usuario.Username, juego.Puntaje_Total FROM juego JOIN usuario ON juego.Usuario = usuario.Usuario_ID ORDER BY Puntaje_Total DESC LIMIT 10;";
            using (var reader = cmd.ExecuteReader()) 
            {
                while (reader.Read())
                {
                    UserLeaderboard usr1 = new UserLeaderboard();
                    usr1.ID = Convert.ToInt32(reader["Usuario_ID"]);
                    usr1.nombreUsuario = reader["Username"].ToString() ?? "NULL";
                    usr1.puntaje = Convert.ToInt32(reader["Puntaje_Total"]);
                    ListaLeader.Add(usr1);
                }
            }
            conexion.Dispose();

            TableHTML = @"<table class=""table table-hover""><thead class=""head""><tr><th scope = ""col""> Lugar </ th><th scope=""col"">Inspector</th><th scope = ""col""> Puntos </th ></ tr></ thead><tbody>";

            // Tabla a manita
            foreach(UserLeaderboard usr in ListaLeader){
                TableHTML += $"<tr><td scope=\"row\">{usr.ID}</td><td> <a href=\"Home?UserName={usr.nombreUsuario ?? "N/A"}\">{usr.nombreUsuario ?? "N/A"}</a> </td ><td> {usr.puntaje} </td ></tr> ";
            }

            TableHTML += @"</tbody></table>";

            var tmp = new LeaderboardController
            {
                TableHTML = TableHTML
            };
            return View(tmp);
        }

        public void OnGet()
        {
            ListaLeader = new List<UserLeaderboard>();
        }
    }
}
