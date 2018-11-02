using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using umgProyecto3._2.Models;

namespace umgProyecto3._2.Controllers
{
    public class nota_debito_cpController : Controller
    {
        private webEntities1 db = new webEntities1();

        // GET: nota_debito_cp
        public ActionResult Index()
        {
            var nota_debito_cp = db.nota_debito_cp.Include(n => n.asign_cheque_cp).Include(n => n.mov_factura_pagos).Include(n => n.usuario);
            return View(nota_debito_cp.ToList());
        }

        // GET: nota_debito_cp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota_debito_cp nota_debito_cp = db.nota_debito_cp.Find(id);
            if (nota_debito_cp == null)
            {
                return HttpNotFound();
            }
            return View(nota_debito_cp);
        }

        // GET: nota_debito_cp/Create
        public ActionResult Create()
        {
            ViewBag.serie_cheque = new SelectList(db.cheques_disponibles, "serie", "serie");
            ViewBag.idempresa = new SelectList(db.gest_proveedor, "codigo", "nombre");
            ViewBag.nfactura = new SelectList(db.facturas_sin_pagar, "nfactura", "nfactura");
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre");
            return View();
        }

        // POST: nota_debito_cp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "descripcion,nfactura,abono,serie_cheque,id_user")] nota_debito_cp nota_debito_cp)
        {
            if (ModelState.IsValid)
            {
            

                DateTime Hoy = DateTime.Today;

                string fecha_actual = Hoy.ToString("dd-MM-yyyy");
                nota_debito_cp.fecha = DateTime.Parse(fecha_actual);
                nota_debito_cp.id_user = Convert.ToInt32(Session["id"]);

               

                db.insert_nota_cre( nota_debito_cp.fecha, nota_debito_cp.nfactura, nota_debito_cp.abono, nota_debito_cp.serie_cheque, nota_debito_cp.id_user);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.serie_cheque = new SelectList(db.asign_cheque_cp, "serie", "pago_a_orden", nota_debito_cp.serie_cheque);
            ViewBag.nfactura = new SelectList(db.mov_factura_pagos, "nfactura", "descripcion", nota_debito_cp.nfactura);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", nota_debito_cp.id_user);
            return View(nota_debito_cp);
        }

        // GET: nota_debito_cp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota_debito_cp nota_debito_cp = db.nota_debito_cp.Find(id);
            if (nota_debito_cp == null)
            {
                return HttpNotFound();
            }
            ViewBag.serie_cheque = new SelectList(db.asign_cheque_cp, "serie", "pago_a_orden", nota_debito_cp.serie_cheque);
            ViewBag.nfactura = new SelectList(db.mov_factura_pagos, "nfactura", "descripcion", nota_debito_cp.nfactura);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", nota_debito_cp.id_user);
            return View(nota_debito_cp);
        }

        // POST: nota_debito_cp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correlativo,fecha,descripcion,nfactura,idempresa,abono,serie_cheque,id_user")] nota_debito_cp nota_debito_cp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nota_debito_cp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serie_cheque = new SelectList(db.asign_cheque_cp, "serie", "pago_a_orden", nota_debito_cp.serie_cheque);
            ViewBag.nfactura = new SelectList(db.mov_factura_pagos, "nfactura", "descripcion", nota_debito_cp.nfactura);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", nota_debito_cp.id_user);
            return View(nota_debito_cp);
        }

        // GET: nota_debito_cp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota_debito_cp nota_debito_cp = db.nota_debito_cp.Find(id);
            if (nota_debito_cp == null)
            {
                return HttpNotFound();
            }
            return View(nota_debito_cp);
        }

        // POST: nota_debito_cp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nota_debito_cp nota_debito_cp = db.nota_debito_cp.Find(id);
            db.nota_debito_cp.Remove(nota_debito_cp);
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
