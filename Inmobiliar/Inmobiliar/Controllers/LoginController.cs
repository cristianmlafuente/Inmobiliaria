using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InmBLL;

namespace Inmobiliar.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("../Home/Login");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Logueo(Inmobiliar.Models.Login collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AdministradoraUsuarios oAdmUsuario = new AdministradoraUsuarios();
                    var usuarioValido = oAdmUsuario.LogueoUsuario(collection.NombreUsuario, collection.Password);
                    if (usuarioValido != null)
                    {
                        Session["Usuario"] = usuarioValido;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.TipoMsj = "Info";
                        ViewBag.Message = "El usuario ingresado no se encuentra registrado en el sistema.";
                        return View(collection);
                    }
                }
                else
                {
                    ViewBag.TipoMsj = "Info";
                    ViewBag.Message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.TipoMsj = "Error";
                ViewBag.Message = ex.Message;
                return View("~/Views/Home/Login.cshtml", collection);                                
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
            
        }

        // POST: Login/Delete/5
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

        
        public ActionResult Logout()
        {
            try
            {
                // TODO: Add insert logic here
                
                    Session["Usuario"] = null;
                    //ViewBag.UsuarioLogueado = true;

                    return RedirectToAction("Index", "Home");
               
            }
            catch
            {
                return View();
            }
        }
    }
}
