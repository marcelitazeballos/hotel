using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel_management.Models;
using a=System.Web.Security;
using System.Data.SqlClient;

namespace Hotel_management.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult perfil()
        {
           
            
            return View();        
        }


    }
}
