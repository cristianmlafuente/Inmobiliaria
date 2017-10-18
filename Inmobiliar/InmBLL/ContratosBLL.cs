using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmBLL.Entities;
using Microsoft.VisualBasic;

namespace InmBLL
{
    public class ContratosBLL : IGenericBLL<Contratos>
    {
        private InmDAL.Contracts.IGenericDAL<InmDAL.Contratos> genericDal;

        public ContratosBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.Contratos>();
        }

        public int Add(Contratos entity)
        {
            try
            {
                var entityDAL = new InmDAL.Contratos();
                entityDAL.FechaContrato = entity.FechaContrato;
                entityDAL.IdEstate = 0;
                entityDAL.IdGaranteLaboral1 = entity.IdGaranteLaboral1;
                entityDAL.IdGaranteLaboral2 = entity.IdGaranteLaboral2;
                entityDAL.IdGaranteLaboral3 = entity.IdGaranteLaboral3;
                entityDAL.IdGarantePropietario = entity.IdGarantePropietario;
                entityDAL.IdPropietario = entity.PropietarioId;
                entityDAL.InquilinoId = entity.InquilinoId;
                entityDAL.MontoInicialAlquiler = entity.MontoInicialAlquiler;
                entityDAL.NroContrato = entity.NroContrato;
                entityDAL.PeriodoMeses = entity.PeriodoMeses;
                entityDAL.PorcentajeIncremento = entity.PorcentajeIncremento;
                entityDAL.PorcentajeInmobiliaria = entity.PorcentajeInmobiliaria;            
                entityDAL.PropiedadesId = entity.PropiedadesId;
                var response = genericDal.Add(entityDAL);
                var listimpu = new List<InmDAL.Contrato_ImpuestoServicio>();
                var newGenericDal = new InmDAL.GenericDAL<InmDAL.Contrato_ImpuestoServicio>();
                foreach (var item in entity.ListaImpuestos)
                {
                    newGenericDal.Add(new InmDAL.Contrato_ImpuestoServicio() { CodImpuesto = item.Codigo, ContratosId = response, FechaAlta = DateTime.Now });                    
                }                                               
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(Contratos entity)
        {
            var entityDAL = new InmDAL.Contratos();
            entityDAL.ContratosId = entity.ContratosId;
            var response = genericDal.Delete(entityDAL);
            return response;
        }

        public bool Update(Contratos entity)
        {
            try
            {
                var entityDAL = new InmDAL.Contratos();
                entityDAL.FechaContrato = entity.FechaContrato;
                entityDAL.IdEstate = entity.IdEstate;
                entityDAL.IdGaranteLaboral1 = entity.IdGaranteLaboral1;
                entityDAL.IdGaranteLaboral2 = entity.IdGaranteLaboral2;
                entityDAL.IdGaranteLaboral3 = entity.IdGaranteLaboral3;
                entityDAL.IdGarantePropietario = entity.IdGarantePropietario;
                entityDAL.IdPropietario = entity.PropietarioId;
                entityDAL.InquilinoId = entity.InquilinoId;
                entityDAL.MontoInicialAlquiler = entity.MontoInicialAlquiler;
                entityDAL.NroContrato = entity.NroContrato;
                entityDAL.PeriodoMeses = entity.PeriodoMeses;
                entityDAL.PorcentajeIncremento = entity.PorcentajeIncremento;
                entityDAL.PorcentajeInmobiliaria = entity.PorcentajeInmobiliaria;
                var response = genericDal.Update(entityDAL);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Contratos> GetAll()
        {
            try
            {
                var response = genericDal.GetAll();
                var listPropie = new List<Contratos>();
                foreach (var propiedad in response)
                {
                    var data = new Contratos
                    {
                        ContratosId = propiedad.ContratosId,
                        IdEstate = propiedad.IdEstate,
                        FechaContrato = propiedad.FechaContrato,
                        IdGaranteLaboral1 = propiedad.IdGaranteLaboral1,
                        IdGaranteLaboral2 = propiedad.IdGaranteLaboral2,
                        IdGaranteLaboral3 = propiedad.IdGaranteLaboral3,
                        IdGarantePropietario = propiedad.IdGarantePropietario,
                        Incrementos = propiedad.Incrementos,
                        InquilinoId = propiedad.InquilinoId,
                        MontoInicialAlquiler = propiedad.MontoInicialAlquiler,
                        NroContrato = propiedad.NroContrato,
                        PeriodoMeses = propiedad.PeriodoMeses,
                        PorcentajeIncremento = propiedad.PorcentajeIncremento,
                        PorcentajeInmobiliaria = propiedad.PorcentajeInmobiliaria,
                        PropiedadesId = propiedad.PropiedadesId,
                        PropietarioId = propiedad.IdPropietario                        
                    };
                    listPropie.Add(data);
                }

                return listPropie;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Contratos GetById(string id)
        {
            try
            {
                var propie = new Contratos();
                if (!string.IsNullOrEmpty(id))
                {
                    var response = genericDal.GetById(id);
                    if (response != null)
                        propie = new Contratos
                        {
                            ContratosId = response.ContratosId,
                            FechaContrato = response.FechaContrato,
                            IdEstate = response.IdEstate,
                            IdGaranteLaboral1 = response.IdGaranteLaboral1,
                            IdGaranteLaboral2 = response.IdGaranteLaboral2,
                            IdGaranteLaboral3 = response.IdGaranteLaboral3,
                            IdGarantePropietario = response.IdGarantePropietario,
                            Incrementos = response.Incrementos,
                            InquilinoId = response.InquilinoId,
                            MontoInicialAlquiler = response.MontoInicialAlquiler,
                            NroContrato = response.NroContrato,
                            PeriodoMeses = response.PeriodoMeses,
                            PorcentajeIncremento = response.PorcentajeIncremento,
                            PorcentajeInmobiliaria = response.PorcentajeInmobiliaria,
                            PropiedadesId = response.PropiedadesId,
                            PropietarioId = response.IdPropietario

                        };
                }
                return propie;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ObtenerMonto(string fecha, string idContrato)
        {
            try
            {
                //fecha "20170808" string 
                //fecha contrato {08/07/2017 12:00:00 a.m.} datetime
                // incrementos 3

                var contrato = this.GetById(idContrato);
                var a = contrato.ListaImpuestos;
                var listcobros = new CobrosBLL().GetByContrato(idContrato);
                var periodo = DateTime.Now.ToString("dd/mm/YYYY");
                if (listcobros.Any(xx => xx.Periodo.Value.ToString() == periodo))
                    throw new Exception("Ya existe cobro para el periodo Ingresado.");
                decimal Monto = contrato.MontoInicialAlquiler.Value;
                int incrementos = contrato.Incrementos.Value;
                decimal porsIncre = contrato.PorcentajeIncremento.Value;

                var calculoPeriodo = contrato.PeriodoMeses / (incrementos + 1);

                Dictionary<string, DateTime> dictionary = new Dictionary<string, DateTime>();
                for (int i = 1; i < (incrementos+1); i++)
                {
                    int addMonth = ((int)calculoPeriodo * i);
                    var contratofecha =  contrato.FechaContrato.Value.AddMonths(addMonth);
                    dictionary.Add(i.ToString(), contratofecha);
                }
                DateTime dateFilter = DateTime.ParseExact(fecha, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                foreach (var item in dictionary)
                {
                    var result = DateTime.Compare(item.Value, dateFilter);
                    var key = Convert.ToDecimal(item.Key);
                    if (result == 0 || result == 1)
                    {
                        if (key == 0)
                        {
                            return Monto.ToString();
                        }
                        var montoNew = (Monto * (((key-1) * porsIncre)/100));

                        return (Monto + Monto).ToString();
                    }
 
                }
                    return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    }
}
