using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseIncreiblesTernium.Model;
using MySql.Data.MySqlClient;

namespace DataBaseIncreiblesTernium.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Bitacora> ListaBitacoras { get; set; }
        public void OnPost()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=bitacora;Uid=root;password=2105Itok/5012;";
            MySqlConnection conexion = new MySqlConnection(connectionString); 
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand(); 
            cmd.Connection = conexion; 
            cmd.CommandText = "Select * from bitacora";
            Bitacora btr1 = new Bitacora(); 
            ListaBitacoras = new List<Bitacora>(); 
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    btr1 = new Bitacora(); 
                    btr1.bitacoraID = Convert.ToInt32(reader["idBitacora"]); 
                    btr1.usuarioID = reader["Usuario_ID"].ToString();
                    btr1.fechaConexion = Convert.ToDateTime(reader["Hora_Entrada"]);
                    ListaBitacoras.Add(btr1);
                }
            }
            conexion.Dispose();
        }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ListaBitacoras = new List<Bitacora>();
        }
    }
}
