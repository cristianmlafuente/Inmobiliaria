using InmDAL;
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
            var PersonasDal = new PersonasDAL();
            return PersonasDal.GetAllPersons();
        }
    }
}
