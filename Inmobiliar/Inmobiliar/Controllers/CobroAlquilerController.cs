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
        public ActionResult Create()
        {
            return View();
        }

        // POST: CobroAlquiler/Create
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
    }
}
