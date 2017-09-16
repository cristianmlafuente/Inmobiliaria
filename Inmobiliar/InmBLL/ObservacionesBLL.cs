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

        public bool Add(Observacion entity)
        {
            var entityDAL = new InmDAL.Observaciones();
            var response = genericDal.Add(entityDAL);

            return response;
        }

        public bool Delete(Observacion entity)
        {
            var entityDAL = new InmDAL.Observaciones();
            var response = genericDal.Delete(entityDAL);
            return response;
        }

        public bool Update(Observacion entity)
        {
            var entityDAL = new InmDAL.Observaciones();
            var response = genericDal.Update(entityDAL);
            return response;
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
                        ContratosId = observa.ContratosId,
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
                            ContratosId = response.ContratosId,
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
