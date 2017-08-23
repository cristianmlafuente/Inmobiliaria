using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inmobiliar.Models
{
    public class DomiciliosModel
    {
        public int DomiciliosId { get; set; }

        //[Required(ErrorMessage = "El nombre de la calle es requerido")]
        [DataType(DataType.Text)]
        public string Calle { get; set; }
        //[Required(ErrorMessage = "El nombre de la ciudad requerido")]
        [DataType(DataType.Text)]
        public string Ciudad { get; set; }
        //[Required(ErrorMessage = "El codigo postal es requerido")]
        [DataType(DataType.Text)]
        public string CP { get; set; }
        public Nullable<int> Piso { get; set; }
        public string Dto { get; set; }
        public Nullable<int> Numero { get; set; }
        //[Required(ErrorMessage = "El nombre del barrio es requerido")]
        public string Barrio { get; set; }
    }
}