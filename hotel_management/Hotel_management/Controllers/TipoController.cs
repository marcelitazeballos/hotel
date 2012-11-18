using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_management.Models;

namespace Hotel_management.Controllers
{
    public class TipoController : Controller
    {
        //
        // GET: /Tipo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistroT()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            ViewBag.ti = (from a in db.tipos select a).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult RegistroT(tipos newtipo)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
  
            if (ModelState.IsValid)
            {
                tipo ti = new tipo();
                ti.nombre = newtipo.nombre;
                ti.descripcion = newtipo.desc;
                ti.precio = newtipo.pre;
                db.tipos.InsertOnSubmit(ti);
                db.SubmitChanges();
            }
            ViewBag.ti = (from a in db.tipos select a).ToList();
            return Redirect("../Tipo/RegistroT");
        }

            
        public ActionResult actualizartipo(String id)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();

            int ID = Convert.ToInt32(id);
            if ((from i in dt.tipos where i.id == ID select i).ToList().Count == 0)
            {
                ViewBag.flag = 0;
            }

            else
            {
                var x = (from i in dt.tipos
                         where i.id==ID
                         select new
                         {
                             id=i.id,
                             nombre = i.nombre,
                             descripcion = i.descripcion,
                             precio = i.precio
                             }).ToArray()[0];

                ViewBag.id = x.id;
                ViewBag.nombre = x.nombre;
                ViewBag.descripcion = x.descripcion;
                ViewBag.precio = x.precio;
                
                ViewBag.flag = 1;
            }



            return View();
        }
        public ActionResult actualizarper(tipos newtipo)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            tipo t = db.tipos.Single(u => u.id ==  newtipo.id);
           
            t.nombre = newtipo.nombre;
            t.descripcion = newtipo.desc;
            t.precio = newtipo.pre;
            
            db.SubmitChanges();
            return Redirect("../Cliente/RegistroT");
        }

        public ActionResult eliminarpersona()
        {
            ViewBag.flag = 0;
            return View();
        }
        [HttpPost]
        public ActionResult eliminartipo(tipos newtipo)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();


            if ((from i in dt.tipos where i.nombre == newtipo.nombre select i).ToList().Count == 0)
            {
                ViewBag.flag = 0;
            }

            else
            {
                var x = (from i in dt.tipos
                          where i.nombre == newtipo.nombre
                         select new
                         {
                             nombre = i.nombre,
                             id = i.id,
                             descripcion = i.descripcion,
                             precio = i.precio
                         }).ToArray()[0];

                ViewBag.id = x.id;
                ViewBag.descripcion = x.descripcion;
                ViewBag.precio = x.precio;
                ViewBag.nombre = x.nombre;
                ViewBag.flag = 1;
            }


            return View();
        }

       
        public ActionResult eliminart(String ID)
        {
            int id = Convert.ToInt32(ID);
            DataClasses1DataContext db = new DataClasses1DataContext();
            tipo t = db.tipos.Single(u => u.id == id);
           
            db.tipos.DeleteOnSubmit(t);
            db.SubmitChanges();
            return Redirect("/Tipo/RegistroT");
        }

    }
}