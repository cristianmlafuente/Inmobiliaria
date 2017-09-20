using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inmobiliar.Models
{
    public class PersonasModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string TelefonoLaboral { get; set; }
        [Required]
        public string DU { get; set; }
        public Nullable<int> PersonasId { get; set; }
    }
}