using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.Almacen
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe comprender entre 3 a 50 caractere")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        public bool condicion { get; set; }
    }
}
