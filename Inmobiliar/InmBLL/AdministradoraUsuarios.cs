using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmDAL;
using System.Web;

namespace InmBLL
{
    public class AdministradoraUsuarios
    {
        public Usuarios LogueoUsuario(string nombreUsuario, string Password)
        {
            Usuarios ousu = null;
            try
            {
                DALUsuarios dalUsuario = new DALUsuarios();
                ousu = dalUsuario.LogueoUsuario(nombreUsuario, Password);
                if (ousu != null)
                {
                    ousu.Usuario_Rol = (ICollection<Usuario_Rol>)dalUsuario.RolesUsuario(ousu.IdUser);                                         
                }
                
                return ousu;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
               
       }
            
            

    }
}
