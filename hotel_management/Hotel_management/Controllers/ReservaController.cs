using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_management.Models;

namespace Hotel_management.Controllers
{
    public class ReservaController : Controller
    {
        //
        // GET: /Reserva/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegistroReserva()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            this.ViewBag.tip = db.tipos.Select(a => new SelectListItem() { Selected = false, Value = a.id.ToString(), Text = a.nombre }).ToList();
            this.ViewBag.cli = db.clientes.Select(a => new SelectListItem() { Selected = false, Value = a.id.ToString(), Text = a.nombre }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult RegistroReserva(Reservas newreserva)
        {
            if (ModelState.IsValid)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                this.ViewBag.tip = db.tipos.Select(a => new SelectListItem() { Selected = false, Value = a.id.ToString(), Text = a.nombre }).ToList();
                this.ViewBag.cli = db.clientes.Select(a => new SelectListItem() { Selected = false, Value = a.id.ToString(), Text = a.nombre }).ToList();
                reserva res = new reserva();
                res.idCli = Convert.ToInt32(newreserva.id_cli);
                string[] f_ini = newreserva.fecha_ini.Split(new char[] { '/' });
                string[] f_fin = newreserva.fecha_fin.Split(new char[] { '/' });

                res.fecha_inicio = DateTime.Parse(f_ini[2] + "/" + f_ini[0] + "/" + f_ini[1]);
                res.fecha_final = DateTime.Parse(f_fin[2] + "/" + f_fin[0] + "/" + f_fin[1]);
                res.estado = newreserva.estado;

                int idTipo = Convert.ToInt32(newreserva.id_tip);
                var q2 = from hh in db.habitacions
                         where !(from re in db.reservas
                                 where (re.fecha_final.Value >= res.fecha_inicio.Value && re.fecha_final.Value <= res.fecha_final.Value
                                || re.fecha_inicio.Value >= res.fecha_inicio.Value && re.fecha_inicio.Value <= res.fecha_final.Value)
                                
                                 select re.habitacion).Contains(hh)
                         select hh;
                if (q2.Count() == 0)
                {
                    //añadir mensaje de error
                    return RedirectToAction("Index", "Home");
                }
                habitacion[] aux = q2.ToArray();
                res.idHabi = aux[0].id;
                res.cant_hab = newreserva.can_hab;
                db.reservas.InsertOnSubmit(res);
                db.SubmitChanges();
            }
            return View();
        }        
    }
    class ReservaFechaComparer : IEqualityComparer<reserva>
    {
        public bool Equals(reserva a, reserva b)
        {
            if ((a.fecha_final.Value >= b.fecha_inicio.Value && a.fecha_final.Value <= b.fecha_final.Value)
               || (a.fecha_inicio.Value >= b.fecha_inicio.Value && a.fecha_inicio.Value <= b.fecha_final.Value)
                )
                return true;
            else
                return false;
        }
        public int GetHashCode(reserva r)
        {
            return r.GetHashCode();
        }
    }
}
