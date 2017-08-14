﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmDAL;

namespace InmBLL.Entities
{
    public class PagoAlquiler
    {
        public DateTime Periodo { get; set; }
        public DateTime FechaPago { get; set;}
        public int idInquilino { get; set; }
        public int idPropiedad { get; set; }
        private Propiedades _propiedad;
        private Personas _inquilino;

        public Propiedades Propiedad
        {
            get
            {        
                if (_propiedad == null)
                {
                    if (idPropiedad != 0)
                    {
                        var dalpropiedad = new InmDAL.GenericDAL();
                        var response = dalpropiedad.GetById<InmDAL.Propiedades>(idPropiedad.ToString());
                        return _propiedad = AutoMapper.Mapper.Map<InmDAL.Propiedades, Propiedades>(response);
                    }
                    else return null;
                }
                else return _propiedad;
            }
        }

        public Personas Inquilino
        {
            get
            {
                if (_inquilino == null)
                {
                    if (idInquilino != 0)
                    {
                        var dalinquilino = new InmDAL.GenericDAL();
                        var response = dalinquilino.GetById<InmDAL.Personas>(idPropiedad.ToString());
                        return _inquilino = AutoMapper.Mapper.Map<InmDAL.Personas, Personas>(response);
                    }
                    else 
                        return null;
                }
                else
                    return _inquilino;
            }            
        }

    }
}