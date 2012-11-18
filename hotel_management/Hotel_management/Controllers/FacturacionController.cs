using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Hotel_management.Models;

namespace Hotel_management.Controllers
{
    public class FacturacionController : Controller
    {
        //
        // GET: /Facturacion/

        public ActionResult Facturacion()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Facturacion(FacturacionInput input)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var q = db.reservas.Where(x => x.cliente.nombre == input.nombre);//reservas
            ViewBag.doit = false;
            if (q.Count() > 0)
            {
                int idCliente = q.First().idCli;
                var q2 = db.servicios_clientes.Where(x => x.idCli == idCliente);
                q.Select(x => x.habitacion);
                ViewBag.reservas = q.ToArray();
                ViewBag.servicios = q2.ToArray();
                ViewBag.doit = true;
            }
            return View();
        }
    }
}
