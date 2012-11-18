using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using Hotel_management.Models;


namespace Hotel_management.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View();
        }
         [Authorize(Roles = "administrador de roles")]
        public ActionResult RegistroPersonas()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            //ViewBag.cli = (from a in db.clientes select a).ToList();
              ViewBag.cli = (from a in db.clientes join j in db.personas on a.id equals j.idCli select a).ToList();
             return View();

        }

        [HttpPost]
        public ActionResult RegistroPersonas(Personitas newpersona)
         {
             DataClasses1DataContext db = new DataClasses1DataContext();
             
            if (ModelState.IsValid)
            {
                persona per = new persona();
                cliente cli = new cliente();

                cli.nombre = newpersona.nombr;
                cli.telefono = newpersona.tel;
                cli.email = newpersona.email;
                cli.direccion = newpersona.dir;
                cli.ciudad = newpersona.ciu;
                cli.pais = newpersona.pa;
                cli.estado = newpersona.est;
                cli.contacto = newpersona.cont;
                db.clientes.InsertOnSubmit(cli);
                db.SubmitChanges();
                int id = db.clientes.OrderByDescending(b => b.id).First().id;
                per.idCli = id;
                per.apellido_pat = newpersona.apel;
                per.apellido_mat = newpersona.apel_mat;
                per.pasaporte = newpersona.pas;
                per.comentarios = newpersona.come;
                per.cumpleanos = Convert.ToString(newpersona.cump);

                db.personas.InsertOnSubmit(per);
                db.SubmitChanges();
             }

            ViewBag.cli = (from a in db.clientes join j in db.personas on a.id equals j.idCli select a).ToList();
            return Redirect("../Cliente/RegistroPersonas");
           
        }
       public ActionResult detalle()
        {
           /* DataClasses1DataContext db = new DataClasses1DataContext();
            //ViewBag.cli = (from a in db.clientes select a).ToList();
            ViewBag.cli = (from a in db.clientes join j in db.personas on a.id equals j.idCli select a).ToList();*/
            return View();
        }
                       
        public ActionResult actualizarpersona(String id)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();

            int ID = Convert.ToInt32(id);
            if ((from i in dt.clientes where i.id == ID select i).ToList().Count == 0)
            {
                ViewBag.flag = 0;
            }

            else
            {
                var x = (from i in dt.clientes
                         join j in dt.personas on i.id equals j.idCli
                         where i.id == ID
                         select new
                         {   nombre=i.nombre,
                             telefono = i.telefono,
                             id = i.id,
                             apellido_pat = j.apellido_pat,
                             apellido_mat = j.apellido_mat,
                             pasaporte = j.pasaporte,
                             email = i.email,
                             direccion = i.direccion,
                             ciudad = i.ciudad,
                             estado = i.estado,
                             pais = i.pais,
                             contacto = i.contacto,
                             cumple = j.cumpleanos,
                             comen = j.comentarios
                         }).ToArray()[0];

                ViewBag.id = x.id;
                ViewBag.nombre = x.nombre;
                ViewBag.apellido_pat = x.apellido_pat;
                ViewBag.apellido_mat = x.apellido_mat;
                ViewBag.telefono = x.telefono;
                ViewBag.pasaporte = x.pasaporte;
                ViewBag.email = x.email;
                ViewBag.direccion = x.direccion;
                ViewBag.ciudad = x.ciudad;
                ViewBag.estado = x.estado;
                ViewBag.pais = x.pais;
                ViewBag.contacto = x.contacto;
                ViewBag.comentario = x.comen;
                ViewBag.cumpleaños = x.cumple;
                ViewBag.flag = 1;
            }


            return View();
        }
        [HttpPost]
        public ActionResult actualizarper(Personitas newpersonas)
        {
            
            DataClasses1DataContext db = new DataClasses1DataContext();
            cliente c = db.clientes.Single(u => u.id == newpersonas.id);
            persona p = db.personas.Single(u => u.idCli == newpersonas.id);

            c.nombre = newpersonas.nombr;
            c.telefono = newpersonas.tel;
            c.direccion = newpersonas.dir;
            c.email = newpersonas.email;
            c.estado = newpersonas.est;
            c.ciudad = newpersonas.ciu;
            c.pais = newpersonas.pa;
            c.contacto = newpersonas.cont;

            p.apellido_pat = newpersonas.apel;
            p.apellido_mat = newpersonas.apel_mat;
            p.pasaporte = newpersonas.pas;
            p.cumpleanos = newpersonas.cump;
            p.comentarios = newpersonas.come;

            db.SubmitChanges();
            return Redirect("../Cliente/RegistroPersonas");
        }

        public ActionResult eliminarpersona()
        {
            ViewBag.flag = 0;
            return View();
        }
        [HttpPost]
        public ActionResult eliminarpersona(Personitas newpersonas)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();


            if ((from i in dt.clientes where i.nombre == newpersonas.nombr select i).ToList().Count == 0)
            {
                                ViewBag.flag = 0;
            }

            else
            {
                var x = (from i in dt.clientes
                         join j in dt.personas on i.id equals j.idCli
                         where i.nombre == newpersonas.nombr
                         select new
                         {
                             telefono = i.telefono,
                             id = i.id,
                             apellido_pat = j.apellido_pat,
                             apellido_mat = j.apellido_mat,
                             pasaporte = j.pasaporte,
                             email = i.email,
                             direccion = i.direccion,
                             ciudad = i.ciudad,
                             estado = i.estado,
                             pais = i.pais,
                             contacto = i.contacto,
                             cumple = j.cumpleanos,
                             comen = j.comentarios
                         }).ToArray()[0];

                ViewBag.id = x.id;
                ViewBag.apellido_pat = x.apellido_pat;
                ViewBag.apellido_mat = x.apellido_mat;
                ViewBag.telefono = x.telefono;
                ViewBag.pasaporte = x.pasaporte;
                ViewBag.email = x.email;
                ViewBag.direccion = x.direccion;
                ViewBag.ciudad = x.ciudad;
                ViewBag.estado = x.estado;
                ViewBag.pais = x.pais;
                ViewBag.contacto = x.contacto;
                ViewBag.comentario = x.comen;
                ViewBag.cumpleaños = x.cumple;
                ViewBag.flag = 1;
            }


            return View();
        }

        
        public ActionResult eliminar(String ID)
        {
            int id = Convert.ToInt32(ID);
            DataClasses1DataContext db = new DataClasses1DataContext();
            cliente c = db.clientes.Single(u => u.id == id);
            persona p = db.personas.Single(u => u.idCli == id);

            db.personas.DeleteOnSubmit(p);
            db.SubmitChanges();
            
            db.clientes.DeleteOnSubmit(c);
            db.SubmitChanges();
            
           
            return Redirect("/Cliente/RegistroPersonas");
        }

        
     
        [Authorize(Roles = "usuario")]
        public ActionResult RegistroAgencias()
        {
            DataClasses1DataContext db=new DataClasses1DataContext();
            ViewBag.usu2 = (from a in db.clientes join j in db.agencias on a.id equals j.idCli select a).ToList();
            return View();

        }
        [HttpPost]
        public ActionResult RegistroAgencias(Agencitas newagencia)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            if (ModelState.IsValid)
            {                
                agencia age = new agencia();
                cliente clie = new cliente();

                clie.nombre = newagencia.nombr;
                clie.telefono = newagencia.tel;
                clie.email = newagencia.email;
                clie.direccion = newagencia.dir;
                clie.ciudad = newagencia.ciu;
                clie.pais = newagencia.pa;
                clie.estado = newagencia.est;
                clie.contacto = newagencia.cont;
                db.clientes.InsertOnSubmit(clie);
                db.SubmitChanges();
                int idA = db.clientes.OrderByDescending(b => b.id).First().id;
                age.idCli = idA;
                age.nit = newagencia.nit;
                db.agencias.InsertOnSubmit(age);
                db.SubmitChanges();

             }
            ViewBag.usu2 = (from a in db.clientes join j in db.agencias on a.id equals j.idCli select a).ToList();

            return Redirect("../Cliente/RegistroAgencias");

        }
        public ActionResult actualizaragencia(String id)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();
            int ID = Convert.ToInt32(id);

            if ((from i in dt.clientes where i.id == ID select i).ToList().Count == 0)
            {
                ViewBag.flag = 0;
            }

            else
            {
                var x = (from i in dt.clientes
                         join j in dt.agencias on i.id equals j.idCli
                         where i.id == ID
                         select new
                         {
                             nombre=i.nombre,
                             telefono = i.telefono,
                             id = i.id,
                             nit = j.nit,
                             email = i.email,
                             direccion = i.direccion,
                             ciudad = i.ciudad,
                             estado = i.estado,
                             pais = i.pais,
                             contacto = i.contacto
                             
                         }).ToArray()[0];

                ViewBag.id = x.id;
                ViewBag.nombre = x.nombre;
                ViewBag.nit = x.nit;
                ViewBag.telefono = x.telefono;         
                ViewBag.email = x.email;
                ViewBag.direccion = x.direccion;
                ViewBag.ciudad = x.ciudad;
                ViewBag.estado = x.estado;
                ViewBag.pais = x.pais;
                ViewBag.contacto = x.contacto;

                ViewBag.flag = 1;
            }


            return View();
        }
        [HttpPost]
        public ActionResult actualizarage(Agencitas newagencia)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            cliente c = db.clientes.Single(u => u.id == newagencia.id);
            agencia ag = db.agencias.Single(u => u.idCli == newagencia.id);

            c.nombre = newagencia.nombr;
            c.telefono = newagencia.tel;
            c.direccion = newagencia.dir;
            c.email = newagencia.email;
            c.estado = newagencia.est;
            c.ciudad = newagencia.ciu;
            c.pais = newagencia.pa;
            c.contacto = newagencia.cont;

            ag.nit = newagencia.nit;
            

            db.SubmitChanges();
            return Redirect("../Cliente/RegistroAgencias");
          }

        public ActionResult eliminaragencia()
        {
            ViewBag.flag = 0;
            return View();
        }
        [HttpPost]
        public ActionResult eliminaragencia(Agencitas newagencia)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();


            if ((from i in dt.clientes where i.nombre == newagencia.nombr select i).ToList().Count == 0)
            {
                ViewBag.flag = 0;
            }

            else
            {
                var x = (from i in dt.clientes
                         join j in dt.agencias on i.id equals j.idCli
                         where i.nombre == newagencia.nombr
                         select new
                         {
                             telefono = i.telefono,
                             id = i.id,
                             nit = j.nit,                          
                             email = i.email,
                             direccion = i.direccion,
                             ciudad = i.ciudad,
                             estado = i.estado,
                             pais = i.pais,
                             contacto = i.contacto
                         }).ToArray()[0];

                ViewBag.id = x.id;
                ViewBag.nit = x.nit;
                ViewBag.telefono = x.telefono;
                ViewBag.email = x.email;
                ViewBag.direccion = x.direccion;
                ViewBag.ciudad = x.ciudad;
                ViewBag.estado = x.estado;
                ViewBag.pais = x.pais;
                ViewBag.contacto = x.contacto;
                ViewBag.flag = 1;
            }


            return View();
        }

        public ActionResult eliminarage(String ID)
        {
            int id = Convert.ToInt32(ID);
            DataClasses1DataContext db = new DataClasses1DataContext();
            cliente c = db.clientes.Single(u => u.id == id);
            agencia ag = db.agencias.Single(u => u.idCli == id);
            db.agencias.DeleteOnSubmit(ag);
            db.SubmitChanges();
            db.clientes.DeleteOnSubmit(c);
            db.SubmitChanges();
            return Redirect("/Cliente/RegistroAgencias");
        }


        public ActionResult RegistroEmpresas()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            ViewBag.usu = (from a in db.clientes join j in db.empresas on a.id equals j.idCli select a).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult RegistroEmpresas(Empresitas newempresa)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            if (ModelState.IsValid)
            {
                
                cliente clien = new cliente();
                empresa emp = new empresa();
                clien.nombre = newempresa.nombr;
                clien.telefono = newempresa.tel;
                clien.email = newempresa.email;
                clien.direccion = newempresa.dir;
                clien.ciudad = newempresa.ciu;
                clien.pais = newempresa.pa;
                clien.estado = newempresa.est;
                clien.contacto = newempresa.cont;
                db.clientes.InsertOnSubmit(clien);
                db.SubmitChanges();
                int idE = db.clientes.OrderByDescending(b => b.id).First().id;
                emp.idCli = idE;
                emp.nit = newempresa.nit;
                emp.metodo_pago = newempresa.metodo;
                db.empresas.InsertOnSubmit(emp);
                db.SubmitChanges();

            }
            ViewBag.usu = (from a in db.clientes join j in db.empresas on a.id equals j.idCli select a).ToList();
            return Redirect("/Cliente/RegistroEmpresas");   
        }
        public ActionResult actualizarempresa(String id)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();
            int ID = Convert.ToInt32(id);

            if ((from i in dt.clientes where i.id == ID select i).ToList().Count == 0)
            {
                ViewBag.flag = 0;
            }

            else
            {
                var x = (from i in dt.clientes
                         join j in dt.empresas on i.id equals j.idCli
                         where i.id == ID
                         select new
                         {
                             nombre=i.nombre,
                             telefono = i.telefono,
                             id = i.id,
                             nit = j.nit,
                             metodo_pago=j.metodo_pago,
                             email = i.email,
                             direccion = i.direccion,
                             ciudad = i.ciudad,
                             estado = i.estado,
                             pais = i.pais,
                             contacto = i.contacto

                         }).ToArray()[0];

                ViewBag.id = x.id;
                ViewBag.nombre = x.nombre;
                ViewBag.nit = x.nit;
                ViewBag.metodo_pago = x.metodo_pago;
                ViewBag.telefono = x.telefono;
                ViewBag.email = x.email;
                ViewBag.direccion = x.direccion;
                ViewBag.ciudad = x.ciudad;
                ViewBag.estado = x.estado;
                ViewBag.pais = x.pais;
                ViewBag.contacto = x.contacto;

                ViewBag.flag = 1;
            }


            return View();
        }
        [HttpPost]
        public ActionResult actualizaremp(Empresitas newempresa)
        {

            DataClasses1DataContext db = new DataClasses1DataContext();
            cliente c = db.clientes.Single(u => u.id == newempresa.id);
            empresa e = db.empresas.Single(u => u.id == newempresa.id);

            c.nombre = newempresa.nombr;
            c.telefono = newempresa.tel;
            c.direccion = newempresa.dir;
            c.email = newempresa.email;
            c.estado = newempresa.est;
            c.ciudad = newempresa.ciu;
            c.pais = newempresa.pa;
            c.contacto = newempresa.cont;
            e.metodo_pago = newempresa.metodo;
            e.nit = newempresa.nit;

            
            db.SubmitChanges();
            return Redirect("../Cliente/RegistroEmpresas");
        }

        public ActionResult eliminarempresa()
        {
            ViewBag.flag = 0;
            return View();
        }
        [HttpPost]
        public ActionResult eliminarempresa(Empresitas newempresa)
        {
            DataClasses1DataContext dt = new DataClasses1DataContext();


            if ((from i in dt.clientes where i.nombre == newempresa.nombr select i).ToList().Count == 0)
            {
                ViewBag.flag = 0;
            }

            else
            {
                var x = (from i in dt.clientes
                         join j in dt.empresas on i.id equals j.idCli
                         where i.nombre == newempresa.nombr
                         select new
                         {
                             telefono = i.telefono,
                             id = i.id,
                             nit = j.nit,
                             metodo_pago=j.metodo_pago,
                             email = i.email,
                             direccion = i.direccion,
                             ciudad = i.ciudad,
                             estado = i.estado,
                             pais = i.pais,
                             contacto = i.contacto
                         }).ToArray()[0];

                ViewBag.id = x.id;
                ViewBag.nit = x.nit;
                ViewBag.metodo_pago = x.metodo_pago;
                ViewBag.telefono = x.telefono;
                ViewBag.email = x.email;
                ViewBag.direccion = x.direccion;
                ViewBag.ciudad = x.ciudad;
                ViewBag.estado = x.estado;
                ViewBag.pais = x.pais;
                ViewBag.contacto = x.contacto;
                ViewBag.flag = 1;
            }


            return View();
        }

        [HttpPost]
        public ActionResult eliminaremp(String ID)
        {
            int id = Convert.ToInt32(ID);
            DataClasses1DataContext db = new DataClasses1DataContext();
            cliente c = db.clientes.Single(u => u.id == id);
            empresa e = db.empresas.Single(u => u.idCli == id);
            db.empresas.DeleteOnSubmit(e);
            db.SubmitChanges();
            db.clientes.DeleteOnSubmit(c);
            db.SubmitChanges();
            return Redirect("/Cliente/RegistroEmpresas");
        }

       
        public ActionResult exportarCsv()
        {
            return View();
        }
        public ActionResult exportar()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<cliente> datos = db.clientes.ToList();
            string nombre = "clientes" + DateTime.Now.ToString().Replace("/", "_").Replace(":", "_") + "csv";
            string ruta = Server.MapPath("~/download");
            StreamWriter stream = System.IO.File.CreateText(ruta + @"\" + nombre);
            //string cadena = "";
            foreach (var item in datos)
            {

                // cadena+=item.id+,+;
                stream.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", item.id, item.nombre, item.telefono, item.email, item.direccion, item.ciudad, item.estado, item.pais, item.contacto);
            }
            stream.Close();
            return Redirect("/download/" + nombre);
        }

        public ActionResult upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult upload(ArchivoFile datos)
        {
            string rutafisica = Server.MapPath("~/csv");
            string rt = rutafisica + @"/" + datos.archivo.FileName;
            datos.archivo.SaveAs(rutafisica + @"/" + datos.archivo.FileName);
            DataClasses1DataContext db = new DataClasses1DataContext();
            archivo ar = new archivo()
            {
                rutafisica = rutafisica + @"/" + datos.archivo.FileName,
                fecha = DateTime.Now.ToString()
            };
            db.archivos.InsertOnSubmit(ar);
            db.SubmitChanges();
            CsvReader csv = new CsvReader(new StreamReader(rt), true);
            int total = csv.FieldCount;
            string[] headers = csv.GetFieldHeaders();
            List<cliente> listacli = new List<cliente>();
            while (csv.ReadNextRecord())
            {
                cliente cli = new cliente()
                {
                    
                    nombre = csv[1],
                    telefono = csv[2],
                    email = csv[3],
                    direccion = csv[4],
                    pais = csv[5],
                    ciudad = csv[6],
                    estado = csv[7],
                    contacto = csv[8]
                    
                };
                listacli.Add(cli);
                db.clientes.InsertOnSubmit(cli);
                db.SubmitChanges();
            }
            ViewBag.lista = listacli;

            return View();



        }
        public JsonResult loadData()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return Json(new { nombres = db.clientes.Select(a => a.nombre).ToList() });
        }

    }
}

