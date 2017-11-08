using AutoMapper;
using Common.Emum;
using InmBLL;
using InmBLL.Entities;
using Inmobiliar.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                //if (ModelState.IsValid)
                //{
                    var pagoentity  = new PagoAlquiler();
                    pagoentity.ContratoId = int.Parse(collection.Contrato.sIdContrato);
                    pagoentity.FechaPago = DateTime.Now;
                    pagoentity.InquilinoId = int.Parse(collection.Contrato.sInquilinoId);
                    pagoentity.PropiedadId = int.Parse(collection.Contrato.sPropiedadId);
                    pagoentity.MontoTotal = collection.Pago.MontoTotal;
                    pagoentity.Observaciones = collection.Pago.Observaciones;
                    pagoentity.Periodo = DateTime.Parse(collection.sPeriodo.Substring(6, 2) + "/" + collection.sPeriodo.Substring(4, 2) + "/" + collection.sPeriodo.Substring(0, 4));
                    pagoentity.Observaciones = collection.Pago.Observaciones;    
                    var detallePago = new PagoAlquiler_Detalle();
                    detallePago.Monto = collection.Pago.MontoTotal.Value;
                    detallePago.TipoId = 6;
                    detallePago.PeriodoPago = pagoentity.Periodo.Value;
                    pagoentity.DetallePago = new List<PagoAlquiler_Detalle>();

                    pagoentity.DetallePago.Add(detallePago);
                    var pagoBll = new CobrosBLL();
                    pagoBll.Add(pagoentity);


                    ViewBag.Imprimir = true;
                    ViewBag.TipoMsj = "Success";
                    ViewBag.Message = "El cobro se registro con Exito!!!";

                    return View(collection);
                //}
                //else
                //{
                //    ViewBag.TipoMsj = "Info";
                //    ViewBag.Message = string.Join("; ", ModelState.Values
                //                        .SelectMany(x => x.Errors)
                //                        .Select(x => x.ErrorMessage));
                //    return View(collection);
                //}
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
                var bCobro = false;
                var cobbll = new CobrosBLL();
                collection.Pago = cobbll.GetById(collection.Pago.PagoId.ToString());
                if (true)
                {
                    var a = "";
                    var pagobll = new CobrosBLL();
                    //var pago = pagobll.GetById(Pago);
                    var admAlqui = new AdministradoraAlquileres();
                    //byte[] bytes = admAlqui.GenerarRecibo(pago);
                    byte[] bytes = admAlqui.GenerarRecibo(collection.Pago);

                    //var pdf = new string(resultFactura.ArchivoArray.Select(Convert.ToChar).ToArray());
                    //byte[] bytes = pdf.Select(Convert.ToByte).ToArray();

                    var streamDownload = new MemoryStream(bytes);
                    streamDownload.Flush();
                    streamDownload.Position = 0;
                    return File(streamDownload, "application/xls", "Comprobante" + DateTime.Now.ToShortDateString() + "_" + collection.Pago.PagoId.ToString() + ".xlsx");
                }
                else
                { 

                bCobro = cobbll.Delete(collection.Pago);
                }
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

        [HttpPost]
        public ActionResult GetImprimir(string Contrato, string Pago)
        {
            try
            {
                var a = "";               
                var pagobll = new CobrosBLL();
                var pago = pagobll.GetById(Pago);
                var admAlqui = new AdministradoraAlquileres();
                byte[] bytes = admAlqui.GenerarRecibo(pago);


                //var pdf = new string(resultFactura.ArchivoArray.Select(Convert.ToChar).ToArray());
                //byte[] bytes = pdf.Select(Convert.ToByte).ToArray();

                var streamDownload = new MemoryStream(bytes);
                streamDownload.Flush();
                streamDownload.Position = 0;
                return File(streamDownload, "application/pdf", Pago);
               
                //var stream = new MemoryStream(bytes);
                //Response.Clear();
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "inline; filename=" + Pago);
                //Response.AddHeader("content-length", stream.Length.ToString());
                //Response.BinaryWrite(stream.ToArray());
                //Response.Flush();
                //Response.End();

                //return View();
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

    }
}
