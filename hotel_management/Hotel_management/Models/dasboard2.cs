using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections;

namespace Hotel_management.Models
{
    public class infohdash
    {
        public string hab { get; set; }
        public string tipo { get; set; }
        //public string num { get; set; }
        public List<DateTime> desde { get; set; }
        public List<DateTime> hasta { get; set; }
    }

    public class dasboard2
    {
        //public  canh { get; set;}
        public bool semanal { get; set; }
             
        public List<infohdash> habitaciones { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }

    }
}