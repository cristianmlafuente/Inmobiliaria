﻿using System;
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
using InmDAL.Contracts;

namespace InmDAL
{
    public class GenericDAL<T> : IGenericDAL <T>
    {/*
        public List<T> GetAll<T>() where T : class
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AySConexionDesarrollo"].ConnectionString))
                {
                    db.Open();
                    var sqlQuery = string.Format("SELECT * FROM [{0}]", typeof(T).Name);
                    return db.Query<T>(sqlQuery).ToList();
                }
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
            
        }

        public T GetById<T>(string id) where T : class
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AySConexionDesarrollo"].ConnectionString))
                {
                    int i = 0;
                    
                    db.Open();
                    var sqlQuery = string.Format("SELECT * FROM [{0}] WHERE {0}ID = {1}", typeof(T).Name, id);
                    return db.QueryFirstOrDefault<T>(sqlQuery);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public T Add<T>(T entity) where T : class
        {
            try
            {
                var propertyContainer = ParseProperties(entity);
                var sql = string.Format("INSERT INTO [{0}] ({1}) VALUES (@{2}) SELECT CAST(scope_identity() AS int)",
                    typeof(T).Name,
                    string.Join(", ", propertyContainer.ValueNames),
                    string.Join(", @", propertyContainer.ValueNames));

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    db.Open();
                    return db.Query<T>(sql, propertyContainer.ValuePairs, commandType: CommandType.Text).First();
                }

                //using (var context = new ClientesEntities())
                //{
                //    context.Set<T>().Add(entity);
                //    context.SaveChanges();
                //    return entity;

                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public T Delete<T>(T entity) where T : class
        {
            try
            {
                using (var context = new ClientesEntities())
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    context.SaveChanges();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        
        public T Update<T>(T entity) where T : class
        {
            try
            {
                using (var context = new ClientesEntities())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        } * */

        private static PropertyContainer ParseProperties<T>(T obj)
        {
            try
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

                    if (property.PropertyType.IsAbstract)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
     
        public bool Add(T entity)
        {
            try
            {
                var propertyContainer = ParseProperties(entity);
                var sql = string.Format("INSERT INTO [{0}] ({1}) VALUES (@{2}) SELECT CAST(scope_identity() AS int)",
                    typeof(T).Name,
                    string.Join(", ", propertyContainer.ValueNames),
                    string.Join(", @", propertyContainer.ValueNames));

                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    db.Open();
                    var response = db.Query<T>(sql, propertyContainer.ValuePairs, commandType: CommandType.Text).First();
                    if (response != null)
                        return true;
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AySConexionDesarrollo"].ConnectionString))
                {
                    db.Open();
                    var sqlQuery = string.Format("SELECT * FROM [{0}]", typeof(T).Name);
                    return db.Query<T>(sqlQuery).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetById(string id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["AySConexionDesarrollo"].ConnectionString))
                {
                    int i = 0;

                    db.Open();
                    var sqlQuery = string.Format("SELECT * FROM [{0}] WHERE {0}ID = {1}", typeof(T).Name, id);
                    return db.QueryFirstOrDefault<T>(sqlQuery);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
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
