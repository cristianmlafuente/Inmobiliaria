using AutoMapper;
using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL
{
    public class PersonasBLL
    {
        public List<Personas> GetAllPersons()
        {
            var genericDal = new InmDAL.GenericDAL();
            var response = genericDal.GetAll<InmDAL.Personas>();       
            
            return Mapper.Map<List<InmDAL.Personas>, List<Personas>>(response);
        }
    }
}
