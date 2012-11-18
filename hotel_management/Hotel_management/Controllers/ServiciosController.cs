using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_management.Models;

namespace Hotel_management.Controllers
{
    public class ServiciosController : Controller
    {
        //
        // GET: /Servicios/

        public ActionResult RegistroServicio()
        {
            return View();

        }

        [HttpPost]
        public ActionResult RegistroServicio(Servicitos newservicio)

        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            servicio ser = new servicio();
            ser.tipo = newservicio.tip;
            ser.descripcion = newservicio.desc;
            ser.precio = newservicio.pre;
            db.servicios.InsertOnSubmit(ser);
            db.SubmitChanges();

            return View();

        }

        public ActionResult categoria()
        {

            return View();
        }
        [HttpPost]
        public ActionResult categoria(Servicitos model)
        {
            string[] arraycategorias = model.nombre.ToLower().Split(',');
            List<categoriass> listacategoria = new List<categoriass>();
            DataClasses1DataContext db = new DataClasses1DataContext();
            foreach (var item in arraycategorias)
            {
                string items = item.Trim();
                if (db.categoriasses.Where(a => a.nombre == item).Count() == 0)
                {
                    listacategoria.Add(new  categoriass() { nombre = item, fecha = DateTime.Now });

                }
            }
            if (listacategoria.ToList().Count > 0)
            {
                db.categoriasses.InsertAllOnSubmit(listacategoria);
                db.SubmitChanges();
                @ViewBag.mensaje = "las categorias se crearon con exito";
            }
            return View();
        }
        }
}
