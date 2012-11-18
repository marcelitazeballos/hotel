using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_management.Models
{
    public class ArchivoFile
    {
        public HttpPostedFileBase archivo { get; set; }
        public string rutafisica { get; set; }
    }
    public class clientes
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string contacto { get; set; }
        
    }
}