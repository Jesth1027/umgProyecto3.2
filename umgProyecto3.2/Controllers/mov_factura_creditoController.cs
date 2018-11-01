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
    public class mov_factura_creditoController : Controller
    {
        private webEntities1 db = new webEntities1();

        // GET: mov_factura_credito
        public ActionResult Index()
        {
            var mov_factura_credito = db.mov_factura_credito.Include(m => m.gest_factura).Include(m => m.usuario);
            return View(mov_factura_credito.ToList());
        }

        // GET: mov_factura_credito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov_factura_credito mov_factura_credito = db.mov_factura_credito.Find(id);
            if (mov_factura_credito == null)
            {
                return HttpNotFound();
            }
            return View(mov_factura_credito);
        }

        // GET: mov_factura_credito/Create
        public ActionResult Create()
        {
            ViewBag.serie = new SelectList(db.Facturas_Disponibles, "serie", "serie");
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre");
            ViewBag.id_cliente = new SelectList(db.gest_cliente, "codigo", "nombre");
            return View();
        }

        // POST: mov_factura_credito/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "serie,total,id_cliente,descripcion")] mov_factura_credito mov_factura_credito)
        {
            if (ModelState.IsValid)
            {

                DateTime Hoy = DateTime.Today;

                string fecha_actual = Hoy.ToString("dd-MM-yyyy");
                mov_factura_credito.fecha = DateTime.Parse(fecha_actual);
                mov_factura_credito.cancelado = "No";
                mov_factura_credito.id_user = Convert.ToInt32(Session["id"]);


                db.insert_facturacc(mov_factura_credito.serie, mov_factura_credito.total, mov_factura_credito.id_cliente, mov_factura_credito.cancelado, mov_factura_credito.fecha, mov_factura_credito.descripcion, mov_factura_credito.id_user);

                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.serie = new SelectList(db.gest_factura, "serie", "estado", mov_factura_credito.serie);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", mov_factura_credito.id_user);
            ViewBag.id_user = new SelectList(db.gest_cliente, "codigo", "nombre", mov_factura_credito.id_cliente);
            return View(mov_factura_credito);
        }

        // GET: mov_factura_credito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov_factura_credito mov_factura_credito = db.mov_factura_credito.Find(id);
            if (mov_factura_credito == null)
            {
                return HttpNotFound();
            }
            ViewBag.serie = new SelectList(db.gest_factura, "serie", "estado", mov_factura_credito.serie);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", mov_factura_credito.id_user);
            return View(mov_factura_credito);
        }

        // POST: mov_factura_credito/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "correlativo,serie,total,id_cliente,cancelado,fecha,descripcion,id_user")] mov_factura_credito mov_factura_credito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mov_factura_credito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serie = new SelectList(db.gest_factura, "serie", "estado", mov_factura_credito.serie);
            ViewBag.id_user = new SelectList(db.usuario, "id", "nombre", mov_factura_credito.id_user);
            return View(mov_factura_credito);
        }

        // GET: mov_factura_credito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mov_factura_credito mov_factura_credito = db.mov_factura_credito.Find(id);
            if (mov_factura_credito == null)
            {
                return HttpNotFound();
            }
            return View(mov_factura_credito);
        }

        // POST: mov_factura_credito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mov_factura_credito mov_factura_credito = db.mov_factura_credito.Find(id);
            db.mov_factura_credito.Remove(mov_factura_credito);
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
