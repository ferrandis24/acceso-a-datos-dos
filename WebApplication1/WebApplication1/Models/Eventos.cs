using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Eventos
    {
        public Eventos(int id, string equipoLocal, string equipoVisitante, int fecha, int goles)
        {
            Id = id;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
            Goles = goles;
        }

        public int Id { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public int Fecha { get; set; }
        public int Goles { get; set; }


    }

    public class EventosDTO
    {
        public EventosDTO(string equipoLocal, string equipoVisitante, int fecha, int goles)
        {

            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
            Goles = goles;
        }

        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public int Fecha { get; set; }
        public int Goles { get; set; }
    }
}