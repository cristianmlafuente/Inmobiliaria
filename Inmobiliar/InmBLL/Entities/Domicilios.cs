using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class Domicilios
    {
        public int DomiciliosId { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string CP { get; set; }
        public Nullable<int> Piso { get; set; }
        public string Dto { get; set; }
        public Nullable<int> Numero { get; set; }
        public string Barrio { get; set; }
    }
}
