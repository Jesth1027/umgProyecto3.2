using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using umgProyecto3._2.Models;

namespace PROYECTO_WEB.Controllers
{
    public class gest_cuentaController : Controller
    {
        private webEntities1 db = new webEntities1();

        // GET: gest_cuenta
        public ActionResult Index()
        {
            return View(db.gest_cuenta.ToList());
        }

        // GET: gest_cuenta/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_cuenta gest_cuenta = db.gest_cuenta.Find(id);
            if (gest_cuenta == null)
            {
                return HttpNotFound();
            }
            return View(gest_cuenta);
        }

        // GET: gest_cuenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gest_cuenta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = ",No_cuenta,banco,tipo")] gest_cuenta cuenta)

        {

            DateTime Hoy = DateTime.Today;

            string fecha_actual = Hoy.ToString("dd-MM-yyyy");
            cuenta.fecha = DateTime.Parse(fecha_actual);

            if (ModelState.IsValid)
            {


                db.insert_cuenta(cuenta.No_cuenta,cuenta.banco,cuenta.tipo,cuenta.fecha);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View("Create");
        }

        // GET: gest_cuenta/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_cuenta gest_cuenta = db.gest_cuenta.Find(id);
            if (gest_cuenta == null)
            {
                return HttpNotFound();
            }
            return View(gest_cuenta);
        }

        // POST: gest_cuenta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correlativo,No_cuenta,banco,tipo,fecha")] gest_cuenta gest_cuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gest_cuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gest_cuenta);
        }

        // GET: gest_cuenta/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_cuenta gest_cuenta = db.gest_cuenta.Find(id);
            if (gest_cuenta == null)
            {
                return HttpNotFound();
            }
            return View(gest_cuenta);
        }

        // POST: gest_cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            gest_cuenta gest_cuenta = db.gest_cuenta.Find(id);
            db.gest_cuenta.Remove(gest_cuenta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
