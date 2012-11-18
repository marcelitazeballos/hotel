using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_management.Models
{
    public class Mantenimientos
    {
        public String numero { get; set; }
        public String fecha_ini { get; set; }
        public String fecha_fin { get; set; }
        public int id_hab { get; set; }
    }
}