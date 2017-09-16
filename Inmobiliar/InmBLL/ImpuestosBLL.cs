using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmBLL.Entities;

namespace InmBLL
{
    public class ImpuestosBLL : IGenericBLL<TipoImpuestosServicios>
    {
        private InmDAL.Contracts.IGenericDAL<InmDAL.TiposImpuestosServicios> genericDal;

        public ImpuestosBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.TiposImpuestosServicios>();
        }

        public int Add(TipoImpuestosServicios entity)
        {
            try
            {
                var entityDAL = new InmDAL.TiposImpuestosServicios();
                entityDAL.Codigo = entity.Codigo;
                entityDAL.Descripcion = entity.Descripcion;
                var response = genericDal.Add(entityDAL);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(TipoImpuestosServicios entity)
        {
            try
            {
                var entityDAL = new InmDAL.TiposImpuestosServicios();
                entityDAL.Codigo = entity.Codigo;
                var response = genericDal.Delete(entityDAL);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(TipoImpuestosServicios entity)
        {
            try
            {
                var entityDAL = new InmDAL.TiposImpuestosServicios();
                entityDAL.Codigo = entity.Codigo;
                entityDAL.Descripcion = entity.Descripcion;
                var response = genericDal.Update(entityDAL);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoImpuestosServicios> GetAll()
        {
            try
            {
                var response = genericDal.GetAll();
                var listTipo = new List<TipoImpuestosServicios>();
                foreach (var Tipo in response)
                {
                    var data = new TipoImpuestosServicios
                    {
                        Codigo = Tipo.Codigo,
                        Descripcion = Tipo.Descripcion                                                
                    };
                    listTipo.Add(data);
                }

                return listTipo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public TipoImpuestosServicios GetById(string id)
        {
            try
            {
                var data = new TipoImpuestosServicios();
                if (!string.IsNullOrEmpty(id))
                {
                    var response = genericDal.GetById(id);
                    if (response != null)
                        data = new TipoImpuestosServicios
                        {
                            Codigo = response.Codigo,
                            Descripcion = response.Descripcion     
                        };
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
