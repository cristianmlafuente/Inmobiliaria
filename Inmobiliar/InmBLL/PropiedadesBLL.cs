using AutoMapper;
using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL
{
    public class PropiedadesBLL : IGenericBLL<Propiedades>
    {
        private InmDAL.GenericDAL genericDal;
        public PropiedadesBLL()
        {
            genericDal = new InmDAL.GenericDAL();
        }

        public bool Add(Propiedades entity)
        {
            var entityDAL = new InmDAL.Propiedades();
            var response = genericDal.Add<InmDAL.Propiedades>(entityDAL);
            if (response != null)
                return true;
            return false;         
        }

        public bool Delete(Propiedades entity)
        {
            var entityDAL = new InmDAL.Propiedades();
            var response = genericDal.Delete<InmDAL.Propiedades>(entityDAL);
            if (response != null)
                return true;
            return false;      
        }

        public bool Update(Propiedades entity)
        {
            var entityDAL = new InmDAL.Propiedades();
            var response = genericDal.Update<InmDAL.Propiedades>(entityDAL);
            if (response != null)
                return true;
            return false;   
        }

        public List<Propiedades> GetAll()
        {
            try
            {
                var response = genericDal.GetAll<InmDAL.Propiedades>();
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
                    var response = genericDal.GetById<InmDAL.Propiedades>(id);
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
