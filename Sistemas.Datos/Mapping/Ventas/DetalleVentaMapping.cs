using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Ventas;

namespace Sistemas.Datos.Mapping.Ventas
{
    public class DetalleVentaMapping : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("detalleIngreso").
               HasKey(detVenta => detVenta.idDetalleVenta);
            builder
                .Property(detVenta => detVenta.idVenta);
            builder
                .Property(detVenta => detVenta.idVenta);
            builder
                .Property(detVenta => detVenta.idArticulo);
            builder
                .Property(detVenta => detVenta.cantidad);
            builder
                .Property(detVenta => detVenta.precioDetalleVenta);
            builder
                .Property(detVenta => detVenta.descuento);
        }
    }
}
