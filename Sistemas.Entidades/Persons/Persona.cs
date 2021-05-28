using Sistemas.Entidades.Conditions;
using Sistemas.Entidades.Documents;
using Sistemas.Entidades.Personal_Information;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Persons
{
    public class Persona
    {
        public int idPersona { get; set; }
      
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

        [Display(Name = "Numero Documento")]
        [Required(ErrorMessage = "Debe de ingresar número documento")]
        [StringLength(20, ErrorMessage = "número de documento no puede sobrepasar los 20 caracteres")]
        public string numeroDocumento { get; set; }

        public List<TipoPersona> TipoPersonas { get; set; }

        public List<Documento> Documentos { get; set; }

        public List<Direccion> Direcciones { get; set; }

        public List<Telefono> Telefonos { get; set; }

        public List<Email> Emails { get; set; }

        public List<Condicion> Condiciones { get; set; }

    }
}
