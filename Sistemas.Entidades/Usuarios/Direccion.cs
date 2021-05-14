using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Usuarios
{
    public class Direccion
    {
        public int idDireccion { get; set; }
        public int idMunicipio { get; set; }
        public string nombreCalle { get; set; }
        public int numeroCalle { get; set; }
        public string avenida { get; set; }
        public string barrio { get; set; }
        public int zona { get; set; }
        public int numeroCasa { get; set; }
        public string referencia { get; set; }
    }
}
