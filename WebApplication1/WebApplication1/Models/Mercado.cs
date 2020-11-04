using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Mercado
    {
        public Mercado(int id, double underOver, double cuotaUnder, double cuotaOver, double dineroOver, double dineroUnder, int idEvento)
        {
            Id = id;
            UnderOver = underOver;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            IdEvento = idEvento;

        }

        public int Id { get; set; }
        public double UnderOver { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public int IdEvento { get; set; }

    }

    public class MercadoDTO
    {
        public MercadoDTO( double underOver, double cuotaUnder, double cuotaOver, double dineroOver, double dineroUnder, int idEvento)
        {
            UnderOver = underOver;
            CuotaUnder = cuotaUnder;
            CuotaOver = cuotaOver;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            IdEvento = idEvento;

        }

        public double UnderOver { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public int IdEvento { get; set; }
    }
}