using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace InmDAL
{
    public class GenericDAL 
    {
        public List<T> GetAll<T>() where T : class
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                db.Open();
                var sqlQuery = string.Format("SELECT * FROM [{0}]", typeof(T).Name);
                return db.Query<T>(sqlQuery).ToList();
            }
        }
        public T GetById<T>(string id) where T : class
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                db.Open();
                var sqlQuery = string.Format("SELECT * FROM [{0}] WHERE ID=@ID", typeof(T).Name, new { ID = id } );
                return db.QueryFirstOrDefault<T>(sqlQuery);
            }
            using (var context = new ClientesEntities())
            {
                return context.Set<T>().Find(id);
            }
        }
        public T Add<T>(T entity) where T : class
        {
            var propertyContainer = ParseProperties(entity);
            var sql = string.Format("INSERT INTO [{0}] ({1}) VALUES (@{2}) SELECT CAST(scope_identity() AS int)",
                typeof(T).Name,
                string.Join(", ", propertyContainer.ValueNames),
                string.Join(", @", propertyContainer.ValueNames));

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                db.Open();
                var id = db.Query<T>(sql, propertyContainer.ValuePairs, commandType: CommandType.Text).First();
            }

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
        private static PropertyContainer ParseProperties<T>(T obj)
        {
            var propertyContainer = new PropertyContainer();

            var typeName = typeof(T).Name;
            var validKeyNames = new[] { "Id", 
            string.Format("{0}Id", typeName), string.Format("{0}_Id", typeName) };

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                // Skip reference types (but still include string!)
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                    continue;

                // Skip methods without a public setter
                if (property.GetSetMethod() == null)
                    continue;

                // Skip methods specifically ignored
                if (property.IsDefined(typeof(DapperIgnore), false))
                    continue;

                var name = property.Name;
                var value = typeof(T).GetProperty(property.Name).GetValue(obj, null);

                if (property.IsDefined(typeof(DapperKey), false) || validKeyNames.Contains(name))
                {
                    propertyContainer.AddId(name, value);
                }
                else
                {
                    propertyContainer.AddValue(name, value);
                }
            }

            return propertyContainer;
        }
        private class PropertyContainer
        {
            private readonly Dictionary<string, object> _ids;
            private readonly Dictionary<string, object> _values;

            #region Properties

            internal IEnumerable<string> IdNames
            {
                get { return _ids.Keys; }
            }

            internal IEnumerable<string> ValueNames
            {
                get { return _values.Keys; }
            }

            internal IEnumerable<string> AllNames
            {
                get { return _ids.Keys.Union(_values.Keys); }
            }

            internal IDictionary<string, object> IdPairs
            {
                get { return _ids; }
            }

            internal IDictionary<string, object> ValuePairs
            {
                get { return _values; }
            }

            internal IEnumerable<KeyValuePair<string, object>> AllPairs
            {
                get { return _ids.Concat(_values); }
            }

            #endregion

            #region Constructor

            internal PropertyContainer()
            {
                _ids = new Dictionary<string, object>();
                _values = new Dictionary<string, object>();
            }

            #endregion

            #region Methods

            internal void AddId(string name, object value)
            {
                _ids.Add(name, value);
            }

            internal void AddValue(string name, object value)
            {
                _values.Add(name, value);
            }

            #endregion
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class DapperKey : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DapperIgnore : Attribute
    {
    }
}
