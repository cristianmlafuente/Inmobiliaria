//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InmDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contrato_ImpuestoServicio
    {
        public int CodImpuesto { get; set; }
        public int IdContrato { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
    
        public virtual Contratos Contratos { get; set; }
        public virtual TiposImpuestosServicios TiposImpuestosServicios { get; set; }
    }
}