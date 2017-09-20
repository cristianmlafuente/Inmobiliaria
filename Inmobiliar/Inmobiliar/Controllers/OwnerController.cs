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
        //[PermisoAtribute(Rol = RolesPermisos.Rol_Alta_Clientes)]
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
                    var personasBll = new PersonasBLL();
                    var persona = new Personas
                    {
                        PersonasId = collection.PersonasId,
                        Apellido = collection.Apellido,
                        Nombre = collection.Nombre,
                        Email = collection.Email,
                        DU = collection.DU,
                        Telefono = collection.Telefono,
                        TelefonoLaboral = collection.TelefonoLaboral,
                        Celular = collection.Celular
                    };
                    personasBll.Add(persona);
                    ViewBag.TipoMsj = "Success";
                    ViewBag.Message = "El cliente se registro con Exito!!!";
                    return View();
                }
                else
                {
                    ViewBag.TipoMsj = "Info";
                    ViewBag.Message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    return View(collection);
                }
                
                
            }
            catch (Exception ex)
            {
                ViewBag.TipoMsj = "Error";
                ViewBag.Message = ex.Message;
                return View(collection);
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
            //var personViews = Mapper.Map<List<Personas>, List<PersonasModel>>(listPersons);

            var CityName = (from person in listPersons
                            where (person.Nombre.ToUpper().Contains(nombre.ToUpper()) || person.Apellido.ToUpper().Contains(nombre.ToUpper()) || person.DU.Contains(nombre))
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
