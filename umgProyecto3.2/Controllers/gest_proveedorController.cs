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
    public class gest_proveedorController : Controller
    {
        private webEntities1 db = new webEntities1();

        // GET: gest_proveedor
        public ActionResult Index()
        {
            return View(db.gest_proveedor.ToList());
        }

        // GET: gest_proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_proveedor gest_proveedor = db.gest_proveedor.Find(id);
            if (gest_proveedor == null)
            {
                return HttpNotFound();
            }
            return View(gest_proveedor);
        }

        // GET: gest_proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gest_proveedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,telefono,dirreccion,nit")] gest_proveedor gest_proveedor)
        {


            if (ModelState.IsValid)
            {

                buscar_codigo_de_proveedor_Result u = db.buscar_codigo_de_proveedor().FirstOrDefault();
                gest_proveedor.codigo = u.codigo + 1;

                db.insert_proveedor(gest_proveedor.nit, gest_proveedor.nombre, gest_proveedor.telefono, gest_proveedor.dirreccion, gest_proveedor.codigo);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(gest_proveedor);
        }

        // GET: gest_proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_proveedor gest_proveedor = db.gest_proveedor.Find(id);
            if (gest_proveedor == null)
            {
                return HttpNotFound();
            }
            return View(gest_proveedor);
        }

        // POST: gest_proveedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,telefono,dirreccion,nit")] gest_proveedor gest_proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gest_proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gest_proveedor);
        }

        // GET: gest_proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gest_proveedor gest_proveedor = db.gest_proveedor.Find(id);
            if (gest_proveedor == null)
            {
                return HttpNotFound();
            }
            return View(gest_proveedor);
        }

        // POST: gest_proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gest_proveedor gest_proveedor = db.gest_proveedor.Find(id);
            db.gest_proveedor.Remove(gest_proveedor);
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
