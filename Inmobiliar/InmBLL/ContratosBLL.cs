using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmBLL.Entities;

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
            
                var response = genericDal.Add(entityDAL);

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
    }
}
