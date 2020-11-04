using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Usuario
    {
        public Usuario(int id, string nombre, string apellido, int edad, string email)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Email = email;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
    }
}


