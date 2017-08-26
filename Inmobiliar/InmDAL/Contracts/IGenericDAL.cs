using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmDAL.Contracts
{
    public interface IGenericDAL <T>
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        List<T> GetAll();
        T GetById(string id);
    }
}
