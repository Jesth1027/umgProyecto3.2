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
    public class despositoesController : Controller
    {
        private webEntities1 db = new webEntities1();

        // GET: despositoes
        public ActionResult Index()
        {
            var desposito = db.desposito.Include(d => d.gest_cuenta).Include(d => d.usuario);
            return View(desposito.ToList());
        }

        // GET: despositoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            desposito desposito = db.desposito.Find(id);
            if (desposito == null)
            {
                return HttpNotFound();
            }
            return View(desposito);
        }

        // GET: despositoes/Create
        public ActionResult Create()
        {
            ViewBag.cuenta = new SelectList(db.gest_cuenta, "No_cuenta", "No_cuenta");
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre");
            return View();
        }

        // POST: despositoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "serie,fecha,total,cuenta,fecha_sistema,id_user")] desposito desposito)
        {
            if (ModelState.IsValid)
            {
                DateTime Hoy = DateTime.Today;

                string fecha_actual = Hoy.ToString("dd-MM-yyyy");
                desposito.fecha_sistema = DateTime.Parse(fecha_actual);


                desposito.id_user = Convert.ToInt32( Session["id"]);

                db.insert_deposito(desposito.serie, desposito.fecha, desposito.total, desposito.cuenta, desposito.fecha_sistema, desposito.id_user);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.cuenta = new SelectList(db.gest_cuenta, "No_cuenta", "No_cuenta", desposito.cuenta);
         
            return View(desposito);
        }

        // GET: despositoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            desposito desposito = db.desposito.Find(id);
            if (desposito == null)
            {
                return HttpNotFound();
            }
            ViewBag.cuenta = new SelectList(db.gest_cuenta, "No_cuenta", "banco", desposito.cuenta);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", desposito.id_user);
            return View(desposito);
        }

        // POST: despositoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correlativo,serie,fecha,total,cuenta,fecha_sistema,id_user")] desposito desposito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desposito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cuenta = new SelectList(db.gest_cuenta, "No_cuenta", "No_cuenta", desposito.cuenta);
           
            return View(desposito);
        }

        // GET: despositoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            desposito desposito = db.desposito.Find(id);
            if (desposito == null)
            {
                return HttpNotFound();
            }
            return View(desposito);
        }

        // POST: despositoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            desposito desposito = db.desposito.Find(id);
            db.desposito.Remove(desposito);
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
