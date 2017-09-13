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
        
        //public ContratosController() { }
        //public ContratosController(IGenericBLL<Propiedades> _genericProp) 
        //{
        //    _PropiedadesBll = _genericProp;
        //}
        
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
        public ActionResult Create(ContratosModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var contratoBll = new ContratosBLL();
                    var contrato = new Contratos
                    {
                        FechaContrato = collection.Contrato.FechaContrato,
                        IdGaranteLaboral1 = collection.Contrato.IdGaranteLaboral1,
                        IdGaranteLaboral2 = collection.Contrato.IdGaranteLaboral2,
                        IdGaranteLaboral3 = collection.Contrato.IdGaranteLaboral3,
                        IdGarantePropietario = collection.Contrato.IdGarantePropietario,
                        Incrementos = collection.Contrato.Incrementos,
                        InquilinoId = collection.Contrato.InquilinoId,
                        MontoInicialAlquiler = collection.Contrato.MontoInicialAlquiler,
                        NroContrato = collection.Contrato.NroContrato,
                        PeriodoMeses = collection.Contrato.PeriodoMeses,
                        PorcentajeIncremento = collection.Contrato.PorcentajeIncremento,
                        PorcentajeInmobiliaria = collection.Contrato.PorcentajeInmobiliaria,
                        PropiedadesId = collection.Contrato.PropiedadesId                         
                    };
                    contratoBll.Add(contrato);
                }

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
            var propiedadList = new  PropiedadesBLL();
            var listPropiedad = propiedadList.GetAll();
                        
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
                                IdPropiedad = prope.Domicilio.DomiciliosId,
                                IdPropietario = prope.PersonasId,
                                Apellido = prope.Personas.Apellido,
                                Nombre = prope.Personas.Nombre,
                                Du = prope.Personas.DU,
                                TelLabo = prope.Personas.TelefonoLaboral != null ? prope.Personas.TelefonoLaboral : ""
                            }).ToList();

            return Json(PropiedadName, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetInquilino(string nombre)
        {
            var contratoList = new ContratosBLL();
            var listContrato = contratoList.GetAll();

            var inquilinoName = (from contrato in listContrato
                                 where (contrato.Inquilino.Nombre.ToLower().Contains(nombre.ToLower()) || contrato.Inquilino.Apellido.ToLower().Contains(nombre.ToLower()) || contrato.Inquilino.DU.Contains(nombre))
                                 select new
                                 {
                                     ContratoId = contrato.ContratosId,
                                     InquilinoId = contrato.InquilinoId,
                                     Nombre = contrato.Inquilino.Nombre,
                                     Apellido = contrato.Inquilino.Apellido,
                                     DU = contrato.Inquilino.DU,
                                     TelefonoLaboral = contrato.Inquilino.TelefonoLaboral,
                                     PropiedadId = contrato.sPropiedadId,
                                     Calle = contrato.Propiedades.Domicilio.Calle,
                                     Numero = contrato.Propiedades.Domicilio.Numero,
                                     Piso = contrato.Propiedades.Domicilio.Piso,
                                     Departamento = contrato.Propiedades.Domicilio.Dto,
                                     Barrio = contrato.Propiedades.Domicilio.Barrio,
                                     CP = contrato.Propiedades.Domicilio.CP,
                                     PeriodosAdeudados = contrato.PeriodosAdeudados
                                 }).ToList();
            
            return Json(inquilinoName, JsonRequestBehavior.AllowGet);
            
        }

    }
}
