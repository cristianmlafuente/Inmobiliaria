using AutoMapper;
using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL
{
    public class PropiedadesBLL
    {
        public bool add(Propiedades entity)
        {
            var entityDAL = new InmDAL.Propiedades();
            var genericDal = new InmDAL.GenericDAL();
            var response = genericDal.Add<InmDAL.Propiedades>(entityDAL);
            if (response != null)
                return true;
            return false;           
        }
        public Propiedades getbyid(string id)
        {
            var genericDal = new InmDAL.GenericDAL();
            var response = genericDal.GetById<InmDAL.Propiedades>(id);
            return Mapper.Map<InmDAL.Propiedades, Propiedades>(response);
        }
    }
}
