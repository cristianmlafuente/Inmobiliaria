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
        public string PorcentajeInmobiliaria { get; set; }
        public ContratosModel()
        {
            this.Contrato = new Contratos();
        }
        public string Impuestos {get;set;}
       
    }
}