using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public DateTime Registro { get; set; }
    }
}