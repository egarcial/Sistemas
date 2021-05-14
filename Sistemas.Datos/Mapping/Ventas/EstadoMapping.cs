using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Ventas;

namespace Sistemas.Datos.Mapping.Ventas
{
    public class EstadoMapping : IEntityTypeConfiguration<Estado>
    {
         public void Configure(EntityTypeBuilder<Estado> builder)
         {
            builder.ToTable("tbl_Estado").
              HasKey(estado => estado.idEstado);
            builder
                .Property(estado => estado.estado)
                .HasMaxLength(20);

        }
    }
}
