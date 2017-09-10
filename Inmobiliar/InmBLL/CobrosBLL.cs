using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL
{
    public class CobrosBLL : IGenericBLL<PagoAlquiler>
    {
        private InmDAL.Contracts.IGenericDAL<InmDAL.Pagos> genericDal;

        public CobrosBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.Pagos>();
        }

        public bool Add(PagoAlquiler entity)
        {
            var data = new InmDAL.Pagos
            {
                ContratoId = entity.ContratoId,
                FechaPago = entity.FechaPago,
                InquilinoId = entity.InquilinoId,
                MontoTotal = entity.MontoTotal,
                Observaciones = entity.Observaciones,
                Periodo = entity.Periodo,
                PropiedadId = entity.PropiedadId
            };
            var response = genericDal.Add(data);
            if (response != null)
                return true;
            return false;
        }

        public bool Delete(PagoAlquiler entity)
        {
            var data = new InmDAL.Pagos();
            var response = genericDal.Delete(data);
            if (response != null)
                return true;
            return false;
        }

        public bool Update(PagoAlquiler entity)
        {
            var data = new InmDAL.Pagos();
            var response = genericDal.Update(data);
            if (response != null)
                return true;
            return false;
        }

        public List<PagoAlquiler> GetAll()
        {
            var response = genericDal.GetAll();
            var listPago = new List<PagoAlquiler>();
            foreach (var pago in listPago)
            {
                var data = new PagoAlquiler
                {
                    ContratoId = pago.ContratoId ,
                    FechaPago = pago.FechaPago,
                    InquilinoId = pago.InquilinoId,
                    MontoTotal = pago.MontoTotal,
                    Observaciones = pago.Observaciones,
                    Periodo = pago.Periodo,
                    PropiedadId = pago.PropiedadId
                };
                listPago.Add(data);
            }
            return listPago;
        }

        public PagoAlquiler GetById(string id)
        {
            var pago = new PagoAlquiler();
            if (!string.IsNullOrEmpty(id))
            {
                var response = genericDal.GetById(id);
                if (response != null)
                {
                    pago = new PagoAlquiler
                    {
                        ContratoId = pago.ContratoId,
                        FechaPago = pago.FechaPago,
                        InquilinoId = pago.InquilinoId,
                        MontoTotal = pago.MontoTotal,
                        Observaciones = pago.Observaciones,
                        Periodo = pago.Periodo,
                        PropiedadId = pago.PropiedadId
                    };
                }
            }
            return pago;
        }

        public List<PagoAlquiler> GetByContrato(string contratoId)
        {
 
        }
    }
}
