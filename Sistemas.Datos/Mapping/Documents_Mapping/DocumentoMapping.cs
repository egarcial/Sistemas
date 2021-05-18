using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Documents_Mapping
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
