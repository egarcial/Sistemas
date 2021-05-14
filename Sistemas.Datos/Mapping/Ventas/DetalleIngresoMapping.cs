using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Ventas;

namespace Sistemas.Datos.Mapping.Ventas
{
    class DetalleIngresoMapping : IEntityTypeConfiguration<DetalleIngreso>
    {
        public void Configure(EntityTypeBuilder<DetalleIngreso> builder)
        {
            builder.ToTable("detalleIngreso").
                HasKey(detIngreso => detIngreso.idDetalleIngreso);
            builder.Property(detIngreso => detIngreso.idingreso);
            builder.Property(detIngreso => detIngreso.idArticulo);
            builder.Property(detIngreso => detIngreso.cantidad);
            builder.Property(detIngreso => detIngreso.precioDetalle);
        }
    }
}
