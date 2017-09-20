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
                if (ModelState.IsValid)
                {

                    ViewBag.TipoMsj = "Success";
                    ViewBag.Message = "El cobro se registro con Exito!!!";
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
        public JsonResult GetCobro(string fecha, string idContrato)
        {
            var contratoList = new ContratosBLL();
            var contrato = contratoList.ObtenerMonto(fecha, idContrato);
            
           



            return Json(contrato, JsonRequestBehavior.AllowGet);
        }
    
    }
}
