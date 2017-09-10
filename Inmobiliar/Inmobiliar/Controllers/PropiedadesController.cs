﻿using AutoMapper;
using Common.Emum;
using InmBLL;
using InmBLL.Entities;
using Inmobiliar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inmobiliar.Controllers
{
    public class PropiedadesController : Controller
    {
        //private InmBLL.IGenericBLL<Propiedades> generic;
        //public PropiedadesController(IGenericBLL<Propiedades> _generic)
        //{
        //    generic = _generic;
        //}
        // GET: Propiedades
        public ActionResult Index()
        {
            return View();
        }

        // GET: Propiedades/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Propiedades/Create
        [PermisoAtribute(Rol = RolesPermisos.Rol_Alta_Propiedades)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propiedades/Create
        [HttpPost]
        public ActionResult Create(PropiedadesModel model)
        {
            try
            {

                var propiedades = new PropiedadesBLL();
                if (ModelState.IsValid)
                {
                    var propiedad = new Propiedades
                    {
                        PersonasId = model.Dueño.PersonasId,
                        Domicilio = new Domicilios { 
                            Barrio = model.domicilio.Barrio,
                            Calle = model.domicilio.Calle,
                            Ciudad = model.domicilio.Ciudad,
                            CP = model.domicilio.CP,
                            Numero = model.domicilio.Numero,
                            Piso = model.domicilio.Piso,
                            Dto = model.domicilio.Dto
                        },
                        NroFactura = model.UnidadFacturacion,
                        
                    };
                    var result = propiedades.Add(propiedad);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Propiedades/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Propiedades/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Propiedades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Propiedades/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
