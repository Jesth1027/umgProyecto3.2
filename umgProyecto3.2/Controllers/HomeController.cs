using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using umgProyecto3._2.Models;

namespace umgProyecto3._2.Controllers
{
    public class HomeController : Controller
    {
        private webEntities1 db = new webEntities1();


        public ActionResult Login()
        {
            return View();
        }



        public ActionResult cheque()
        {
            return PartialView("~/views/gest_cheque/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "usuario1,password")] usuario usuario)
        {
            buscar_user_Result u = db.buscar_user(usuario.usuario1, usuario.password).FirstOrDefault();




            if (u == null)//si no existe el usuario
            {
                ModelState.AddModelError("Eror", "Usuario o Contraseña Incorrectos.");
                return View();
            }
            Session["usuario"] = u.usuario;
            Session["id"] = u.id;
            Session["nombre"] = u.nombre;
            Session["puesto"] = u.puesto;
            return View("menu");//redirigir a vista con layout menu
        }
    }
}