using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_management.Models;

namespace Hotel_management.Controllers
{
    public class Dasbohard2Controller : Controller
    {
        //
        // GET: /Dasbohard2/

        public ActionResult dasbo2()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<habitacion> habi = db.habitacions.ToList();
            dasboard2  das=new dasboard2();
            das.habitaciones = new List<infohdash>();            
            das.fecha_inicio = DateTime.Now;
            das.fecha_fin = DateTime.Now.AddDays(7);
            das.semanal = true;
            for (int i = 0; i < habi.Count; i++)
            {
                infohdash info = new infohdash();
                info.hab = habi[i].numero;
                info.tipo = habi[i].nombre;
                info.desde = new List<DateTime>();
                info.hasta = new List<DateTime>();
                var q = from re in db.reservas
                        //where re.//conpletar cuando se relacionen las tablas reserva y habitacion
                        where ((re.fecha_final.Value >= das.fecha_inicio && re.fecha_final.Value <= das.fecha_fin
                                || re.fecha_inicio.Value >= das.fecha_inicio && re.fecha_inicio.Value <= das.fecha_fin)
                                || (re.fecha_inicio.Value <= das.fecha_inicio && re.fecha_final.Value >= das.fecha_fin))
                                && info.hab == re.habitacion.numero
                        select re;
                foreach (var k in q)
                {
                    info.desde.Add(k.fecha_inicio.Value);
                    info.hasta.Add(k.fecha_final.Value);
                }
                das.habitaciones.Add(info);
            }
            ViewBag.das = das;
            return View();
        }
    }
}
