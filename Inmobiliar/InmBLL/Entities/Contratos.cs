using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmBLL.Entities
{
    public class Contratos
    {
        public int ContratosId { get; set; }
        public string NroContrato { get; set; }
        public Nullable<int> PropiedadesId { get; set; }
        public Nullable<int> InquilinoId { get; set; }
        public Nullable<int> PropietarioId { get; set; }
        public Nullable<System.DateTime> FechaContrato { get; set; }
        public Nullable<int> PeriodoMeses { get; set; }
        public Nullable<int> Incrementos { get; set; }
        public Nullable<decimal> PorcentajeIncremento { get; set; }
        public Nullable<int> IdGarantePropietario { get; set; }
        public Nullable<int> IdGaranteLaboral1 { get; set; }
        public Nullable<int> IdGaranteLaboral2 { get; set; }
        public Nullable<int> IdGaranteLaboral3 { get; set; }
        public Nullable<decimal> MontoInicialAlquiler { get; set; }
        public Nullable<decimal> PorcentajeInmobiliaria { get; set; }

        private Personas _Inquilino;
        private Personas _Propietario;
        private Personas _GaranteLaboral1;
        private Personas _GaranteLaboral2;
        private Personas _GaranteLaboral3;
        private Propiedades _Propiedad;

        public virtual Personas Inquilino { 
            get 
            {
                if (_Inquilino != null)
                    return _Inquilino;
                else
                {
                    if (InquilinoId != 0)
                    {
                        _Inquilino = new PersonasBLL().GetById(InquilinoId.ToString());
                        return _Inquilino;
                    }
                    else
                        return null;
                }
            } 
        }
        public virtual Personas Propietario {
            get
            {
                if (_Propietario != null)
                    return _Propietario;
                else
                {
                    if (InquilinoId != 0)
                    {
                        _Propietario = new PersonasBLL().GetById(PropietarioId.ToString());
                        return _Propietario;
                    }
                    else
                        return null;
                }
            }
        }
        public virtual Personas GaranteLaboral1 {
            get
            {
                if (_GaranteLaboral1 != null)
                    return _GaranteLaboral1;
                else
                {
                    if (IdGaranteLaboral1 != 0)
                    {
                        _GaranteLaboral1 = new PersonasBLL().GetById(IdGaranteLaboral1.ToString());
                        return _GaranteLaboral1;
                    }
                    else
                        return null;
                }
            }
        }
        public virtual Personas GaranteLaboral2
        {
            get
            {
                if (_GaranteLaboral2 != null)
                    return _GaranteLaboral2;
                else
                {
                    if (IdGaranteLaboral2 != 0)
                    {
                        _GaranteLaboral2 = new PersonasBLL().GetById(IdGaranteLaboral2.ToString());
                        return _GaranteLaboral2;
                    }
                    else
                        return null;
                }
            }
        }
        public virtual Personas GaranteLaboral3
        {
            get
            {
                if (_GaranteLaboral3 != null)
                    return _GaranteLaboral3;
                else
                {
                    if (IdGaranteLaboral3 != 0)
                    {
                        _GaranteLaboral3 = new PersonasBLL().GetById(IdGaranteLaboral3.ToString());
                        return _GaranteLaboral3;
                    }
                    else
                        return null;
                }
            }
        }

        public virtual Propiedades Propiedades
        {
            get
            {
                if (_Propiedad != null)
                    return _Propiedad;
                else
                {
                    _Propiedad = new Propiedades();
                    if (PropiedadesId != 0)
                    {
                        _Propiedad = new PropiedadesBLL().GetById(PropiedadesId.ToString());                        
                    }
                    return _Propiedad; 
                }
            }
        }

        
    }
}
