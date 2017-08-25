﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class Personas
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string TelefonoLaboral { get; set; }
        public string DU { get; set; }
        public Nullable<int> PersonasId { get; set; }
        public string Detalle = "";
    }
}
