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
    public class asign_cheque_cpController : Controller
    {
        private webEntities1 db = new webEntities1();

        // GET: asign_cheque_cp
        public ActionResult Index()
        {
            var asign_cheque_cp = db.asign_cheque_cp.Include(a => a.gest_cheque).Include(a => a.usuario);
            return View(asign_cheque_cp.ToList());
        }

        // GET: asign_cheque_cp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asign_cheque_cp asign_cheque_cp = db.asign_cheque_cp.Find(id);
            if (asign_cheque_cp == null)
            {
                return HttpNotFound();
            }
            return View(asign_cheque_cp);
        }

        // GET: asign_cheque_cp/Create
        public ActionResult Create()
        {
            ViewBag.serie = new SelectList(db.gest_cheque, "serie", "cuenta");
   
            return View();
        }

        // POST: asign_cheque_cp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "serie,cantidad,fecha,pago_a_orden,id_user")] asign_cheque_cp asign_cheque_cp)
        {
            if (ModelState.IsValid)
            {
                asign_cheque_cp.id_user = Convert.ToInt32(Session["id"]);

                db.asignar_cheque(asign_cheque_cp.serie, asign_cheque_cp.cantidad, asign_cheque_cp.fecha, asign_cheque_cp.pago_a_orden, asign_cheque_cp.id_user);
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.serie = new SelectList(db.gest_cheque, "serie", "cuenta", asign_cheque_cp.serie);
          
            return View(asign_cheque_cp);
        }

        // GET: asign_cheque_cp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asign_cheque_cp asign_cheque_cp = db.asign_cheque_cp.Find(id);
            if (asign_cheque_cp == null)
            {
                return HttpNotFound();
            }
            ViewBag.serie = new SelectList(db.gest_cheque, "serie", "cuenta", asign_cheque_cp.serie);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", asign_cheque_cp.id_user);
            return View(asign_cheque_cp);
        }

        // POST: asign_cheque_cp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correlativo,serie,cantidad,fecha,pago_a_orden,id_user")] asign_cheque_cp asign_cheque_cp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asign_cheque_cp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serie = new SelectList(db.gest_cheque, "serie", "cuenta", asign_cheque_cp.serie);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", asign_cheque_cp.id_user);
            return View(asign_cheque_cp);
        }

        // GET: asign_cheque_cp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asign_cheque_cp asign_cheque_cp = db.asign_cheque_cp.Find(id);
            if (asign_cheque_cp == null)
            {
                return HttpNotFound();
            }
            return View(asign_cheque_cp);
        }

        // POST: asign_cheque_cp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asign_cheque_cp asign_cheque_cp = db.asign_cheque_cp.Find(id);
            db.asign_cheque_cp.Remove(asign_cheque_cp);
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
