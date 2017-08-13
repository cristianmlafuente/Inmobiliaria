using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmDAL
{
    public class PersonasDAL
    {
        public List<T> GetAll<T>() where T : class
        {
            using (var context = new ClientesEntities())
            {
                return context.Set<T>().ToList();
            }
        }
        public List<T> GetById<T>(string id) where T : class
        {
            using (var context = new ClientesEntities())
            {
                return context.Set<T>().ToList();
            }
        }
        public T Add<T>(T entity) where T : class
        {
            using (var context = new ClientesEntities())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                return entity;
                
            }
        }
        public T Delete<T>(T entity) where T : class
        {
            using (var context = new ClientesEntities())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
                return entity;
            }
        }
        public T Update<T>(T entity) where T : class
        {
            using (var context = new ClientesEntities())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
