using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class TipoImpuestosServicios
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Pagar { get; set; }
        public bool Selected { get; set; }
    }
}
