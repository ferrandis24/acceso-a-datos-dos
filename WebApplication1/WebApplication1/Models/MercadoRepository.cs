using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MercadoRepository
    {
        private MySqlConnection conect()
        {
            String connString = "Server = 127.0.0.1; Port = 3306; Database = placemybet; Uid = root; password =; SslMode = none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;

        }
        internal Mercado Retrieve()
        {
            MySqlConnection con = conect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Mercado";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Mercado m = null;

            if (res.Read())
            {
     
                m = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5),res.GetInt32(6));

            }




            return m;
        }

        internal ApuestaMercado RetriveByEvento(string email, double tipoMercado )
        {
            MySqlConnection con = conect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT mercado.underOver, mercado.id, apuesta.cuota,  apuesta.DineroApostado  FROM  mercado join apuesta  WHERE usuario.email=@email && underOver=@tipo ";
            command.Parameters.AddWithValue("@email", email );
            command.Parameters.AddWithValue("@tipo", tipoMercado);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            ApuestaMercado m = null;

            while(res.Read())
            {
                m = new ApuestaMercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3),res.GetInt32(4));

            }
            con.Close();
            return m;
        }

        internal ApuestaUsuario RetriveByUsuario(string email, double tipoMercado)
        {
            MySqlConnection con = conect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT mercado.underOver, mercado.id, apuesta.cuota,  apuesta.DineroApostado  FROM  mercado join apuesta  WHERE underOver=@tipou && suario.email=@email   ";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@tipo", tipoMercado);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            ApuestaUsuario m = null;

            while (res.Read())
            {
                m = new ApuestaUsuario(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3));

            }
            con.Close();
            return m;
        }


        internal Mercado RetrieveMercado(int id, double tipo)
        {
            MySqlConnection con = conect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM Mercado where ID_Evento= @id && OverUnder=@tipo";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@tipo", tipo);
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            Mercado m = null;

            if (res.Read())
            {
                m = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));

            }
            con.Close();
            return m;
        }
        internal MercadoDTO RetrieveMercado(ApuestaDTO apuesta)
        {
            MySqlConnection con = conect();
            MySqlCommand command = con.CreateCommand();


            con.Open();



            if (apuesta.TipoApuesta == "Over")
            {
                command.CommandText = "UPDATE Mercado Set DineroOver = DineroOver + " + apuesta.DineroApostado + " WHERE ID= " + apuesta.Mercado_id; ;
            }
            else if (apuesta.TipoApuesta == "Under")
            {
                command.CommandText = "UPDATE Mercado Set DineroUnder = DineroUnder + " + apuesta.DineroApostado + " WHERE ID= " + apuesta.Mercado_id;

            }
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                MercadoDTO m = null;

                if (res.Read())
                {
                    m = new MercadoDTO(res.GetInt32(1), res.GetInt32(2), res.GetInt32(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                }
                return m;
            }
            catch (MySqlException a)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
                return null;
            }
        }
        internal MercadoDTO RetrieveMercado()
        {

            MySqlConnection con = conect();
            MySqlCommand command = con.CreateCommand();

            command.CommandText = "SELECT * FROM Mercado";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            MercadoDTO m = null;

            if (res.Read())
            {

                Debug.WriteLine("Recuparado: " + res.GetDouble(1) + res.GetDouble(2) + res.GetDouble(3));
                m = new MercadoDTO(res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
            }

            return m;
        }

                internal void Calculos(ApuestaDTO Apuesta, Mercado Dinero)
            {

                MySqlConnection con = conect();
                MySqlCommand command = con.CreateCommand();
                double probabilidadOver = Dinero.DineroOver / (Dinero.DineroOver + Dinero.DineroUnder);
                double cuotaOver = 0;
                double over = 0.95;
                if (probabilidadOver != 0)
                {
                    cuotaOver = 1 / probabilidadOver * 0.95;
                    over = Math.Round((double)Convert.ToDouble(cuotaOver), 2);
                }

                double probabilidadUnder = Dinero.DineroUnder / (Dinero.DineroOver + Dinero.DineroUnder);
                double cuotaUnder = 0;
                double under = 0.95;
                if (probabilidadUnder != 0)
                {
                    cuotaUnder = 1 / probabilidadUnder * 0.95;
                    under = Math.Round((double)Convert.ToDouble(cuotaUnder), 2);
                }




                Debug.WriteLine("under: " + cuotaUnder + "dineroOver: " + Dinero.DineroOver + "dineroUnder: " + Dinero.DineroUnder + "probabilidad: " + probabilidadUnder);
                Debug.WriteLine("under: " + under);
                con.Open();

                command.CommandText = "UPDATE Mercado SET CuotaUnder=" + under.ToString(CultureInfo.CreateSpecificCulture("us-US")) + ", CuotaOver =" + over.ToString(CultureInfo.CreateSpecificCulture("us-US")) + " WHERE ID= " + Dinero.Id + ";";
                Debug.WriteLine("Comando: " + command.CommandText);



                command.ExecuteNonQuery();


            }

        }
    }
 
 
