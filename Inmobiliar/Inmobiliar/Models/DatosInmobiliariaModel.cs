using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inmobiliar.Models
{
    public class DatosInmobiliariaModel
    {
        public string InmueblesEnAlquiler { get; set; }
        public string InmueblesEnVenta { get; set; }
        public string ConsultaDeClientes { get; set; }
        public string FuturosClientes { get; set; }
        public string Impagos { get; set; }
        public string NombreInmobiliaria { get; set; }
        public string TareasDiarias { get; set; }
        public string Pendientes { get; set; }
    }
}