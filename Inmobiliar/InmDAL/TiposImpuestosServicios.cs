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
    
    public partial class TiposImpuestosServicios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TiposImpuestosServicios()
        {
            this.Contrato_ImpuestoServicio = new HashSet<Contrato_ImpuestoServicio>();
        }
    
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_ImpuestoServicio> Contrato_ImpuestoServicio { get; set; }
    }
}