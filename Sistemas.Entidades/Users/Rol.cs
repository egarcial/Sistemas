using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sistemas.Entidades.Users
{
    public class Rol
    {
        public int idRol { get; set; }
        [Display(Name = "Nombre de Rol")]
        [Required(ErrorMessage = "Debe de ingresar Rol")]
        [StringLength(30, ErrorMessage = "Rol no puede sobrepasar los 30 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(100, ErrorMessage = "Descripcion no puede sobrepasar los 100 caracteres")]
        public string descripcion { get; set; }

        public int idCondicion { get; set; }

    }
}
