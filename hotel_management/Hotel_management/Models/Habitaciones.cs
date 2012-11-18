using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_management.Models
{
    public class Habitaciones
    {
        public int id { get; set; }
        public string estado { get; set; }
        public string numero { get; set; }
        public string idTipo { set; get; }
    }
    public class verhabitacion
    {
        public string estado { get; set; }
        public string numero { get; set; }
        public string idTipo { set; get; }

    }
    public class rehabitaciones
    {
        public string estado { get; set; }
        public string numero { get; set; }
        public string idTipo { set; get; }
        public List<verhabitacion> ListaHabitacion { get; set; }
    }

}