using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Ventas;

namespace Sistemas.Datos.Mapping.Ventas
{
    public class DocumentoMapping : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable("tbl_Documento").
               HasKey(documento => documento.idTipoDocumento);
            builder
                .Property(documento => documento.tipoDocumento)
                .HasMaxLength(50);

        }
    }
}
