using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inmobiliar.Models
{
    public class PersonasModel
    {        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string TelefonoLaboral { get; set; }
        public string DU { get; set; }
        public Nullable<int> PersonasId { get; set; }
    }
}