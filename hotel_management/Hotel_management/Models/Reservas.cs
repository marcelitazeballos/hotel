using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_management.Models
{
    public class Reservas
    {
        public int id_cli { get; set; }

        public int id_tip { get; set; }

        public string fecha_ini { get; set; }

        public string fecha_fin { get; set; }

        public int estado { get; set; }

        public int can_hab { get; set; }

    }
}