using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_management.Models;
namespace Hotel_management.Controllers
{
    public class MantenimientoController : Controller
    {
        //
        // GET: /Mantenimiento/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegistroMantenimiento()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            this.ViewBag.man = db.habitacions.Select(b => new SelectListItem() { Selected = false, Value = b.id.ToString(), Text = b.numero }).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult RegistroMantenimiento(Mantenimientos newmantenimiento)
        {
            if (ModelState.IsValid)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                this.ViewBag.man = db.habitacions.Select(b => new SelectListItem() { Selected = false, Value = b.id.ToString(), Text = b.numero }).ToList();

                ViewBag.emp = (from f in db.habitacions select f).ToList();
                mantenimiento mante = new mantenimiento();
                //habitacion hab = new habitacion();
                mante.idHab = Convert.ToInt32(newmantenimiento.id_hab);
                mante.fecha_inicio =newmantenimiento.fecha_ini;
                mante.fecha_final = newmantenimiento.fecha_fin;

                db.mantenimientos.InsertOnSubmit(mante);
                db.SubmitChanges();
            }

            return View(); }

    }
}
