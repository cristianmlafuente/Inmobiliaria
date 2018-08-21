using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using InmBLL.Entities;

namespace Inmobiliar.Models
{
    public class PropiedadesModel
    {
        [Required]
        [DataType(DataType.Text)]
        public DomiciliosModel domicilio { get; set; }
        public string Tipo { get; set; }
        //[Required]
        [DataType(DataType.Text)]
        public PersonasModel Dueño { get; set; }
        public Nullable<int> NroContratoEpec { get; set; }
        public string NomenclaturaCatastral { get; set; }
        public string NumeroCtaRenta { get; set; }
        public Nullable<int> UnidadFacturacion { get; set; }
        public int PropiedadesId { get; set; }
        public Nullable<bool> Estado { get; set; }
		public string ClienteEpecNro { get; set; }
		public int NumeroFacturaAgua { get; set; }
		public string NroMedidorGas { get; set; }
        public Nullable<decimal> MontoVenta { get; set; }
        public Nullable<int> TelefonoExpensas { get; set; }
    }

    public class Propiedad
    {
        public string Calle;
        public Nullable<int> Numero;
        public int PropiedadId;
        public string Barrio;
        public Nullable<int> Piso;
        public string Dto;
        public string CP;
        public string Ciudad;
        public Nullable<int> NroContratoEpec;
        public string NomCatrastal;
        public string NumeroCtaRenta;
		public string ClienteEpecNro;
		public string NumeroFacturaAgua;
		public string NroMedidorGas;
        public Nullable<int> UnidadFacturacion;
        public Nullable<int> DomicilioId;
        public Nullable<int> IdPropietario;
        public string Apellido;
        public string Nombre;
        public string Du;
        public string TelLabo;
        public List<TipoImpuestosServicios> Impuesto;
        public string Tipo;
        public bool Estado;
    }
}