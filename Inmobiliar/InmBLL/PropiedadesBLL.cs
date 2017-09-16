using AutoMapper;
using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmDAL.Contracts;

namespace InmBLL
{
    public class PropiedadesBLL : IGenericBLL<Propiedades>
    {

        private InmDAL.Contracts.IGenericDAL<InmDAL.Propiedades> genericDal;

        public PropiedadesBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.Propiedades>();
        }

        public int Add(Propiedades entity)
        {
            var entityDAL = new InmDAL.Propiedades
            {
                DomiciliosId = entity.DomiciliosId,
                NomenclaturaCatastral = entity.NomenclaturaCatastral,
                NroContratoEpec = entity.NroContratoEpec,
                PersonasId = entity.PersonasId,
                UnidadFacturacion = entity.UnidadFacturacion,
                NroFactura = entity.NroFactura
            };
            var response = genericDal.Add(entityDAL);

            return response;
        }

        public bool Delete(Propiedades entity)
        {
            var entityDAL = new InmDAL.Propiedades();
            var response = genericDal.Delete(entityDAL);
            return response;
        }

        public bool Update(Propiedades entity)
        {
            var entityDAL = new InmDAL.Propiedades();
            var response = genericDal.Update(entityDAL);
            return response;
        }

        public List<Propiedades> GetAll()
        {
            try
            {
                var response = genericDal.GetAll();
                var listPropie = new List<Propiedades>();
                foreach (var propiedad in response)
                {
                    var data = new Propiedades
                    {
                        DomiciliosId = propiedad.DomiciliosId,
                        IdAdmConsorcio = propiedad.IdAdmConsorcio,
                        NomenclaturaCatastral = propiedad.NomenclaturaCatastral,
                        NroContratoEpec = propiedad.NroContratoEpec,
                        NroFactura = propiedad.NroFactura,
                        NumeroCtaRenta = propiedad.NumeroCtaRenta,
                        PersonasId = propiedad.PersonasId,
                        PropiedadesId = propiedad.PropiedadesId,
                        UnidadFacturacion = propiedad.UnidadFacturacion

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

        public Propiedades GetById(string id)
        {
            try
            {
                var propie = new Propiedades();
                if (!string.IsNullOrEmpty(id))
                {
                    var response = genericDal.GetById(id);
                    if (response != null)
                        propie = new Propiedades
                        {
                            DomiciliosId = response.DomiciliosId,
                            IdAdmConsorcio = response.IdAdmConsorcio,
                            NomenclaturaCatastral = response.NomenclaturaCatastral,
                            NroContratoEpec = response.NroContratoEpec,
                            NroFactura = response.NroFactura,
                            NumeroCtaRenta = response.NumeroCtaRenta,
                            PersonasId = response.PersonasId,
                            PropiedadesId = response.PropiedadesId,
                            UnidadFacturacion = response.UnidadFacturacion

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
