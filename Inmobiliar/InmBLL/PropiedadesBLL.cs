﻿using AutoMapper;
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
            var response = genericDal.GetAll<InmDAL.Propiedades>();
            return Mapper.Map<List<InmDAL.Propiedades>, List<Propiedades>>(response);
        }

        public Propiedades GetById(string id)
        {
            var response = genericDal.GetById<InmDAL.Propiedades>(id);
            return Mapper.Map<InmDAL.Propiedades, Propiedades>(response);
        }
    }
}
