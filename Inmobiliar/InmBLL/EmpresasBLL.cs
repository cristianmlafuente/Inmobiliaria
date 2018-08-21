using InmBLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL
{
    public class EmpresasBLL : IGenericBLL<Empresa>
    {
        private InmDAL.Contracts.IGenericDAL<InmDAL.Empresa> genericDal;

        public EmpresasBLL()
        {
            genericDal = new InmDAL.GenericDAL<InmDAL.Empresa>();
        }

        public int Add(Empresa entity)
        {
            var data = new InmDAL.Empresa
            {
                Nombre = entity.Nombre,
                Domicilio = entity.Domicilio,               
            };
            var response = genericDal.Add(data);
            return response;
        }

        public bool Delete(Empresa entity)
        {
            var data = new InmDAL.Empresa
            {
                EmpresaId = entity.EmpresaId                
            };
            var response = genericDal.Delete(data);
            
            return response;
        }

        public bool Update(Empresa entity)
        {
            var data = new InmDAL.Empresa();
            var response = genericDal.Update(data);
            if (response != null)
                return true;
            return false;
        }

        public List<Empresa> GetAll()
        {
            var response = genericDal.GetAll();
            var listPago = new List<Empresa>();
            foreach (var pago in response)
            {
                var data = new Empresa
                {
                    EmpresaId = pago.EmpresaId,
                    Nombre = pago.Nombre,
                    Domicilio = pago.Domicilio
                };
                listPago.Add(data);
            }
            return listPago;
        }

        public Empresa GetById(string id)
        {
            var pago = new Empresa();
            if (!string.IsNullOrEmpty(id))
            {
                var response = genericDal.GetById(id);
                if (response != null)
                {
                    pago = new Empresa
                    {
                        EmpresaId = response.EmpresaId,
                        Nombre = response.Nombre,
                        Domicilio = response.Domicilio
                    };                    
                }
            }
            return pago;
        }        
    }
}
