using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intesis_Web_Demo.Models
{
    public class Trabajadores_BD
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string rut { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }

    }
}
