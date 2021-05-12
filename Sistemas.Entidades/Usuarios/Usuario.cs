using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.Usuarios
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage ="Nombre de Catergoria es obligatorio")]
        [StringLength(100, MinimumLength =4, ErrorMessage ="Nombre debe comprender entre un minimo de 4 y máximo 100 carateres")]
        public string nombre { get; set; }

        public string tipoDocumento { get; set; }

        [Display(Name ="Número Documento")]
        public int numDocumento { get; set; }
        
        [Required]
        [StringLength(70, MinimumLength =25, ErrorMessage ="Dirección debe de comprender entre un minimo 25 y máximo 70 caracteres")]
        public string direccion { get; set; }
        
        [Required]
        [StringLength(11, ErrorMessage ="Número de teléfono de tener 11 números")]
        public string telefono { get; set; }
       
        [Display(Name ="Correo Electrónico:")]
        [Required]
        [EmailAddress]
        public string email { get; set; }
        
        [Required]
        [StringLength(64)]
        [Display(Name ="Contraseña Hash")]
        public string passwordHash { get; set; }
        
        [Required]
        [StringLength(64)]
        [Display(Name = "Contraseña Salt")]
        public string passwordSalt { get; set; }
       
        public bool condicion { get; set; }
    }
}
