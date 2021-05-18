using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.Users
{
    public class Direccion
    {
        public int idDireccion { get; set; }
        [Required]
        public int idMunicipio { get; set; }

        [Display(Name = "Nombre de Calle")]
        [StringLength(50, ErrorMessage = "Nombre de calle no puede sobrepasar los 50 caracteres")]
        public string nombreCalle { get; set; }

        [Display(Name = "Número de Calle")]
        public int numeroCalle { get; set; }

        [Display(Name = "Avenida")]
        [StringLength(50, ErrorMessage = "Avenida no puede sobrepasar los 50 caracteres")]
        public string avenida { get; set; }

        [Display(Name = "Barrio")]
        [StringLength(50, ErrorMessage = "Barrio no puede sobrepasar los 50 caracteres")]
        public string barrio { get; set; }

        [Display(Name = "Zona")]
        public int zona { get; set; }

        [Display(Name = "Numero de Casa")]
        public int numeroCasa { get; set; }

        [Display(Name = "Referencia")]
        [StringLength(50, ErrorMessage = "Referencia no puede sobrepasar los 50 caracteres")]
        public string referencia { get; set; }
    }
}
