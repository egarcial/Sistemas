using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Documents_Mapping
{
    public class ComprobanteMapping : IEntityTypeConfiguration<Comprobante>
    {
        public void Configure(EntityTypeBuilder<Comprobante> builder)
        {
            builder.ToTable("tbl_comprobante").HasKey(comprbante => comprbante.idTipoComprobante);
            builder.Property(comprobante => comprobante.tipoComprobante).HasMaxLength(20);

        }

    }
}
