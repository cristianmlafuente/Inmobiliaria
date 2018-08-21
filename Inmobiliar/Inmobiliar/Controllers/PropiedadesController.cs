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
    public class PropiedadesController : Controller
    {
        
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
                var Domicilio = new DomiciliosBLL();


                if (ModelState.IsValid)
                {
                    if (model.Tipo == "-1")
                    {
                        ViewBag.TipoMsj = "Error";
                        ViewBag.Message = "Debe indicar si el tipo propiedad es para alquilar o vender.";
                        return View(model);
                    }
                    var domicilio = new Domicilios
                    {
                        Barrio = model.domicilio.Barrio,
                        Calle = model.domicilio.Calle,
                        Ciudad = model.domicilio.Ciudad,
                        CP = model.domicilio.CP,
                        Numero = model.domicilio.Numero,
                        Piso = model.domicilio.Piso,
                        Dto = model.domicilio.Dto
                    };

                    var idDomicilio = Domicilio.Add(domicilio);


                    var propiedad = new Propiedades
                    {
                        PersonasId = model.Dueño.PersonasId,
                        DomiciliosId = idDomicilio,
                        NroFactura = model.NumeroFacturaAgua,
                        NomenclaturaCatastral = model.NomenclaturaCatastral,
                        NumeroCtaRenta = model.NumeroCtaRenta,
                        NroContratoEpec = model.NroContratoEpec,
                        UnidadFacturacion = model.UnidadFacturacion,
                        Tipo = model.Tipo,
                        Estado = false,
						ClienteEpecNro = model.ClienteEpecNro,
						NumeroFacturaAgua = model.NumeroFacturaAgua,
						NroMedidorGas = model.NroMedidorGas,
                        PrecioVenta = model.MontoVenta,
                        TelExpensas = model.TelefonoExpensas
                    };

                    var result = propiedades.Add(propiedad);
                    ViewBag.TipoMsj = "Success";
                    ViewBag.Message = "La propiedad se registro con Exito!!!";
                    return View(); 
                }
                else
                {
                    ViewBag.TipoMsj = "Info";
                    ViewBag.Message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    return View(model); 
                }
                
            }
            catch(Exception ex)
            {
                ViewBag.TipoMsj = "Error";
                ViewBag.Message = ex.Message;
                return View(model);
            }
        }

        // GET: Propiedades/Edit/5
        public ActionResult Edit(int id = 0)
        {
            return View();
        }

        // POST: Propiedades/Edit/5
        [HttpPost]
        public ActionResult Edit(PropiedadesModel model, int id = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var propiedades = new PropiedadesBLL();
                    var Domicilio = new DomiciliosBLL();

                    var domicilio = new Domicilios
                    {
                        Barrio = model.domicilio.Barrio,
                        Calle = model.domicilio.Calle,
                        Ciudad = model.domicilio.Ciudad,
                        CP = model.domicilio.CP,
                        Numero = model.domicilio.Numero,
                        Piso = model.domicilio.Piso,
                        Dto = model.domicilio.Dto,
                        DomiciliosId = model.domicilio.DomiciliosId
                    };

                    Domicilio.Update(domicilio);
                    var propiedad = new Propiedades
                    {
                        PersonasId = model.Dueño.PersonasId,
                        DomiciliosId = model.domicilio.DomiciliosId,
                        NroFactura = model.NumeroFacturaAgua,
                        NomenclaturaCatastral = model.NomenclaturaCatastral,
                        NumeroCtaRenta = model.NumeroCtaRenta,
                        NroContratoEpec = model.NroContratoEpec,
                        UnidadFacturacion = model.UnidadFacturacion,
                        PropiedadesId = model.PropiedadesId,
                        Tipo = model.Tipo,
						ClienteEpecNro = model.ClienteEpecNro,						
						NroMedidorGas = model.NroMedidorGas,
                        PrecioVenta = model.MontoVenta,
                        TelExpensas = model.TelefonoExpensas
                    };
                    propiedades.Update(propiedad);                    
                    ViewBag.TipoMsj = "Success";
                    ViewBag.Message = "La propiedad se modifico con Exito!!!";
                    return View();
                }
                else
                {
                    ViewBag.TipoMsj = "Info";
                    ViewBag.Message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.TipoMsj = "Error";
                ViewBag.Message = ex.Message;
                return View(model);
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
