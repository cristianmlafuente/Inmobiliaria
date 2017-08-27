using InmBLL;
using Inmobiliar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmBLL.Entities;

namespace Inmobiliar.Controllers
{

    public class ContratosController : Controller
    {
        private IGenericBLL<Propiedades> _PropiedadesBll;

        public ContratosController(IGenericBLL<Propiedades> _genericProp) 
        {
            _PropiedadesBll = _genericProp;
        }
        
        // GET: Contratos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {
            ViewBag.Propietarios = "Propietario";
            ContratosModel model = new ContratosModel();
            return View(model);
        }

        // POST: Contratos/Create
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

        // GET: Contratos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contratos/Edit/5
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

        // GET: Contratos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contratos/Delete/5
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
        public JsonResult GetPropiedad(string prop)
        {
            //var propiedadList = new  PropiedadesBLL();
            var listPropiedad = _PropiedadesBll.GetAll();
                        
            var PropiedadName = (from prope in listPropiedad
                                 where (prope.Domicilio.Calle.Contains(prop) || prope.Domicilio.Barrio.Contains(prop) || prope.Domicilio.Ciudad.Contains(prop) || prope.Domicilio.CP.Contains(prop))
                            select new
                            {
                                Calle = prope.Domicilio.Calle,
                                Numero = prope.Domicilio.Numero,
                                PropiedadId = prope.PropiedadesId,
                                Barrio = prope.Domicilio.Barrio,
                                Piso = prope.Domicilio.Piso,
                                Dto = prope.Domicilio.Dto,
                                CP = prope.Domicilio.CP,
                                Id = prope.Domicilio.DomiciliosId
                            }).ToList();

            return Json(PropiedadName, JsonRequestBehavior.AllowGet);
        }
    }
}
