using AutoMapper;
using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL
{
    public class PersonasBLL : IGenericBLL<Personas>
    {
        private InmDAL.GenericDAL genericDal;
        public PersonasBLL()
        {
            genericDal = new InmDAL.GenericDAL();
        }

        public bool Add(Personas entity)
        {
            var data = new InmDAL.Personas
            {
                Apellido = entity.Apellido,
                Nombre = entity.Nombre,
                Email = entity.Email,
                DU = entity.DU,
                Telefono = entity.Telefono,
                TelefonoLaboral = entity.TelefonoLaboral,
                Celular = entity.Celular
            };
            var response = genericDal.Add<InmDAL.Personas>(data);
            if (response != null)
                return true;
            return false;
        }

        public bool Delete(Personas entity)
        {
            var data = new InmDAL.Personas();
            var response = genericDal.Delete<InmDAL.Personas>(data);
            if (response != null)
                return true;
            return false;
        }

        public bool Update(Personas entity)
        {
            var data = new InmDAL.Personas();
            var response = genericDal.Update<InmDAL.Personas>(data);
            if (response != null)
                return true;
            return false;
        }


        public List<Personas> GetAll()
        {
            var response = genericDal.GetAll<InmDAL.Personas>();
            var listPerson = new List<Personas>();
            foreach(var person in response)
            {
                var data = new Personas
                {
                    Apellido = person.Apellido,
                    Nombre = person.Nombre,
                    Email = person.Email,
                    DU = person.DU,
                    Telefono = person.Telefono,
                    TelefonoLaboral = person.TelefonoLaboral,
                    Celular = person.Celular,
                    PersonasId = person.PersonasId
                };
                listPerson.Add(data);
            }
            return listPerson;
        }

        public Personas GetById(string id)
        {
            var response = genericDal.GetById<InmDAL.Personas>(id);

            return Mapper.Map<InmDAL.Personas, Personas>(response);
        }
    }
}
