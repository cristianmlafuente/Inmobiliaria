using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class PagoAlquiler_Detalle
    {
        public int Pagos_DetalleId { get; set; }
        public int TipoId { get; set; }
        public int PagoId { get; set; }
        public decimal Monto { get; set; }
        public DateTime PeriodoPago { get; set; }
    }
}
