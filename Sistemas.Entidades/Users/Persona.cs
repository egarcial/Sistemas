using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Entidades.Users
{
    public class Persona
    {
        public int idPersona { get; set; }
        public int idTipoPersona { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string apellidoCasada { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public int idTipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public int idDireccion { get; set; }
        public int idTelefono { get; set; }
        public int idEmail { get; set; }
        public int idCondicion { get; set; }
    }
}
