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
        public Nullable<System.DateTime> Periodo { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
        public Nullable<int> InquilinoId { get; set; }
        public Nullable<int> PropiedadId { get; set; }
        public Nullable<int> ContratoId { get; set; }
        private Propiedades _propiedad;
        private Personas _inquilino;
        private Contratos _contrato;
        public Nullable<decimal> MontoTotal { get; set; }

        public Propiedades Propiedad
        {
            get
            {
                if (_propiedad == null)
                {
                    if (PropiedadId != 0)
                    {
                        return _propiedad = (getPropiedades(PropiedadId.ToString()));
                    }
                    else return null;
                }
                else return _propiedad;
            }
        }

        public Personas Inquilino
        {
            get
            {
                if (_inquilino == null)
                {
                    if (InquilinoId != 0)
                    {
                        return _inquilino = getPersonas(InquilinoId.ToString());
                    }
                    else
                        return null;
                }
                else
                    return _inquilino;
            }
        }

        public Contratos Contrato
        {
            get
            {
                if (_contrato == null)
                {
                    if (ContratoId != 0)
                    {
                        return _contrato = getContratos(ContratoId.ToString());
                    }
                    else
                        return null;
                }
                else
                    return _contrato;
            }
        }
        private Contratos getContratos(string id)
        {
            var contraBll = new ContratosBLL();
            return contraBll.GetById(id);            
        }
        private Personas getPersonas(string id)
        {
            var persBLL = new PersonasBLL();
            return persBLL.GetById(id);            
        }
        private Propiedades getPropiedades(string id)
        {
            var propBll = new PropiedadesBLL();
            return propBll.GetById(id);
            
        }
        public List<PagoAlquiler_Detalle> DetallePago { get; set; }

        public string Observaciones { get; set; }

    }
}
