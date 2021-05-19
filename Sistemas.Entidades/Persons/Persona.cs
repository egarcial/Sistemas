using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Persons
{
    public class Persona
    {
        public int idPersona { get; set; }
        public int idTipoPersona { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "Debe de ingresar primer nombre")]
        [StringLength(50, ErrorMessage = "primer nombre  no puede sobrepasar los 50 caracteres")]
        public string primerNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        [StringLength(50, ErrorMessage = "segundo nombre  no puede sobrepasar los 50 caracteres")]
        public string segundoNombre { get; set; }

        [Display(Name = "Apellido Casada")]
        [StringLength(50, ErrorMessage = "Apellido casada  no puede sobrepasar los 50 caracteres")]
        public string apellidoCasada { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "Debe de ingresar primer apellido")]
        [StringLength(50, ErrorMessage = "primer apellido  no puede sobrepasar los 50 caracteres")]
        public string primerApellido { get; set; }

        [Display(Name = "Sgundo Apellido")]
        [StringLength(50, ErrorMessage = "segundo apellidp  no puede sobrepasar los 50 caracteres")]
        public string segundoApellido { get; set; }

        public int idTipoDocumento { get; set; }

        [Display(Name = "Numero Documento")]
        [Required(ErrorMessage = "Debe de ingresar número documento")]
        [StringLength(20, ErrorMessage = "número de documento no puede sobrepasar los 20 caracteres")]
        public string numeroDocumento { get; set; }

        public int idDireccion { get; set; }
        public int idTelefono { get; set; }
        public int idEmail { get; set; }
        public int idCondicion { get; set; }
    }
}
