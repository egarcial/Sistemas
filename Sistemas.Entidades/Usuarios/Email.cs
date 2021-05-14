using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Usuarios
{
   public class Email
    {
        public int idEmail { get; set; }

        [Display(Name = "Correo Electrónico Personal")]
        [Required(ErrorMessage = "Debe ingresar un correo electrónico")]
        [EmailAddress(ErrorMessage = "Favor introduzca un correo electrónico valido!!")]
        public string emailPersonal { get; set; }

        [Display(Name = "Correo Electrónico Laboral")]
        [Required(ErrorMessage = "Debe ingresar un correo electrónico")]
        [EmailAddress(ErrorMessage = "Favor introduzca un correo electrónico valido!!")]
        public string emailLaboral { get; set; }
    }
}
