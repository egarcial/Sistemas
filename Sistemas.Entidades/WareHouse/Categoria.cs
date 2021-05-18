using System.ComponentModel.DataAnnotations;

namespace Sistemas.Entidades.WareHouse
{
    public class Categoria
    {
        public int idCategoria { get; set; }

        [Display(Name = "Nombre de Categoria")]
        [Required(ErrorMessage = "Debe ingresar nombre de Categoria")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe comprender entre 3 a 50 caractere")]
        public string nombre { get; set; }

        [Display(Name = "Nombre de Categoria")]
        [StringLength(256)]
        public string descripcion { get; set; }

        [Display(Name = "Condición")]
        public int idCondicion { get; set; }
    }
}
