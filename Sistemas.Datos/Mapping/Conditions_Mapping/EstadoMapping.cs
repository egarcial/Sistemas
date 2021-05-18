using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Conditions_Mapping
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
