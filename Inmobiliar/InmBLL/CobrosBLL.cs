﻿using InmBLL.Entities;
using InmDAL;
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

        public int Add(PagoAlquiler entity)
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
            return response;
        }

        public bool Delete(PagoAlquiler entity)
        {
            var data = new InmDAL.Pagos
            {
                PagosId = entity.PagoId,
                ContratoId = entity.ContratoId,
                FechaPago = entity.FechaPago,
                InquilinoId = entity.InquilinoId,
                MontoTotal = entity.MontoTotal,
                Observaciones = entity.Observaciones,
                Periodo = entity.Periodo,
                PropiedadId = entity.PropiedadId
            };
            var response = genericDal.Delete(data);
            if (response)
            {
                var newgeneric = new InmDAL.GenericDAL<InmDAL.Pagos_Detalle>();
                foreach (var item in entity.DetallePago)
                {
                    var newdata = new InmDAL.Pagos_Detalle
                    {
                        Pagos_DetalleId = item.Pagos_DetalleId,
                        Monto = item.Monto,
                        PagoId = item.PagoId,
                        PeriodoPago = item.PeriodoPago,
                        TipoId = item.TipoId
                    };
                    newgeneric.Delete(newdata);
                }
            }
            return response;            
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
            foreach (var pago in response)
            {
                var data = new PagoAlquiler
                {
                    PagoId = pago.PagosId,
                    ContratoId = pago.ContratoId ,
                    FechaPago = pago.FechaPago,
                    InquilinoId = pago.InquilinoId,
                    MontoTotal = pago.MontoTotal,
                    Observaciones = pago.Observaciones,
                    Periodo = pago.Periodo,
                    PropiedadId = pago.PropiedadId
                };
                var newgenericDal = new InmDAL.GenericDAL<InmDAL.Pagos_Detalle>();
                var deta = newgenericDal.GetAll();
                var detalleDal = (from detalle in deta
                                  where (detalle.PagoId == data.PagoId)
                                  select new PagoAlquiler_Detalle
                                  {
                                      Pagos_DetalleId = detalle.Pagos_DetalleId,
                                      TipoId = detalle.TipoId,
                                      PagoId = detalle.PagoId,
                                      Monto = detalle.Monto.Value,
                                      PeriodoPago = detalle.PeriodoPago.Value
                                  }).ToList();

                data.DetallePago = detalleDal;
                
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
                        PagoId = response.PagosId,
                        ContratoId = response.ContratoId,
                        FechaPago = response.FechaPago,
                        InquilinoId = response.InquilinoId,
                        MontoTotal = response.MontoTotal,
                        Observaciones = response.Observaciones,
                        Periodo = response.Periodo,
                        PropiedadId = response.PropiedadId
                    };
                    var newgenericDal = new InmDAL.GenericDAL<InmDAL.Pagos_Detalle>();
                    var deta = newgenericDal.GetAll();
                    var detalleDal = (from detalle in deta
                                      where (detalle.PagoId == pago.PagoId)
                                      select new PagoAlquiler_Detalle
                                      {
                                          Pagos_DetalleId = detalle.Pagos_DetalleId,
                                          TipoId = detalle.TipoId,
                                          PagoId = detalle.PagoId,
                                          Monto = detalle.Monto.Value,
                                          PeriodoPago = detalle.PeriodoPago.Value
                                      }).ToList();

                    pago.DetallePago = detalleDal;
                }
            }
            return pago;
        }

        public List<PagoAlquiler> GetByContrato(string contratoId)
        {
            try
            {            
                int contra = int.Parse(contratoId);
                var nuevopago = new PagoAlquiler();
                var a = new List<PagoAlquiler>();
                if (!string.IsNullOrEmpty(contratoId))
                {
                    var response = genericDal.GetAll();
                    if (response != null)
                    {
                        var filtro = response.Where(x => x.ContratoId == contra).ToList();
                        if (filtro != null)
                        {
                            foreach (var pago in filtro)
                            {
                                nuevopago = new PagoAlquiler
                                {
                                    PagoId = pago.PagosId,
                                    ContratoId = pago.ContratoId,
                                    FechaPago = pago.FechaPago,
                                    InquilinoId = pago.InquilinoId,
                                    MontoTotal = pago.MontoTotal,
                                    Observaciones = pago.Observaciones,
                                    Periodo = pago.Periodo,
                                    PropiedadId = pago.PropiedadId
                                };

                                var newgenericDal = new InmDAL.GenericDAL<InmDAL.Pagos_Detalle>();
                                var deta = newgenericDal.GetAll();
                                var detalleDal = (from detalle in deta
                                                  where (detalle.PagoId == nuevopago.PagoId)
                                                  select new PagoAlquiler_Detalle
                                                  {
                                                      Pagos_DetalleId = detalle.Pagos_DetalleId,
                                                      TipoId = detalle.TipoId,
                                                      PagoId = detalle.PagoId,
                                                      Monto = detalle.Monto.Value,
                                                      PeriodoPago = detalle.PeriodoPago.Value
                                                  }).ToList();

                                nuevopago.DetallePago = detalleDal;
                                a.Add(nuevopago);
                            }
                        }
                    }
                }

                return a;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
