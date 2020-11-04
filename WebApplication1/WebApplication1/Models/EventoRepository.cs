using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EventoRepository
    {
        private MySqlConnection conect()
        {
            String connString = "Server = 127.0.0.1; Port = 3306; Database = placemybet; Uid = root; password =; SslMode = none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }
        internal Eventos Retrieve()
        {
            MySqlConnection con = conect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Evento";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Eventos e = null;

            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetInt32(4));
                e = new Eventos(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetInt32(4));

            }




            return e;
        }
    }
}