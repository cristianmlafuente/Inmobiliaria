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
            InmDAL.Usuarios oUsuario = new Usuarios();
            oUsuario.UserName = nombreUsuario;
            oUsuario.Pass = Password;

            return true;
        }

    }
}
