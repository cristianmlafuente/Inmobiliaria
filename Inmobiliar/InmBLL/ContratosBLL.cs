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

        public bool Add(Contratos entity)
        {
            var entityDAL = new InmDAL.Contratos();
            var response = genericDal.Add(entityDAL);

            return response;
        }

        public bool Delete(Contratos entity)
        {
            var entityDAL = new InmDAL.Contratos();
            var response = genericDal.Delete(entityDAL);
            return response;
        }

        public bool Update(Contratos entity)
        {
            var entityDAL = new InmDAL.Contratos();
            var response = genericDal.Update(entityDAL);
            return response;
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
