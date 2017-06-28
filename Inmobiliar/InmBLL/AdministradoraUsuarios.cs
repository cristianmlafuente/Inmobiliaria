using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmDAL;


namespace InmBLL
{
    public class AdministradoraUsuarios
    {
        public bool LogueoUsuario(string nombreUsuario, string Password)
        {
            
            try
            {
                DALUsuarios dalUsuario = new DALUsuarios();
                return dalUsuario.LogueoUsuario(nombreUsuario, Password);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
               
       }
            
            

    }
}
