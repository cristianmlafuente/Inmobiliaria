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
        private Domicilios _domicilio { get; set; }
        private Personas _personas { get; set; }

        public Domicilios Domicilio {
            get {
                if (_domicilio != null)
                    return _domicilio;
                else
                {
                    _domicilio = new Domicilios();
                    if (DomiciliosId != 0)
                    {
                        _domicilio = new DomiciliosBLL().GetById(DomiciliosId.ToString());
                    }
                    return _domicilio;
                }
            }
            set { }
        }
        public Personas Personas {
            get
            {
                if (_personas != null)
                    return _personas;
                else
                {
                    if (PersonasId != 0)
                    {
                        _personas = new PersonasBLL().GetById(PersonasId.ToString());
                        return _personas;
                    }
                    else
                        return null;
                }
            } 
        }
    }
}
