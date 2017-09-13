using Common.Emum;
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

        public string sPropietarioId
        {
            get
            {
                if (PropietarioId != null && PropietarioId != 0)
                    return PropietarioId.ToString();
                else
                    return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    PropietarioId = null;
                else
                    PropietarioId = int.Parse(value);
            }
        }
        public string sPropiedadId
        {
            get
            {
                if (PropiedadesId != null && PropiedadesId != 0)
                    return PropiedadesId.ToString();
                else
                    return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    PropiedadesId = null;
                else
                    PropiedadesId = int.Parse(value);
            }
        }
        public string sInquilinoId
        {
            get
            {
                if (InquilinoId != null && InquilinoId != 0)
                    return InquilinoId.ToString();
                else
                    return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    InquilinoId = null;
                else
                    InquilinoId = int.Parse(value);
            }
        }
        public string sIdGaranteLaboral1
        {
            get
            {
                if (IdGaranteLaboral1 != null && IdGaranteLaboral1 != 0)
                    return IdGaranteLaboral1.ToString();
                else
                    return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    IdGaranteLaboral1 = null;
                else
                    IdGaranteLaboral1 = int.Parse(value);
            }
        }
        public string sIdGaranteLaboral2
        {
            get
            {
                if (IdGaranteLaboral2 != null && IdGaranteLaboral2 != 0)
                    return IdGaranteLaboral2.ToString();
                else
                    return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    IdGaranteLaboral2 = null;
                else
                    IdGaranteLaboral2 = int.Parse(value);
            }
        }
        public string sIdGaranteLaboral3
        {
            get
            {
                if (IdGaranteLaboral3 != null && IdGaranteLaboral3 != 0)
                    return IdGaranteLaboral3.ToString();
                else
                    return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    IdGaranteLaboral3 = null;
                else
                    IdGaranteLaboral3 = int.Parse(value);
            }
        }
        public string sIdContrato
        {
            get
            {
                if (ContratosId != null && ContratosId != 0)
                    return ContratosId.ToString();
                else
                    return "";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    ContratosId = 0;
                else
                    ContratosId = int.Parse(value);
            }
        }
   

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

        public List<PeriodosAdeudados> PeriodosAdeudados 
        {
            get 
            {
                var a = new List<PeriodosAdeudados>();
                a = GenerarPeriodos();
                if (ContratosId != 0)
                {
                    var PeriodosCobrados = new CobrosBLL().GetByContrato(ContratosId.ToString());
                    foreach (var item in PeriodosCobrados)
                    {
                        if (a.Any(x => x.MesAño.Month == item.Periodo.Value.Month && x.MesAño.Year == item.Periodo.Value.Year))
                            a.RemoveAll(x => x.MesAño.Month == item.Periodo.Value.Month && x.MesAño.Year == item.Periodo.Value.Year);
                    }
                    //return PeriodosCobrados;
                }
                return a;
            }
            
        }

        public List<PeriodosAdeudados> GenerarPeriodos()
        {
            var response = new List<PeriodosAdeudados>();
            for (int i = 0; i < PeriodoMeses; i++)
            {
                var per = new PeriodosAdeudados();
                per.MesAño = FechaContrato.Value.AddMonths(i);
                per.Detalle = Enum.GetName(typeof(Meses), per.MesAño.Month) + ' ' + per.MesAño.Year;
                per.sMesAño = per.MesAño.Day.ToString().PadLeft(2, '0') + per.MesAño.Month.ToString().PadLeft(2, '0') + per.MesAño.Year;
                response.Add(per);
            }

            return response;
        }
    }

    public class PeriodosAdeudados
    {
        public DateTime MesAño {get; set;}
        public string Detalle {get; set;}
        public string sMesAño { get; set; }
    }

    
}
