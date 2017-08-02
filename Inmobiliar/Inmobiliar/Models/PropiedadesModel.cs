using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inmobiliar.Models
{
    public class PropiedadesModel
    {
        [Required]
        [DataType(DataType.Text)]
        public DomiciliosModel domicilio { get; set; }
        public string Tipo { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public PersonasModel Dueño { get; set; }
        public Nullable<int> NroContratoEpec { get; set; }
        public string NomenclaturaCatastral { get; set; }
        public string NumeroCtaRenta { get; set; }
        public Nullable<int> UnidadFacturacion { get; set; }
    }
}