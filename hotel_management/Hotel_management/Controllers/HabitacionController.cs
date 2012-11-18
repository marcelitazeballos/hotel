using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_management.Models;

namespace Hotel_management.Controllers
{
    public class HabitacionController : Controller
    {
        //
        // GET: /Habitacion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistroHabitacion()
        {
             DataClasses1DataContext db = new DataClasses1DataContext();
             //var q = from i in db.tipos
                //     select new SelectListItem { Selected = false, Value = i.nombre.ToString(), Text = i.nombre };
            //SelectListItem[] ta = q.ToArray();
            //this.ViewBag.hab = ta;
             this.ViewBag.hab = db.tipos.Select(a => new SelectListItem() { Selected = false, Value = a.id.ToString(), Text = a.nombre + " Precio: " + Convert.ToInt16(a.precio) }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult RegistroHabitacion(Habitaciones newhabitacion)
        {
            if (ModelState.IsValid)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                this.ViewBag.hab = db.tipos.Select(a => new SelectListItem() { Selected = false, Value = a.id.ToString(), Text = a.nombre + " Precio: " + Convert.ToInt16(a.precio) }).ToList();
            
                
                habitacion hab = new habitacion();
                //tipo ti = new tipo();
                hab.estado = "libre";
                hab.numero = newhabitacion.numero.ToString();
                hab.idTip = Convert.ToInt32(newhabitacion.idTipo);
                db.habitacions.InsertOnSubmit(hab);
                db.SubmitChanges();
               
            }
          //  return Redirect("../RegistroHabitacion");
            return View();
        }
        

        public ActionResult recHab()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            ViewBag.ListaH = db.habitacions.
                Select(b => new Habitaciones() { 
                 estado=b.estado,
                 numero=b.numero,
                 idTipo=b.idTip.ToString()
                }).ToList();

            
            
            return View();
        }


   /*     public ActionResult eliminarhab()
        {
            ViewBag.veri = 0;
            return View();
        }

        [HttpPost]
        public ActionResult eliminarhab( Habitaciones hab)
        {

           // ViewBag.ver = hab.id;
            DataClasses1DataContext db = new DataClasses1DataContext();
           /* habitacion habi = db.habitacions.Single(e => e.id == hab.id);
            db.habitacions.DeleteOnSubmit(habi);
            db.SubmitChanges();*/

        /*    if ((from i in db.habitacions where i.numero == hab.numero select i).ToList().Count == 0)
            {
                ViewBag.veri = 0;
            }
            else
            {
                var x = (from i in db.habitacions
                         where i.numero == hab.numero
                         select new
                         {
                             numero = i.numero,
                             id = i.id,
                             estado = i.estado,
                             idtipo = i.idTip
                         }
                           ).ToArray()[0];
                ViewBag.id = x.id;
                ViewBag.numero = x.numero;
                ViewBag.estado = x.estado;
                ViewBag.idtipo = x.idtipo;
                ViewBag.veri = 1;
            }
            return View();
        }

        [HttpPost]
        public ActionResult eliminar(Habitaciones hab)
        {

            ViewBag.ver = hab.id;
            DataClasses1DataContext db = new DataClasses1DataContext();
             habitacion habi = db.habitacions.Single(e => e.id == hab.id);
             db.habitacions.DeleteOnSubmit(habi);
             db.SubmitChanges();
            return View();
        }*/
    }

}
