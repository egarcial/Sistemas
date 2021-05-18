using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Users
{
    public class Rol
    {
        public int idRol { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idCondicion { get; set; }

    }
}
