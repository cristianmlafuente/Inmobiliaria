using InmBLL;
using Inmobiliar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmBLL.Entities;
using Microsoft.VisualBasic;
using Common.Emum;

namespace Inmobiliar.Controllers
{

    public class ContratosController : Controller
    {
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
                        Incrementos = collection.Contrato.Incrementos,
                        InquilinoId = collection.Contrato.InquilinoId,
                        MontoInicialAlquiler = collection.Contrato.MontoInicialAlquiler,
                        NroContrato = collection.Contrato.NroContrato,
                        PeriodoMeses = collection.Contrato.PeriodoMeses,
                        PorcentajeIncremento = collection.Contrato.PorcentajeIncremento,
                        PorcentajeInmobiliaria = collection.Contrato.PorcentajeInmobiliaria,
                        PropiedadesId = collection.Contrato.PropiedadesId,
                        PropietarioId = collection.Contrato.PropietarioId
                    };
                    var inpu = collection.Impuestos.Split(',');
                    foreach (var item in inpu)
                    {
                        if (contrato.ListaImpuestos == null)
                            contrato.ListaImpuestos = new List<TipoImpuestosServicios>();
                        contrato.ListaImpuestos.Add(new TipoImpuestosServicios() { Codigo = int.Parse(item.Trim()) });
                    }
                    if (Information.IsNumeric(collection.idPersonaGarantePropietario))
                    {
                        var garProp = new GarantePropietario();
                        garProp.Domicilio = new Domicilios();
                        garProp.Domicilio.Barrio = collection.BarrioGarantePropietario;
                        garProp.Domicilio.Calle = collection.CalleGarantePropietario;
                        garProp.Domicilio.Ciudad = collection.CiudadGarantePropietario;
                        garProp.Domicilio.CP = collection.CPGarantePropietario;
                        garProp.Domicilio.Dto = collection.DepartamentoGarantePropietario;
                        if (Information.IsNumeric(collection.NumeroGarantePropietario))                        
                            garProp.Domicilio.Numero = int.Parse(collection.NumeroGarantePropietario);
                        if (Information.IsNumeric(collection.PisoGarantePropietario))
                            garProp.Domicilio.Piso = int.Parse(collection.PisoGarantePropietario);
                        garProp.PersonasId = int.Parse(collection.idPersonaGarantePropietario);                        
                        contrato.GarantePropietario = garProp;
                    }
                    contratoBll.Add(contrato);
                    ViewBag.TipoMsj = "Success";
                    ViewBag.Message = "El contrato se registro con Exito!!!";
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
        [PermisoAtribute(Rol = RolesPermisos.Rol_Anular_Contrato)]
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Contratos/Delete/5
        [HttpPost]
        public ActionResult Delete(CobroAlquilerModel collection)
        {
            try
            {
                var contratoBll = new ContratosBLL();
                var a = contratoBll.GetById(collection.Contrato.ContratosId.ToString());
                a.IdEstate = 1;
                contratoBll.Update(a);
                ViewBag.TipoMsj = "Success";
                ViewBag.Message = "El contrato se Bloqueo con Exito!!!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.TipoMsj = "Error";
                ViewBag.Message = ex.Message;
                return View(collection);
            }
        }

        [HttpPost]
        public JsonResult GetPropiedad(string prop)
        {
            var PropiedadName = new object();
            try
            {
                var propiedades = ListaPropiedades(prop);
                var ImpuesService = new ImpuestosBLL().GetAllByEsPago(false);
                var bContra = new ContratosBLL();
                var contratos = bContra.GetAll();
                contratos = contratos.Where(xx => xx.IdEstate.Value == 0).ToList();

                contratos = contratos.Where(b => propiedades.Any(a => a.PropiedadId == b.PropiedadesId)).ToList();

                PropiedadName = (from contra in contratos
                                 select new
                                 {
                                     Calle = contra.Propiedades.Domicilio.Calle,
                                     Numero = contra.Propiedades.Domicilio.Numero,
                                     PropiedadId = contra.PropiedadesId,
                                     Barrio = contra.Propiedades.Domicilio.Barrio,
                                     Piso = contra.Propiedades.Domicilio.Piso,
                                     Dto = contra.Propiedades.Domicilio.Dto,
                                     CP = contra.Propiedades.Domicilio.CP,
                                     Ciudad = contra.Propiedades.Domicilio.Ciudad,
                                     NroContratoEpec = contra.Propiedades.NroContratoEpec,
                                     NomCatrastal = contra.Propiedades.NomenclaturaCatastral,
                                     NumeroCtaRenta = contra.Propiedades.NumeroCtaRenta,
                                     UnidadFacturacion = contra.Propiedades.UnidadFacturacion,
                                     IdPropiedad = contra.Propiedades.DomiciliosId,
                                     IdPropietario = contra.PropietarioId,
                                     Apellido = contra.Inquilino.Apellido,
                                     Nombre = contra.Inquilino.Nombre,
                                     Du = contra.Inquilino.DU,
                                     TelLabo = contra.Inquilino.TelefonoLaboral,
                                     Impuesto = ImpuesService,
                                     PeriodosAdeudados = contra.PeriodosAdeudados,
                                     PeriodosPagados = contra.PeriodosPagados,
                                     ContratoId = contra.ContratosId.ToString(),
                                     Observaciones = contra.Observaciones,
                                 }).ToList();                               

                return Json(PropiedadName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
                
            }
        }

        [HttpPost]
        public JsonResult GetPropiedadSinAlquiler(string prop)
        {
            var PropiedadName = new object();
            try
            {
                var ImpuesService = new ImpuestosBLL().GetAllByEsPago(false);
                var propiedades = ListaPropiedades(prop);
                propiedades = propiedades.Where(x => x.Estado == false).ToList();
                //var bContra = new ContratosBLL();
                //var contratos = bContra.GetAll();
                //contratos = contratos.Where(xx => xx.IdEstate.Value == 0).ToList();
                //foreach (var item in contratos)
                //{
                //    propiedades.RemoveAll(xx => xx.PropiedadId == item.PropiedadesId || xx.Tipo == "2");
                //}                
                PropiedadName = (from propi in propiedades
                                 select new
                                 {
                                     Calle = propi.Calle,
                                     Numero = propi.Numero,
                                     PropiedadId = propi.PropiedadId,
                                     Barrio = propi.Barrio,
                                     Piso = propi.Piso,
                                     Dto = propi.Dto,
                                     CP = propi.CP,
                                     Ciudad = propi.Ciudad,
                                     NroContratoEpec = propi.NroContratoEpec,
                                     ClienteEpecNro = propi.ClienteEpecNro,
                                     NroMedidorGas = propi.NroMedidorGas,
                                     NumeroFacturaAgua = propi.NumeroFacturaAgua,
                                     NomCatrastal = propi.NomCatrastal,
                                     NumeroCtaRenta = propi.NumeroCtaRenta,
                                     UnidadFacturacion = propi.UnidadFacturacion,
                                     IdPropiedad = propi.DomicilioId,
                                     IdPropietario = propi.IdPropietario,
                                     Apellido = propi.Apellido,
                                     Nombre = propi.Nombre,
                                     Du = propi.Du,
                                     TelLabo = propi.TelLabo,
                                     Impuesto = ImpuesService
                                 }).ToList();
                return Json(PropiedadName, JsonRequestBehavior.AllowGet);                
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);

            }            
        }

        [HttpPost]
        public JsonResult GetInquilino(string nombre)
        {
            var contratoList = new ContratosBLL();
            var listContrato = contratoList.GetAll();
            var otrosPagos = new ImpuestosBLL().GetAllByEsPago(true);
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
                                     PeriodosAdeudados = contrato.PeriodosAdeudados,
                                     PeriodosPagados = contrato.PeriodosPagados,
                                     ListaImpuestos = contrato.ListaImpuestos,
                                     OtrosPagos = otrosPagos,
                                     Observaciones = contrato.Observaciones,
                                     Propietario = contrato.Propietario,
                                     Garante1 = contrato.GaranteLaboral1,
                                     Garante2 = contrato.GaranteLaboral2,
                                     Garante3 = contrato.GaranteLaboral3,
                                     GarantePropie = contrato.GarantePropietario,
                                     NroContrato = contrato.NroContrato,
                                     FechaInicio = contrato.FechaContrato.Value.ToShortDateString(),
                                     Duracion = contrato.PeriodoMeses,
                                     CantidadIncrementos = contrato.Incrementos,
                                     PorcentajeIncremento = contrato.PorcentajeIncremento,
                                     MontoIncial = contrato.MontoInicialAlquiler,
                                     PorcentajeInmo = contrato.PorcentajeInmobiliaria
                                 }).ToList();
            
            return Json(inquilinoName, JsonRequestBehavior.AllowGet);
            
        }

        public List<Propiedad> ListaPropiedades(string prop)
        {
            //var PropiedadName = new object();
            try
            {
                var propiedadList = new  PropiedadesBLL();
                var listPropiedad = propiedadList.GetAll();
                             
                var PropiedadName = (from propi in listPropiedad
                                     where (propi.Domicilio.Calle.ToUpper().Contains(prop.ToUpper()) || propi.Domicilio.Barrio.ToUpper().Contains(prop.ToUpper()) || propi.Domicilio.Ciudad.ToUpper().Contains(prop.ToUpper()) || propi.Domicilio.CP.Contains(prop))
                                     select new Propiedad
                                        {
                                            Calle = propi.Domicilio.Calle,
                                            Numero = propi.Domicilio.Numero,
                                            PropiedadId = propi.PropiedadesId,
                                            Barrio = propi.Domicilio.Barrio,
                                            Piso = propi.Domicilio.Piso,
                                            Dto = propi.Domicilio.Dto,
                                            CP = propi.Domicilio.CP,
                                            Ciudad = propi.Domicilio.Ciudad,                                    
                                            NroContratoEpec = propi.NroContratoEpec,
                                            NroMedidorGas = propi.NroMedidorGas,
                                            ClienteEpecNro = propi.ClienteEpecNro,
                                            NomCatrastal = propi.NomenclaturaCatastral,
                                            NumeroFacturaAgua = propi.NroFactura != null ? propi.NroFactura.Value.ToString() : "",
                                            NumeroCtaRenta = propi.NumeroCtaRenta,
                                            UnidadFacturacion = propi.UnidadFacturacion,
                                            DomicilioId = propi.Domicilio.DomiciliosId,
                                            IdPropietario = propi.PersonasId,
                                            Apellido = propi.Personas.Apellido,
                                            Nombre = propi.Personas.Nombre,
                                            Du = propi.Personas.DU,
                                            TelLabo = propi.Personas.TelefonoLaboral != null ? propi.Personas.TelefonoLaboral : "",                                            
                                            Tipo = propi.Tipo,
                                            Estado = propi.Estado
                                }).ToList();
                return PropiedadName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
 
        }

        [HttpPost]
        public JsonResult GetPropietarios(string nombre, Nullable<bool> sinAlquilar = null)
        {
            try
            {
                var Propietarios = new object();
                var propiedades = ListaPropiedades("");
                var ImpuesService = new ImpuestosBLL().GetAllByEsPago(false);
                if (sinAlquilar != null)
                {
                    var bContra = new ContratosBLL();
                    var contratos = bContra.GetAll();
                    if (sinAlquilar.Value)
                    {
                        propiedades = propiedades.Where(x => x.Estado == false).ToList();

                        //contratos = contratos.Where(xx => xx.IdEstate.Value == 0).ToList();
                        //foreach (var item in contratos)
                        //{
                        //    propiedades.RemoveAll(xx => xx.PropiedadId == item.PropiedadesId || xx.Tipo == "2");
                        //}
                        Propietarios = (from propi in propiedades
                                        where propi.Apellido.ToUpper().Contains(nombre.ToUpper()) || propi.Nombre.ToUpper().Contains(nombre.ToUpper()) || propi.Du.ToUpper().Contains(nombre.ToUpper())
                                        select new
                                        {
                                            Calle = propi.Calle,
                                            Numero = propi.Numero,
                                            PropiedadId = propi.PropiedadId,
                                            Barrio = propi.Barrio,
                                            Piso = propi.Piso == null ? "" : propi.Piso.Value.ToString(),
                                            Dto = string.IsNullOrEmpty(propi.Dto) ? "" : propi.Dto,
                                            CP = propi.CP,
                                            Ciudad = propi.Ciudad,
                                            NroContratoEpec = propi.NroContratoEpec,
                                            NomCatrastal = propi.NomCatrastal,
                                            NumeroCtaRenta = propi.NumeroCtaRenta,
                                            UnidadFacturacion = propi.UnidadFacturacion,
                                            IdPropiedad = propi.DomicilioId,
                                            IdPropietario = propi.IdPropietario,
                                            Apellido = propi.Apellido,
                                            Nombre = propi.Nombre,
                                            Du = propi.Du,
                                            TelLabo = propi.TelLabo,
                                            Impuesto = ImpuesService
                                        }).ToList();
                    }
                    else
                    {
                        contratos = contratos.Where(xx => xx.IdEstate.Value == 0).ToList();
                        contratos = contratos.Where(b => propiedades.Any(a => a.PropiedadId == b.PropiedadesId)).ToList();
                        Propietarios = (from contra in contratos
                                        where contra.Propietario.Apellido.ToUpper().Contains(nombre.ToUpper()) || contra.Propietario.Nombre.ToUpper().Contains(nombre.ToUpper()) || contra.Propietario.DU.ToUpper().Contains(nombre.ToUpper())
                                         select new
                                         {
                                             Calle = contra.Propiedades.Domicilio.Calle,
                                             Numero = contra.Propiedades.Domicilio.Numero,
                                             PropiedadId = contra.PropiedadesId,
                                             Barrio = contra.Propiedades.Domicilio.Barrio,
                                             Piso = contra.Propiedades.Domicilio.Piso == null ? "" : contra.Propiedades.Domicilio.Piso.Value.ToString(),
                                             Dto = string.IsNullOrEmpty(contra.Propiedades.Domicilio.Dto) ? "" : contra.Propiedades.Domicilio.Dto,
                                             CP = contra.Propiedades.Domicilio.CP,
                                             Ciudad = contra.Propiedades.Domicilio.Ciudad,
                                             NroContratoEpec = contra.Propiedades.NroContratoEpec,
                                             NomCatrastal = contra.Propiedades.NomenclaturaCatastral,
                                             NumeroCtaRenta = contra.Propiedades.NumeroCtaRenta,
                                             UnidadFacturacion = contra.Propiedades.UnidadFacturacion,
                                             IdPropiedad = contra.Propiedades.DomiciliosId,
                                             IdPropietario = contra.PropietarioId,
                                             Apellido = contra.Propietario.Apellido,
                                             Nombre = contra.Propietario.Nombre,
                                             Du = contra.Propietario.DU,
                                             TelLabo = contra.Propietario.TelefonoLaboral,
                                             Impuesto = ImpuesService,
                                             PeriodosAdeudados = contra.PeriodosAdeudados,
                                             PeriodosPagados = contra.PeriodosPagados,
                                             ContratoId = contra.ContratosId.ToString(),
                                             Observaciones = contra.Observaciones,
                                         }).ToList();      
                    }
                }
                else
                {
                    Propietarios = (from propi in propiedades
                                    where propi.Apellido.ToUpper().Contains(nombre.ToUpper()) || propi.Nombre.ToUpper().Contains(nombre.ToUpper()) || propi.Du.ToUpper().Contains(nombre.ToUpper())
                                    select new
                                    {
                                        Calle = propi.Calle,
                                        Numero = propi.Numero,
                                        PropiedadId = propi.PropiedadId,
                                        Barrio = propi.Barrio,
                                        Piso = propi.Piso == null ? "" : propi.Piso.Value.ToString(),
                                        Dto = string.IsNullOrEmpty(propi.Dto) ? "" : propi.Dto,
                                        CP = propi.CP,
                                        Ciudad = propi.Ciudad,
                                        NroContratoEpec = propi.NroContratoEpec,
                                        NomCatrastal = propi.NomCatrastal,
                                        NumeroCtaRenta = propi.NumeroCtaRenta,
                                        UnidadFacturacion = propi.UnidadFacturacion,
                                        IdPropiedad = propi.DomicilioId,
                                        IdPropietario = propi.IdPropietario,
                                        Apellido = propi.Apellido,
                                        Nombre = propi.Nombre,
                                        Du = propi.Du,
                                        TelLabo = propi.TelLabo,
                                        Impuesto = ImpuesService
                                    }).ToList();
                }
                 

                return Json(Propietarios, JsonRequestBehavior.AllowGet);
            }
             catch (Exception ex)
             {
                 return Json(ex.Message, JsonRequestBehavior.AllowGet);
             }
        }
    }
}
