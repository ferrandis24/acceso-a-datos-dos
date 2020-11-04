using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UsuarioRepository
    {
        private MySqlConnection conect()
        {
            String connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }
        internal Usuario Retrieve()
        {
            MySqlConnection con = conect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Usuario";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Usuario u = null;

            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3));
                u = new Usuario(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetString(3));

            }




            return u;
        }
    }
}