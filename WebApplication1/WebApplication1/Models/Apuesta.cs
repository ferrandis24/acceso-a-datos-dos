using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Apuesta
    {
            public Apuesta(int id, DateTime fecha, int cuota, string tipoApuesta, int mercado_id, double dineroApostado)
            {
                Id = id;
                Fecha = fecha;
                Cuota = cuota;
                TipoApuesta = tipoApuesta;
                Mercado_id = mercado_id;
                DineroApostado = dineroApostado;
            }

            public int Id { get; set; }
            public DateTime Fecha { get; set; }
            public int Cuota { get; set; }
            public string TipoApuesta { get; set; }
            public int Mercado_id { get; set; }
            public double DineroApostado { get; set; }


    }

    public class ApuestaDTO
    {
        public ApuestaDTO( DateTime fecha, int cuota, string tipoApuesta, int mercado_id, double dineroApostado)
        {
           
            Fecha = fecha;
            Cuota = cuota;
            TipoApuesta = tipoApuesta;
            Mercado_id = mercado_id;
            DineroApostado = dineroApostado;
        }

      
        public DateTime Fecha { get; set; }
        public int Cuota { get; set; }
        public string TipoApuesta { get; set; }
        public int Mercado_id { get; set; }
        public double DineroApostado { get; set; }
    }
    public class ApuestaUsuario
    {
        public ApuestaUsuario(int evento, string tipoApuesta, double cuota, double dineroApostado)
        
            {
                Evento = evento;
                TipoApuesta = tipoApuesta;
                Cuota = cuota;
                Dineroapostado = dineroApostado;
            }
        public int Evento { get; set; }
        public string TipoApuesta { get; set; }
        public double Cuota { get; set; }
        public double Dineroapostado { get; set; }
    }

    public class ApuestaMercado
    {
        public ApuestaMercado(int tipoMercado, string tipo_apuesta, double cuota, double dineroApostado, int mercado_id)
        {
            TipoMercado = tipoMercado;
            Tipo_apuesta = tipo_apuesta;
            Cuota = cuota;
            DineroApostado = dineroApostado;
            Mercado_id = mercado_id;
        }

        public int TipoMercado { get; set; }
        public string Tipo_apuesta { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public int Mercado_id { get; set; }

    }
}