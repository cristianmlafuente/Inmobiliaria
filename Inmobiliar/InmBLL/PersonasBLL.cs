using AutoMapper;
using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public int Add(Personas entity)
        {
            try
            {
                int response = 0;
                if (!ExisteClienteConDNI(entity.DU))                
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
                    response = genericDal.Add(data);                    
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(Personas entity)
        {
            try
            {
                var data = new InmDAL.Personas();
                data.PersonasId = entity.PersonasId.Value;
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

        public bool Update(Personas entity)
        {
            try
            {
                var data = new InmDAL.Personas() 
                {
                    Apellido = entity.Apellido,
                    Celular = entity.Celular,
                    DU = entity.DU,
                    Email = entity.Email,
                    Nombre = entity.Nombre,
                    PersonasId = entity.PersonasId.Value,
                    Telefono = entity.Telefono,
                    TelefonoLaboral = entity.TelefonoLaboral
                };

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

        public List<Personas> GetAll()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Personas GetById(string id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ExisteClienteConDNI(string dni)
        {
            try
            {
                bool existe = false;
                var personas = this.GetAll();
                string patron = @"[^\w]";
                Regex regex = new Regex(patron);                
                if (personas.Exists(xx => regex.Replace(xx.DU, "") == regex.Replace(dni, "")))
                {
                    var perso = personas.Where(xx => regex.Replace(xx.DU, "") == regex.Replace(dni, "")).ToList()[0];
                    throw new Exception("Existe una persona registrada con el DNI ingresado. Datos: Apellido: " + perso.Apellido + " Nombre: " + perso.Nombre);
                }
                return existe;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
