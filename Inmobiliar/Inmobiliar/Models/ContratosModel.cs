using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InmBLL.Entities;

namespace Inmobiliar.Models
{
    public class ContratosModel
    {
        public Contratos Contrato { get; set; }        
        public ContratosModel()
        {
            this.Contrato = new Contratos();
        }
        public string Impuestos {get;set;}
        public string idPersonaGarantePropietario { get; set; }
        public string CalleGarantePropietario { get; set; }
        public string CiudadGarantePropietario { get; set; }
        public string NumeroGarantePropietario { get; set; }
        public string PisoGarantePropietario { get; set; }
        public string DepartamentoGarantePropietario { get; set; }
        public string BarrioGarantePropietario { get; set; }
        public string CPGarantePropietario { get; set; }
        public string MatriculaGarantePropietario { get; set; }
    }
}