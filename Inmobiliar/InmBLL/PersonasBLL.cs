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
        private InmDAL.Contracts.IGenericDAL<InmDAL.Personas> genericDal;
        public PersonasBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.Personas>();
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
            var response = genericDal.Add(data);
            if (response != null)
                return true;
            return false;
        }

        public bool Delete(Personas entity)
        {
            var data = new InmDAL.Personas();
            var response = genericDal.Delete(data);
            if (response != null)
                return true;
            return false;
        }

        public bool Update(Personas entity)
        {
            var data = new InmDAL.Personas();
            var response = genericDal.Update(data);
            if (response != null)
                return true;
            return false;
        }


        public List<Personas> GetAll()
        {
            var response = genericDal.GetAll();
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
            var person = new Personas();
            if (!string.IsNullOrEmpty(id))
            {
                var response = genericDal.GetById(id);
                if (response != null)
                {
                    person.Apellido = response.Apellido;
                    person.Celular = response.Celular;
                    person.DU = response.DU;
                    person.Email = response.Email;
                    person.Nombre = response.Nombre;
                    person.PersonasId = response.PersonasId;
                    person.Telefono = response.Telefono;
                    person.TelefonoLaboral = response.TelefonoLaboral;
                }                              
            }
            return person;
        }
    }
}
