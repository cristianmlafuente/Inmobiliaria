using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inmobiliar.Models
{
    public class DomiciliosModel
    {
        public int IdAddress { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Calle { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Ciudad { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string CP { get; set; }
        public Nullable<int> Piso { get; set; }
        public string Dto { get; set; }
        public Nullable<int> Numero { get; set; }
        [Required]
        public string Barrio { get; set; }
    }
}