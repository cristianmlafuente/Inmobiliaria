using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class Contratos
    {
        public int IdContrato { get; set; }
        public string NroContrato { get; set; }
        public Nullable<int> IdEstate { get; set; }
        public Nullable<int> IdInquilino { get; set; }
        public Nullable<System.DateTime> FechaContrato { get; set; }
        public Nullable<int> PeriodoMeses { get; set; }
        public Nullable<int> Incrementos { get; set; }
        public Nullable<decimal> Porsentaje { get; set; }
        public Nullable<int> IdGarantePropietario { get; set; }
        public Nullable<int> IdGaranteLaboral1 { get; set; }
        public Nullable<int> IdGaranteLaboral2 { get; set; }
        public Nullable<int> IdGatanteLaboral3 { get; set; }
        public Nullable<decimal> MontoInicialAlquiler { get; set; }

        public virtual Personas Personas { get; set; }
        public virtual Propiedades Propiedades { get; set; }
    }
}
