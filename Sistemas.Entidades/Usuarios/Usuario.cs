using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.Usuarios
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        [Required]
        [StringLength(100, MinimumLength =4, ErrorMessage ="Nombre debe comprender entre un minimo de 4 y máximo 100 carateres")]
        public string nombre { get; set; }
        public string tipoDocumento { get; set; }
        public int numDocumento { get; set; }
        [Required]
        [StringLength(70, MinimumLength =25, ErrorMessage ="Dirección debe de comprender entre un minimo 25 y máximo 70 caracteres")]
        public string direccion { get; set; }
        [Required]
        [StringLength(11, ErrorMessage ="Número de teléfono de tener 11 números")]
        public string telefono { get; set; }
        [Required]
        [StringLength(50, MinimumLength =6, ErrorMessage ="Direccion de correo electrónico debe comprender entre un mínimo de 6 y máximo de 50 caracteres")]
        public string email { get; set; }
        [Required]
        [StringLength(64)]
        public string passwordHash { get; set; }
        [Required]
        [StringLength(64)]
        public string passwordSalt { get; set; }
        public bool condicion { get; set; }
    }
}
