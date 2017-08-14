using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmDAL;

namespace InmBLL.Entities
{
    public class PagoAlquiler
    {
        public DateTime Periodo { get; set; }
        public DateTime FechaPago { get; set;}
        public int idInquilino { get; set; }
        public int idPropiedad { get; set; }
        private InmDAL.Propiedades _propiedad;
        private InmDAL.Personas _inquilino;

        public ReadOnly Propiedades Propiedad
        {
            get
            {        
                if (_propiedad == null)
                {
                    if (idPropiedad != 0)
                    {
                        _propiedad = new InmDAL.Propiedades();
                        return _propiedad;
                    }
                    else return null;
                }
                else return _propiedad;
            }
        }

        public ReadOnly InmDAL.Personas Inquilino
        {
            get
            {
                if (_inquilino == null)
                {
                    if (idInquilino != 0)
                    {
                        _inquilino = new InmDAL.Personas();
                        return _inquilino;
                    }
                }
                else
                    return _inquilino;
            }            
        }

    }
}
