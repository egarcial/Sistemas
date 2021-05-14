using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Usuarios
{
    public class Usuarios
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string apellidoCasada { get; set; }
        public string  primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public int idTipoDocumento { get; set; }
        public string numDocumento { get; set; }
        public int idDireccion { get; set; }
        public int idTelefono { get; set; }
        public int  idEmail { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
        public int idCondicion { get; set; }


    }
}
