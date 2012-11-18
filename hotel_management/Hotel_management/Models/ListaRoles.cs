using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_management.Models
{
    public class RolView
    {
        public Guid id { set; get; }
        public string nombre { set; get; }
    }
    public class UserListRol
    {
        public Guid id { set; get; }
        public string nombre { set; get; }
        public List<RolView> ListaRoles { set; get; }
    }

}