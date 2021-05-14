using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Almacen;

namespace Sistemas.Datos.Mapping.Almacen
{
    //vamos a mapear de lo que traemos de nuestra entidad
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            /*hacemos conexion con la tabla categoria en la BD
             y el haskey c va ser el idCategoria que sera la llave primaria*/
            builder.ToTable("categoria").
                HasKey(categoria => categoria.idCategoria);
            builder.Property(categoria => categoria.nombre)
                .HasMaxLength(50);
            builder.Property(categoria => categoria.descripcion)
                .HasMaxLength(256);
        }
    }
    
}
