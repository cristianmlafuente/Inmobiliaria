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
        public int InquilinoId { get; set; }
        public int PropiedadId { get; set; }
        public int ContratoId { get; set; }
        private Propiedades _propiedad;
        private Personas _inquilino;
        private Contratos _contrato;
        public decimal MontoTotal { get; set; }

        public Propiedades Propiedad
        {
            get
            {        
                if (_propiedad == null)
                {
                    if (PropiedadId != 0)
                    {
                        var dalpropiedad = new InmDAL.GenericDAL();
                        var response = dalpropiedad.GetById<InmDAL.Propiedades>(PropiedadId.ToString());
                        return _propiedad = AutoMapper.Mapper.Map<InmDAL.Propiedades, Propiedades>(response);
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
                        var dalinquilino = new InmDAL.GenericDAL();
                        var response = dalinquilino.GetById<InmDAL.Personas>(PropiedadId.ToString());
                        return _inquilino = AutoMapper.Mapper.Map<InmDAL.Personas, Personas>(response);
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
                        var dalinquilino = new InmDAL.GenericDAL();
                        var response = dalinquilino.GetById<InmDAL.Contratos>(ContratoId.ToString());
                        return _contrato = AutoMapper.Mapper.Map<InmDAL.Contratos, Contratos>(response);
                    }
                    else
                        return null;
                }
                else
                    return _contrato;
            }
        }

        public List<PagoAlquiler_Detalle> DetallePago { get; set; }

        public string Observaciones { get; set; }

    }
}
