
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Ventas;

namespace Sistemas.Datos.Mapping.Ventas

{
   public class ComprobanteMapping : IEntityTypeConfiguration<Comprobante>
    {
        public void Configure(EntityTypeBuilder<Comprobante> builder)
        {
            builder.ToTable("comprobante").HasKey(comprbante => comprbante.idTipoComprobante);
            builder.Property(comprobante => comprobante.tipoComprobante).HasMaxLength(20);

        }

    }
}
