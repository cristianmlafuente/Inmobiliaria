using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmDAL
{
    public class PersonasDAL
    {
        public List<Personas> GetAllPersons()
        {
            using (var context = new ClientesEntities())
            {
                return context.Set<Personas>().ToList();
            }
        }
    }
}
