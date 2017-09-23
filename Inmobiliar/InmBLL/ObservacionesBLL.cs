using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmBLL.Entities;

namespace InmBLL
{
    public class ObservacionesBLL : IGenericBLL<Observacion>
    {
        private InmDAL.Contracts.IGenericDAL<InmDAL.Observaciones> genericDal;

        public ObservacionesBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.Observaciones>();
        }

        public int Add(Observacion entity)
        {
            try
            {
                var entityDAL = new InmDAL.Observaciones();
                entityDAL.ObservacionId = entity.ObservacionId;
                entityDAL.Descripcion = entity.Descripcion;
                entityDAL.Fecha = entity.Fecha;            
                var response = genericDal.Add(entityDAL);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(Observacion entity)
        {
            try
            {
                var entityDAL = new InmDAL.Observaciones();
                entityDAL.ObservacionId = entity.ObservacionId;
                var response = genericDal.Delete(entityDAL);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(Observacion entity)
        {
            try
            {
                var entityDAL = new InmDAL.Observaciones();
                entityDAL.Descripcion = entity.Descripcion;
                entityDAL.Fecha = entity.Fecha;
                entityDAL.ObservacionId = entity.ObservacionId;
                var response = genericDal.Update(entityDAL);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Observacion> GetAll()
        {
            try
            {
                var response = genericDal.GetAll();
                var listObservacion = new List<Observacion>();
                foreach (var observa in response)
                {
                    var data = new Observacion
                    {
                        ContratosId = int.Parse(observa.ContratosId),
                        ObservacionId = observa.ObservacionId,
                        Descripcion = observa.Descripcion,
                        Fecha = observa.Fecha
                    };
                    listObservacion.Add(data);
                }

                return listObservacion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Observacion GetById(string id)
        {
            try
            {
                var data = new Observacion();
                if (!string.IsNullOrEmpty(id))
                {
                    var response = genericDal.GetById(id);
                    if (response != null)
                        data = new Observacion
                        {
                            ContratosId = int.Parse(response.ContratosId),
                            ObservacionId = response.ObservacionId,
                            Descripcion = response.Descripcion,
                            Fecha = response.Fecha
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
