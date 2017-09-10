using AutoMapper;
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
    public class CobroAlquilerController : Controller
    {
        // GET: CobroAlquiler
        public ActionResult Index()
        {
            return View();
        }

        // GET: CobroAlquiler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CobroAlquiler/Create
        [PermisoAtribute(Rol = RolesPermisos.Rol_Cobro_Alquiler)]
        public ActionResult Create()
        {
            var model = new CobroAlquilerModel();            
            return View("Create", model);
        }

        // POST: CobroAlquiler/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CobroAlquiler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CobroAlquiler/Edit/5
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

        // GET: CobroAlquiler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CobroAlquiler/Delete/5
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

        [HttpPost]
        public JsonResult GetInquilino(string nombre)
        {            
            var personsList = new PersonasBLL();
            var listPersons = personsList.GetAll();
            //Type type = listPersons..GetType();
            //var personViews = Mapper.Map<List<Personas>, List<PersonasModel>>(listPersons);

            var CityName = (from person in listPersons
                            where (person.Nombre.Contains(nombre) || person.Apellido.Contains(nombre) || person.DU.Contains(nombre))
                            select new
                            {
                                Nombre = person.Nombre,
                                Apellido = person.Apellido,
                                DU = person.DU != null ? person.DU : "",
                                TelefonoLaboral = person.TelefonoLaboral != null ? person.TelefonoLaboral : "",
                                PersonasId = person.PersonasId                                
                            }).ToList();
            

            return Json(CityName, JsonRequestBehavior.AllowGet);
        }
    
    }
}
