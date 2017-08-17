using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class PagoAlquiler_Detalle
    {
        public int idTipo { get; set; }
        public int idPago { get; set; }
        public decimal Monto { get; set; }
        public DateTime PeriodoPago { get; set; }
    }
}
