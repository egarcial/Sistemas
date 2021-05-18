using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.Users
{
    public class Departamento
    {
        public int idDepatamento { get; set; }

        [Display(Name = "Nombre Departamento")]
        [Required(ErrorMessage = "Deberá ingresar nombre del departamento")]
        [StringLength(50, ErrorMessage = "Nombre del departamento sobrepasar los 50 numeros")]
        public string nombreDepartamento { get; set; }

    }
}
