using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_management.Models;

namespace Hotel_management.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Perfil newusuario)
        {
            if(ModelState.IsValid)
            {
                usuario us = new usuario();
                DataClasses1DataContext db = new DataClasses1DataContext();
                us.ape_materno = newusuario.ama;
                us.ape_paterno = newusuario.apa;
                //if (Session["idUs"]!=null)
                Guid id = new Guid(Session["idUs"].ToString());
                us.UserId = id;
                us.nombre = newusuario.nom;
                db.usuarios.InsertOnSubmit(us);
                db.SubmitChanges();


            
            }

            return View();
        }

    }
}
