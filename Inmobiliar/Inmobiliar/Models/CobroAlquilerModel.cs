using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Emum;
using InmBLL.Entities;
using System.Web.Mvc;

namespace Inmobiliar.Models
{
    public class CobroAlquilerModel
    {
        public IEnumerable<SelectListItem> Periodos 
        { 
            get
            {
                var a = new List<PeriodosAdeudados>();
                a.Add(new PeriodosAdeudados() { MesAño = DateTime.Now, Detalle = Enum.GetName(typeof(Meses), DateTime.Now.Month) + ' ' + DateTime.Now.Year });
                var fe = DateTime.Now;
                fe = fe.AddMonths(1);
                a.Add(new PeriodosAdeudados() { MesAño = fe, Detalle = Enum.GetName(typeof(Meses), fe.Month) + ' ' + DateTime.Now.Year });
                fe = fe.AddMonths(1);
                a.Add(new PeriodosAdeudados() { MesAño = fe, Detalle = Enum.GetName(typeof(Meses), fe.Month) + ' ' + DateTime.Now.Year });
                fe = fe.AddMonths(1);
                a.Add(new PeriodosAdeudados() { MesAño = fe, Detalle = Enum.GetName(typeof(Meses), fe.Month) + ' ' + DateTime.Now.Year });
                fe = fe.AddMonths(1);
                a.Add(new PeriodosAdeudados() { MesAño = fe, Detalle = Enum.GetName(typeof(Meses), fe.Month) + ' ' + DateTime.Now.Year });
                var s = a.Select(x => new SelectListItem
                    {
                        Value = x.MesAño.ToShortDateString(),
                        Text = x.Detalle
                    });
                return s;
            }
        }

        public List<Nota> Notas
        {
            get 
            {
                var b = new List<Nota>();
                b.Add(new Nota(){id = 1, fecha = "06/03/2017", detalle="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."});
                b.Add(new Nota() { id = 2, fecha = "06/04/2017", detalle = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
                b.Add(new Nota() { id = 3, fecha = "06/05/2017", detalle = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
                return b;
            }
        }

        public Contratos Contrato { get; set; }

        public string NuevaNota { get; set; }

        public int id { get; set; }

        public PagoAlquiler Pago { get; set; }

        public string ImpuestosPresentados { get; set; }

        public string sPeriodo { get; set; }

        public CobroAlquilerModel()
        {
            this.Contrato = new Contratos();
            this.Pago = new PagoAlquiler();
            this.Contrato.ListaImpuestos = new List<TipoImpuestosServicios>();            
        }
    }

    public class PeriodosAdeudados
    {
        public DateTime MesAño {get; set;}
        public string Detalle {get; set;}
    }

    public class Nota
    {
        public int id { get; set; }
        public string fecha {get; set;}
        public string detalle {get; set;}

    }
}