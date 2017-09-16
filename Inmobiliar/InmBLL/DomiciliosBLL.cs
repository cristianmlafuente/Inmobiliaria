using AutoMapper;
using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL
{
    public class DomiciliosBLL : IGenericBLL<Domicilios>
    {
        private InmDAL.Contracts.IGenericDAL<InmDAL.Domicilios> genericDal;

        public DomiciliosBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.Domicilios>();
        }

        public int Add(Domicilios entity)
        {
            var entityDAL = new InmDAL.Domicilios { 
            Barrio = entity.Barrio,
            Calle = entity.Calle,
            Ciudad = entity.Ciudad,
            CP = entity.CP,
            Dto = entity.Dto,
            Numero = entity.Numero,
            Piso = entity.Piso};
            var response = genericDal.Add(entityDAL);
            if (response != null)
                return response;
            return response;         
        }

        public bool Delete(Domicilios entity)
        {
            var entityDAL = new InmDAL.Domicilios();
            var response = genericDal.Delete(entityDAL);
            if (response != null)
                return true;
            return false;      
        }

        public bool Update(Domicilios entity)
        {
            var entityDAL = new InmDAL.Domicilios();
            var response = genericDal.Update(entityDAL);
            if (response != null)
                return true;
            return false;   
        }

        public List<Domicilios> GetAll()
        {
            try
            {
                var response = genericDal.GetAll();

                return Mapper.Map<List<InmDAL.Domicilios>, List<Domicilios>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Domicilios GetById(string id)
        {
            try
            {
                var propie = new Domicilios();
                if (!string.IsNullOrEmpty(id))
                {
                    var response = genericDal.GetById(id);
                    if (response != null)
                        propie = new Domicilios()
                        { 
                            Barrio = response.Barrio,
                            Calle = response.Calle,
                            Ciudad = response.Ciudad,
                            CP = response.CP,
                            DomiciliosId = response.DomiciliosId,
                            Dto = response.Dto,
                            Numero = response.Numero,
                            Piso = response.Piso
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
