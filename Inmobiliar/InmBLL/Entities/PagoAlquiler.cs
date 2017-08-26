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
                        return _propiedad = (getPropiedades(_propiedad.PropiedadesId.ToString()));
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
            InmDAL.Contracts.IGenericDAL<InmDAL.Contratos> genericDal = null;
            var response = genericDal.GetById(id);
            return AutoMapper.Mapper.Map<InmDAL.Contratos, Contratos>(response);
        }
        private Personas getPersonas(string id)
        {
            InmDAL.Contracts.IGenericDAL<InmDAL.Personas> genericDal = null;
            var response = genericDal.GetById(id);
            return AutoMapper.Mapper.Map<InmDAL.Personas, Personas>(response);
        }
        private Propiedades getPropiedades(string id)
        {
            InmDAL.Contracts.IGenericDAL<InmDAL.Propiedades> genericDal = null;
            var response = genericDal.GetById(id);
            return AutoMapper.Mapper.Map<InmDAL.Propiedades, Propiedades>(response);
        }
        public List<PagoAlquiler_Detalle> DetallePago { get; set; }

        public string Observaciones { get; set; }

    }
}
