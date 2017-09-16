using Common.Emum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class Observacion
    {
        public int ObservacionId { get; set; }
        public int ContratosId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public String Descripcion { get; set; }
        public string sFecha { 
            get 
            {
                if (Fecha != null)
                    return Fecha.Value.ToShortDateString();
                else 
                    return "";
            }
        }

    }
}
