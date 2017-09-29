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
        public ActionResult Create(CobroAlquilerModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {



                    ViewBag.Imprimir = true;
                    ViewBag.TipoMsj = "Success";
                    ViewBag.Message = "El cobro se registro con Exito!!!";

                    return View(collection);
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
        [PermisoAtribute(Rol = RolesPermisos.Rol_Anular_Cobro)]
        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                ViewBag.Reimprimir = true;
            }
            return View();
        }

        // POST: CobroAlquiler/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        public JsonResult GetCobro(string fecha, string idContrato)
        {
            var contratoList = new ContratosBLL();
            var contrato = contratoList.ObtenerMonto(fecha, idContrato);
            
           



            return Json(contrato, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(CobroAlquilerModel collection)
        {
            try
            {            
                var cobbll = new CobrosBLL();
                collection.Pago = cobbll.GetById(collection.Pago.PagoId.ToString());
                var bCobro = cobbll.Delete(collection.Pago);
                if (bCobro)
                {
                    ViewBag.TipoMsj = "Success";
                    ViewBag.Message = "La anulación de cobro se realizó con exito. !!!";
                    return View();
                }
                else
                {
                    ViewBag.TipoMsj = "Info";
                    ViewBag.Message = "No pudo realizar la anulación";
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

        [HttpPost]
        public JsonResult GetPago(string idCobro, string idContrato)
        {
            var pagobll = new CobrosBLL();
            var pago = pagobll.GetById(idCobro);
            var newPago = new
            {
                MontoTotal = pago.MontoTotal,
                FechaPago = pago.FechaPago.Value.ToShortDateString()
            };
            return Json(newPago, JsonRequestBehavior.AllowGet);
        }

    }
}
