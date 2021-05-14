using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Almacen;

namespace Sistemas.Datos.Mapping.Almacen
{
   public class ArticuloMapping : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("articulo").HasKey(articulo => articulo.idCategoria);
            builder.Property(articulo => articulo.idCategoria);
            builder.Property(articulo => articulo.codigo).HasMaxLength(50);
            builder.Property(articulo => articulo.nombre).HasMaxLength(50);
            builder.Property(articulo => articulo.precioVenta);
            builder.Property(articulo => articulo.stock);
            builder.Property(articulo => articulo.descripcion).HasMaxLength(256);
            builder.Property(articulo => articulo.idCondicion);
        }
    }
}
