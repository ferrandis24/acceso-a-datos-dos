using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class ApuestaRepository
    {
        private MySqlConnection connect()
        {
            String connString = "Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }
        internal Apuesta Retrieve()
        {
            MySqlConnection con = connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Apuesta";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Apuesta a = null;

            if (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetInt32(2) + " " + res.GetString(3) + " " + res.GetInt32(4) + " " + res.GetDouble(5));
                a = new Apuesta(res.GetInt32(0), res.GetDateTime(1), res.GetInt32(2), res.GetString(3), res.GetInt32(4), res.GetDouble(5));

            }

            con.Close();
            return a;
        }

        internal ApuestaDTO RetrieveDTO()
        {
            MySqlConnection con = connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Apuesta";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO a = null;
                if (res.Read())



                {
                    Debug.WriteLine("Recuperado:  " + res.GetDateTime(1) + " " + res.GetInt32(2) + " " + res.GetString(3) + " " + res.GetInt32(4) + " " + res.GetDouble(5));
                    a = new ApuestaDTO(res.GetDateTime(1), res.GetInt32(2), res.GetString(3), res.GetInt32(4) ,res.GetDouble(5));

                }

                con.Close();
                return a;
            }
            catch(MySqlException a) {

                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }

        }
        
        internal MercadoDTO RetrieveMercado(ApuestaDTO apuesta)
        {
            MySqlConnection con = connect();
            MySqlCommand command = con.CreateCommand();

            if (apuesta.TipoApuesta == "Over")
            {
                command.CommandText = "SELECT CuotaOver FROM Mercado WHERE id = " + apuesta.Mercado_id;
            }
            else if (apuesta.TipoApuesta == "Under")
            {
                command.CommandText = "SELECT CuotaUnder FROM MercadoWHERE id = " + apuesta.Mercado_id; ;
            }

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                MercadoDTO m = null;

                if (res.Read())
                {
                    m = new MercadoDTO(res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                }
                con.Close();
                return m;
            }
            catch (MySqlException a)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }


        } 
        
    } 
}
    




