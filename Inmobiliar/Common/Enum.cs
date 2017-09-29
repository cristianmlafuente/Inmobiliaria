using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Emum
{
    public enum RolesPermisos
    {
        #region Permisos
        Rol_Jefe = 1,
        Rol_Secretaria = 2,
        Rol_Alta_Propiedades = 3,
        Rol_Alta_Clientes = 4,
        Rol_Cobro_Alquiler = 5,
        Rol_AltaContratos = 6,
        Rol_Anular_Cobro = 7,
        Rol_Anular_Contrato = 8,
        #endregion
    }

    public enum Meses
    {
        Enero = 1,
        Febrero = 2,
        Marzo = 3,
        Abril = 4,
        Mayo = 5,
        Junio = 6,
        Julio = 7,
        Agosto = 8,
        Septiembre = 9,
        Octubre = 10,
        Noviembre = 11,
        Diciembre = 12
    }

    public enum TipoImpuestoServicio
    {
        Expensas = 1,
        Rentas = 2,
        Municipalidad = 3,
        Agua = 4,
        Luz = 5,
        Alquiler = 6,
        Seña = 7,
        Comision = 8,
        Informes = 9,
        Timbrado = 10,
        Escribania = 11,
        Otros_Servicios = 12,
        Intereses = 13
    }
}
