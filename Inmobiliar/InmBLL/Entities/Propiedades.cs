using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class Propiedades
    {
        public int PropiedadesId { get; set; }
        public Nullable<int> DomiciliosId { get; set; }
        public Nullable<int> PersonasId { get; set; }
        public Nullable<int> Propiedad { get; set; }
        public string NomenclaturaCatastral { get; set; }
        public string NumeroCtaRenta { get; set; }
        public Nullable<int> IdAdmConsorcio { get; set; }
        public Nullable<int> UnidadFacturacion { get; set; }
        public Nullable<int> NroFactura { get; set; }
        public Nullable<int> NroContratoEpec { get; set; }

        public virtual Domicilios Domicilios { get; set; }
        public virtual Personas Personas { get; set; }
    }
}
