using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmBLL.Entities;


namespace InmBLL
{
    public class GarantePropietarioBLL : IGenericBLL<GarantePropietario>
    {
        private InmDAL.Contracts.IGenericDAL<InmDAL.GarantePropietario> genericDal;
        public GarantePropietarioBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.GarantePropietario>();
        }

        public int Add(GarantePropietario entity)
        {
            try
            {
                var data = new InmDAL.GarantePropietario
                {
                    DomiciliosId = entity.DomiciliosId,
                    PersonasId = entity.PersonasId,
                    Matricula = entity.Matricula                    
                };
                var response = genericDal.Add(data);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(GarantePropietario entity)
        {
            try
            {
                var data = new InmDAL.GarantePropietario();
                var response = genericDal.Delete(data);
                if (response != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(GarantePropietario entity)
        {
            try
            {
                var data = new InmDAL.GarantePropietario();
                var response = genericDal.Update(data);
                if (response != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<GarantePropietario> GetAll()
        {
            try
            {
                var response = genericDal.GetAll();
                var listPerson = new List<GarantePropietario>();
                foreach (var person in response)
                {
                    var data = new GarantePropietario
                    {
                        DomiciliosId = person.DomiciliosId,
                        PersonasId = person.PersonasId,
                        Matricula = person.Matricula,
                        GarantePropietarioId = person.GarantePropietarioId
                    };
                    listPerson.Add(data);
                }
                return listPerson;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GarantePropietario GetById(string id)
        {
            try
            {
                var person = new GarantePropietario();
                if (!string.IsNullOrEmpty(id))
                {
                    var response = genericDal.GetById(id);
                    if (response != null)
                    {
                        person.DomiciliosId = response.DomiciliosId;
                        person.PersonasId = response.PersonasId;
                        person.Matricula = response.Matricula;
                        person.GarantePropietarioId = response.GarantePropietarioId;                        
                    }
                }
                return person;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
