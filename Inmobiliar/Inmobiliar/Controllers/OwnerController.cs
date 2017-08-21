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
    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult Index()
        {
            return View();
        }

        // GET: Owner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Owner/Create
        [PermisoAtribute(Rol = RolesPermisos.Rol_Alta_Clientes)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        public ActionResult Create(PersonasModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
 
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owner/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Owner/Edit/5
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

        // GET: Owner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Owner/Delete/5
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
        public JsonResult GetUser(string nombre)
        {
            //var owner = new PersonasModel();
            var personsList = new PersonasBLL();
            var listPersons = personsList.GetAll();
            //Type type = listPersons..GetType();
            var personViews = Mapper.Map<List<Personas>, List<PersonasModel>>(listPersons);

            var CityName = (from person in personViews
                            where person.Nombre.StartsWith(nombre)
                            select new
                            {
                                nombre = person.Nombre,
                                apellido = person.Apellido,
                                idpeople = person.IdPeople
                            }).ToList();
            return Json(CityName, JsonRequestBehavior.AllowGet);  
        }
    }
}
