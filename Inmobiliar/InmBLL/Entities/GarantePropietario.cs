using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class GarantePropietario
    {
        public Nullable<int> GarantePropietarioId { get; set; }
        public Nullable<int> PersonasId { get; set; }
        public Nullable<int> DomiciliosId { get; set; }
        public Nullable<int> Matricula { get; set; }

        private Personas Perso;
        private Domicilios Domi;

        public Personas DatosPersona 
        {
            get
            {
                if (Perso == null)
                {
                    Perso = new Personas();
                    Perso = new PersonasBLL().GetById(PersonasId.ToString());
                }
                return Perso;            
            }
            set 
            {
                Perso = value;
            }
        }
        public Domicilios Domicilio
        {
            get 
            {
                if (Domi == null)
                {
                    Domi = new Domicilios();
                    Domi = new DomiciliosBLL().GetById(DomiciliosId.ToString());
                }
                return Domi;
            }
            set 
            {
                Domi = value;
            }
        }
    }
}
