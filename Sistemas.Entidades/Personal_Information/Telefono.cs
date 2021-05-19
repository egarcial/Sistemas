using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Personal_Information
{
    public class Telefono
    {
        public int idTelefono { get; set; }

        [Display(Name = "Movil 1")]
        [Required(ErrorMessage = "Debe de ingresar nombre de condición")]
        [StringLength(20, ErrorMessage = "nombre de condición no puede sobrepasar los 20 caracteres")]
        public string movil_1 { get; set; }

        [Display(Name = "Movil 2")]
        public string movil_2 { get; set; }

        [Display(Name = "Telefono Casa 1")]
        public string telCasa { get; set; }

        [Display(Name = "Telefono Oficina 2")]
        public string telOficina { get; set; }
    }
}
