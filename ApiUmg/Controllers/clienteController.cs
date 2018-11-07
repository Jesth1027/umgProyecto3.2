using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiUmg.Models;

namespace ApiUmg.Controllers
{
    public class clienteController : ApiController
    {
        private webEntities db = new webEntities();

        // GET: api/cliente
        public IQueryable<gest_cliente> Getgest_cliente()
        {
            return db.gest_cliente;
        }

        // GET: api/cliente/5
        [ResponseType(typeof(gest_cliente))]
        public IHttpActionResult Getgest_cliente(int id)
        {
            gest_cliente gest_cliente = db.gest_cliente.Find(id);
            if (gest_cliente == null)
            {
                return NotFound();
            }

            return Ok(gest_cliente);
        }

        // PUT: api/cliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgest_cliente(int id, gest_cliente gest_cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gest_cliente.codigo)
            {
                return BadRequest();
            }

            db.Entry(gest_cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gest_clienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/cliente
        [ResponseType(typeof(gest_cliente))]
        public IHttpActionResult Postgest_cliente(gest_cliente gest_cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gest_cliente.Add(gest_cliente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (gest_clienteExists(gest_cliente.codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gest_cliente.codigo }, gest_cliente);
        }

        // DELETE: api/cliente/5
        [ResponseType(typeof(gest_cliente))]
        public IHttpActionResult Deletegest_cliente(int id)
        {
            gest_cliente gest_cliente = db.gest_cliente.Find(id);
            if (gest_cliente == null)
            {
                return NotFound();
            }

            db.gest_cliente.Remove(gest_cliente);
            db.SaveChanges();

            return Ok(gest_cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gest_clienteExists(int id)
        {
            return db.gest_cliente.Count(e => e.codigo == id) > 0;
        }
    }
}