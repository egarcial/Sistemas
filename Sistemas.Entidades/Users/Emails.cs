using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.Users
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
